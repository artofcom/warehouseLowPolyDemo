using System.Collections.Generic;
using UnityEngine;

public class StationModule : AModule
{   
    public override void Init(AContext ctx)
    {
        var model = new StationModel();
        controller = new StationController(ctx, this, model, view);
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    public Vector3 GetViewPosition()
    {
        return (controller as StationController).GetViewPosition();
    }
}
