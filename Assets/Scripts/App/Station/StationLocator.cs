using System.Collections.Generic;
using UnityEngine;

public class StationLocator : IStationLocator
{
    readonly Dictionary<StationId, StationModule> stations;

    public StationLocator(IReadOnlyDictionary<StationId, StationModule> stations)
    {
        // Defensive copy so the locator owns its mapping.
        this.stations = new Dictionary<StationId, StationModule>();
        foreach(var pair in stations)
            this.stations[pair.Key] = pair.Value;
    }

    public Vector3 GetPosition(StationId id) => stations[id].GetViewPosition();

    public IStationService GetService(StationId id) => stations[id];
}
