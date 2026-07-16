using UnityEngine;

public class StationController : AController
{
    StationView View;

    public StationController(AContext ctx, AModule module, AModel model, AView view) : base(ctx, model, view)
    {
        View = view as StationView;
    }

    public Vector3 GetViewPosition()
    {
        return View.transform.position;
    }
}
