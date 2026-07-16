// Cargo service a station exposes to robots executing mission steps.
public interface IStationService
{
    // Returns a cargo to load (pickup station), or null if none / unsupported.
    CargoComp TakeCargo(int cargoTag);

    // Accepts a cargo to unload (drop station); no-op if unsupported.
    void ReceiveCargo(CargoComp cargo);
}
