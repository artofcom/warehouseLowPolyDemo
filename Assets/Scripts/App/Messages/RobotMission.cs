using System.Collections.Generic;

// Immutable message describing one robot job as an ordered set of commands.
// The mission holds the plan only; runtime progress (which step is active)
// is tracked by the executor, not stored here.
public class RobotMission
{
    readonly int missionId;
    readonly RobotCommand[] steps;

    public RobotMission(int missionId, IReadOnlyList<RobotCommand> steps)
    {
        this.missionId = missionId;

        // Defensive copy so the mission stays immutable regardless of the caller.
        int count = steps != null ? steps.Count : 0;
        this.steps = new RobotCommand[count];
        for(int q = 0; q < count; ++q)
            this.steps[q] = steps[q];
    }

    public int MissionId => missionId;
    public int StepCount => steps.Length;

    public RobotCommand StepAt(int index) => steps[index];
}
