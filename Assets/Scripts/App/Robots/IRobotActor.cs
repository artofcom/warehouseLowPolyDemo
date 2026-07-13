
public interface IRobotActor
{
    void PickUp(ITransportable transportable);
    ITransportable GetCargo();
    void UnloadCargo();
}
