using System;
using UnityEngine;

public abstract class AView : MonoBehaviour
{
    public Action EventOnEnable;
    public Action EventOnDisable;

    protected AController controller;

    public AController Controller => controller;

    public class APresentInfo
    {
    }

    public void InitView(AController controller)
    {
        this.controller = controller;
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
