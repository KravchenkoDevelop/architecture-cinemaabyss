namespace Events.API.Models
{
    public record Event
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public DateTime TimeStamp { get; set; }

        public object Payload { get; set; }
    }
}
