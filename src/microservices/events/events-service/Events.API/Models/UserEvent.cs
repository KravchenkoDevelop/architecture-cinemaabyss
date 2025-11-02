namespace Events.API.Models;

public record UserEvent(int UserId, string Action, DateTime Timestamp, string? Username, string? Email);
