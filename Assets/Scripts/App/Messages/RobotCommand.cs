// Immutable single step of a robot mission.
// All fields are private and set only through the constructor;
// external readers access data through accessors only.
public class RobotCommand
{
    // Sentinel meaning "no specific cargo; use the first available one".
    public const int AnyCargo = -1;

    readonly RobotActionType action;
    readonly StationId target;
    readonly int cargoTag;

    public RobotCommand(RobotActionType action, StationId target, int cargoTag = AnyCargo)
    {
        this.action = action;
        this.target = target;
        this.cargoTag = cargoTag;
    }

    public RobotActionType Action => action;
    public StationId Target => target;
    public int CargoTag => cargoTag;

    public bool HasSpecificCargo => cargoTag != AnyCargo;
}
