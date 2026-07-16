// Sanctioned shared communication channel for robot missions.
// Publishers (e.g. FleetHandler) dispatch missions; receivers (robots) subscribe.
public interface IMessageHandler
{
    void Register(IMissionReceiver receiver);
    void Unregister(IMissionReceiver receiver);
    void Dispatch(RobotMission mission);
}

// Implemented by anything that can execute an assigned mission.
public interface IMissionReceiver
{
    void OnMissionAssigned(RobotMission mission);
}
