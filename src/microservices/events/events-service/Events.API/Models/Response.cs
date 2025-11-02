namespace Events.API.Models;

public record Response(string Status,  int Partition, long Offset, Event Event);
