using System.Collections.Generic;
using UnityEngine;

public class StationModule : AModule
{   
    [SerializeField] List<GameObject> cargoBoxes;

    public override void Init(AContext ctx)
    {
        var model = new StationModel();
        controller = new StationController(ctx, model, view);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
