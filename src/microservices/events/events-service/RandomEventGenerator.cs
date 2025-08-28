namespace events_service
{
public class RandomEventGenerator
{
    private static readonly Dictionary<string, string[]> EventTypes = new()
    {
        { "movie", new[] { "MovieCreated", "MovieUpdated", "MovieDeleted" } },
        { "user", new[] { "UserRegistered", "UserLoggedIn", "UserLoggedOut" } },
        { "payment", new[] { "PaymentProcessed", "PaymentFailed" } }
    };

    private readonly Random _rnd = new();

    public object Generate(string category)
    {
        if (!EventTypes.ContainsKey(category))
            throw new ArgumentException($"Unknown category {category}");

        var type = EventTypes[category][_rnd.Next(EventTypes[category].Length)];
        return new
        {
            Id = Guid.NewGuid(),
            Type = type,
            Category = category,
            Timestamp = DateTime.UtcNow
        };
    }
}}
