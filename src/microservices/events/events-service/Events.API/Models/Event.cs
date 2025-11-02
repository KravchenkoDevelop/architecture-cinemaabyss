namespace Events.API.Models;

public record Event(string Id,string Type ,DateTime TimeStamp ,object Payload );
