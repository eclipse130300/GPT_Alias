using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace AliasGPT
{
    public class PopupsManager
    {
        private const string BaePath = "Windows/";

        private readonly Transform _uiRoot;
        private readonly IInstantiator _instantiator;

        public PopupsManager(IInstantiator instantiator, Transform uiRoot)
        {
            _instantiator = instantiator;
            _uiRoot = uiRoot;
        }

        private List<WindowInfo> _intstantiatedList = new ();
        
        public async UniTask<bool> ShowPopup<T>() where T : BaseWindow
        {
            Debug.Log($"Showing popup {typeof(T).Name}");
            var tcs = new UniTaskCompletionSource<bool>();

            var instantiated = await HandleIntatntiatedPopupLoad<T>(tcs);
            if(instantiated)
                return true;
            
            HandleAsyncPopupLoad<T>(tcs);

            return await tcs.Task;
        }

        private async UniTask<bool> HandleIntatntiatedPopupLoad<T>(UniTaskCompletionSource<bool> tcs) where T :  BaseWindow
        {
            var type = typeof(T);
            
            if (TryGetInstantiated(type, out var windowInfo))
            {
                //set as last sibling
                windowInfo.GameObject.transform.SetAsLastSibling();
                
                await ShowLogic(windowInfo);
                tcs.TrySetResult(true);

                return true;
            }

            return false;
        }

        private void HandleAsyncPopupLoad<T>(UniTaskCompletionSource<bool> tcs) where T : BaseWindow
        {
            var type = typeof(T);
            var path = Path.Combine(BaePath, type.Name);
            var asyncLoad = Resources.LoadAsync<T>(path);

            asyncLoad.completed += async operation =>
            {
                var prefab = asyncLoad.asset as T;
                if (prefab == null)
                    Debug.LogError($"Popup {type.Name} not found");

                var instance = _instantiator.InstantiatePrefabForComponent<T>(prefab,_uiRoot);
                var animator = instance.GetComponent<IWindowAnimator>();
                
                var windowInfo = new WindowInfo(typeof(T), instance.gameObject, animator);

                _intstantiatedList.Add(windowInfo);

                await ShowLogic(windowInfo);

                tcs.TrySetResult(true);
            };
        }

        private static async UniTask ShowLogic(WindowInfo windowInfo)
        {
            windowInfo.GameObject.SetActive(true);
            await windowInfo.Animator.AnimateShow();
        }

        public async UniTask<bool> HidePopup<T>(T popup) where T : BaseWindow
        {
            Debug.Log($"Hiding popup {popup.gameObject.name}");

            var tcs = new UniTaskCompletionSource<bool>();
            
            if(TryGetInstantiated(popup.GetType(), out var windowInfo))
            {
                await HideLogic(windowInfo);
                tcs.TrySetResult(true);
            }
            
            return await tcs.Task;
        }

        private static async UniTask HideLogic(WindowInfo windowInfo)
        {
            if(windowInfo.HasAnimator())
                await windowInfo.Animator.AnimateHide();
            
            windowInfo.GameObject.SetActive(false);
        }

        private bool TryGetInstantiated(Type type, out WindowInfo info)
        {
            var contains = _intstantiatedList.Any(x => x.Type == type);
            if (!contains)
            {
                info = null;
                return false;
            }
            
            var windowInfo = _intstantiatedList.Find(x => x.Type == type);
            info = windowInfo;
            return true;
        }
    }
}