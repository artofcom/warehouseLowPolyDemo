using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FleetHandlerModule : AModule
{   
    [SerializeField] RobotModule robotModule;
    [SerializeField] List<StationModule> stationModules;


    Context context;
    public override void Init(AContext ctx)
    {
        context = ctx as Context;

        var model = new FleetHandlerModel();
        controller = new FleetHandlerController(ctx, model, view);
        
        DeferedInit();
    }

    async void DeferedInit()
    {
        // Wait so station transforms are settled before reading positions.
        await Task.Delay(100);

        // Index convention: [0] = pickup, [1] = dropoff.
        var map = new Dictionary<StationId, StationModule>();
        if(stationModules != null && stationModules.Count > 0)
            map[StationId.PickUp] = stationModules[0];
        if(stationModules != null && stationModules.Count > 1)
            map[StationId.DropOff] = stationModules[1];

        context.UpdateData("StationLocator", new StationLocator(map));
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
