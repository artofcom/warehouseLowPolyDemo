using UnityEngine;

// Resolves a logical StationId to its world position and cargo service.
public interface IStationLocator
{
    Vector3 GetPosition(StationId id);
    IStationService GetService(StationId id);
}
