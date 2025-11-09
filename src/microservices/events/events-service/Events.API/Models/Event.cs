<<<<<<< HEAD
<<<<<<< HEAD
﻿namespace Events.API.Models;

public record Event(string Id,string Type ,DateTime TimeStamp ,object Payload );
=======
﻿namespace Events.API.Models
{
    public record Event
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public DateTime TimeStamp { get; set; }

        public object Payload { get; set; }
    }
}
>>>>>>> d01950b ()
=======
﻿namespace Events.API.Models;

	public record Event(string Id, string Type, DateTime Timestamp, object Payload);

	public record MovieEvent(int MovieId, string Title, string Action, int? UserId = null,
					   double? Rating = null, string[]? Genres = null, string? Description = null);

	public record UserEvent(int UserId, string Action, DateTime Timestamp, string? Username = null, string? Email = null);

	public record PaymentEvent(int PaymentId, int UserId, double Amount, string Status, DateTime Timestamp, string? MethodType = null);

	public record EventResponse(string Status, int Partition, long Offset, Event Event);

