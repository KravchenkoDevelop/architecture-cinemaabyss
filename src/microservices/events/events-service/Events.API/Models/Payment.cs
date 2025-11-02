<<<<<<< HEAD
﻿namespace Events.API.Models;

public record Payment(int PaymentId, int UserId, double Amount, string Status, DateTime Timestamp, string? MethodType);

=======
﻿namespace Events.API.Models
{
    public record Payment 
    {
        public int PaymentId { get; set; }

        public int UserId { get; set; }

        public double Amount { get; set; }

        public string Status { get; set; }

        public DateTime Timestamp { get; set; }

        public string? MethodType { get; set; }
    }
}
>>>>>>> d01950b ()
