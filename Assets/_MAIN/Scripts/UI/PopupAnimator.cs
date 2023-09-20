using Cysharp.Threading.Tasks;
using UnityEngine;

public class PopupAnimator : MonoBehaviour, IWindowAnimator
{
    public UniTask AnimateShow()
    {
        Debug.Log("Start show animation");
        return UniTask.Delay(1);
    }

    public UniTask AnimateHide()
    {
        Debug.Log("Start hide animation");
        return UniTask.Delay(1);
    }
}