namespace Events.API.Models;

public record Payment(int PaymentId, int UserId, double Amount, string Status, DateTime Timestamp, string? MethodType);

