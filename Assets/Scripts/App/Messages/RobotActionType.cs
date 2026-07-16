// Atomic action a robot can be told to perform within a mission step.
public enum RobotActionType
{
    MoveTo,   // Travel to a target station.
    PickUp,   // Load cargo at the current station.
    DropOff,  // Unload cargo at the current station.
    Wait,     // Idle (reserved for future use).
}
