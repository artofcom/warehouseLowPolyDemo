// Runtime state of the robot while executing a mission.
// Fields are private; state changes go through intent methods and reads through accessors.
public class RobotModel : AModel
{
    RobotMission mission;
    int stepCursor;
    MissionStatus status = MissionStatus.Idle;
    CargoComp carriedCargo;

    public MissionStatus Status => status;
    public bool HasActiveMission => status == MissionStatus.Running;
    public CargoComp CarriedCargo => carriedCargo;

    public RobotCommand CurrentCommand
        => (mission != null && stepCursor >= 0 && stepCursor < mission.StepCount)
            ? mission.StepAt(stepCursor)
            : null;

    public void AssignMission(RobotMission newMission)
    {
        mission = newMission;
        stepCursor = 0;
        status = (mission != null && mission.StepCount > 0)
            ? MissionStatus.Running
            : MissionStatus.Completed;
    }

    // Advances to the next command; returns false when the mission is finished.
    public bool MoveToNextCommand()
    {
        if(mission == null)
        {
            status = MissionStatus.Completed;
            return false;
        }

        stepCursor++;
        if(stepCursor >= mission.StepCount)
        {
            status = MissionStatus.Completed;
            return false;
        }
        return true;
    }

    public void SetCarriedCargo(CargoComp cargo)
    {
        carriedCargo = cargo;
    }
}
