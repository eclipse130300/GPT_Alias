using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace AliasGPT
{
    public class PopupsManager
    {
        private const string BaePath = "Windows/";
        
        //private Stack<>
        
        public void ShowPopup<T>(T popup) where T : Component, IBaseWindow
        {
            var path = Path.Combine(BaePath, popup.GetType().Name);
            var prefab =  Resources.LoadAsync<T>(path);
            
            if(prefab == null)
                Debug.LogError($"Popup {popup.GetType().Name} not found");
            
            //var instance = Object.Instantiate(prefab);
        }
    }
}