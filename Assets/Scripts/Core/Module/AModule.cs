using UnityEngine;

public abstract class AModule : MonoBehaviour
{
    [SerializeField] protected AView view;

    protected AController controller;

    abstract public void Init(AContext ctx);
    public virtual void Dispose()
    {
        controller?.Dispose();
        
        controller = null;
    }
}
