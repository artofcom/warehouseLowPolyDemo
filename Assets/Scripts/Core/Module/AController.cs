using UnityEngine;
using System;
using System.Threading.Tasks;

public abstract class AController 
{
    protected AContext context;
    protected AModel model;
    protected AView view;

    public AController(AContext ctx, AModel model, AView view)
    {
        this.context = ctx;
        this.model = model;
        this.view = view;

        if(view != null) 
        {
            this.view.InitView(this);

            view.EventOnEnable += OnViewEnabled;
            view.EventOnDisable += OnViewDisabled;

            if(view.isActiveAndEnabled)
                RunWithDelay(10, OnViewEnabled);
        }
        Debug.Log("[AController] Constructor called.");
    }

    public virtual void Dispose()
    {
        Debug.Log("[AController] Dispose called");

        if(view != null) 
        {
            view.EventOnEnable -= OnViewEnabled;
            view.EventOnDisable -= OnViewDisabled;
        }
    }

    async void RunWithDelay(int delay, Action action)
    {
        await Task.Delay(delay);

        action?.Invoke();
    }

    protected virtual void OnViewEnabled()
    {
        Debug.Log("[AController] OnView Enabled");
    }

    protected virtual void OnViewDisabled() 
    {
        Debug.Log("[AController] OnView Disabled");
    }
}
