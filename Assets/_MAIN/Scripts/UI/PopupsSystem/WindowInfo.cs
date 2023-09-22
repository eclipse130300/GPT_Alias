using System;
using UnityEngine;

public class WindowInfo
{
    public Type Type;
    public GameObject GameObject;
    public IWindowAnimator Animator;

    public WindowInfo(Type type, GameObject gameObject, IWindowAnimator animator)
    {
        Type = type;
        GameObject = gameObject;
        Animator = animator;
    }
    
    public bool HasAnimator() => Animator != null;
}