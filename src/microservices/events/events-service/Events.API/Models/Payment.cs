namespace Events.API.Models
{
    public record Payment : ItemBase
    {
        public int? Id { get; set; }
        
        public int UserId { get; set; }
        
        public double Amount { get; set; }
        
        public string Status { get; set; }

        public DateTime Timestamp { get; set; }

        public string? MethodType { get; set; }
    }
}
