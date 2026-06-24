using System;
using UnityEngine;

public abstract class AView : MonoBehaviour
{
    public Action EventOnEnable;
    public Action EventOnDisable;

    public class APresentInfo
    {
    }

    private void OnEnable()
    {
        EventOnEnable?.Invoke();
    }

    private void OnDisable()
    {
        EventOnDisable?.Invoke();
    }

    public virtual void Refresh(APresentInfo info) { }

}
