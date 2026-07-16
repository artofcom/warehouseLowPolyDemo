// Runtime lifecycle state of a mission being executed by a robot.
public enum MissionStatus
{
    Idle,       // No mission assigned.
    Running,    // Executing commands.
    Completed,  // All commands finished.
}
