// Logical identifier of a station a command can target.
// Kept as an enum while station kinds are few; promote to a value type
// (unique id) if multiple stations of the same kind are needed later.
public enum StationId
{
    PickUp,
    DropOff,
}
