namespace Events.API.Models;

record UserEvent(int UserId, string Action, DateTime Timestamp, string? Username, string? Email);
