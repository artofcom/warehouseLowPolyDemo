using System.Collections.Generic;

// Builds robot missions in code (no external data source yet).
// Acts as the higher-level "order -> mission" compiler for now; can be
// promoted to a dedicated TransportOrder type when orders gain more data.
public static class MissionFactory
{
    // Standard transport job: go to 'from', pick up, go to 'to', drop off.
    public static RobotMission CreateTransport(int missionId, StationId from, StationId to, int cargoTag = RobotCommand.AnyCargo)
    {
        var steps = new List<RobotCommand>
        {
            new RobotCommand(RobotActionType.MoveTo,  from),
            new RobotCommand(RobotActionType.PickUp,  from, cargoTag),
            new RobotCommand(RobotActionType.MoveTo,  to),
            new RobotCommand(RobotActionType.DropOff, to,   cargoTag),
        };

        return new RobotMission(missionId, steps);
    }
}
