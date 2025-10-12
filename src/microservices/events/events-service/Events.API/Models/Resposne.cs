using System.Runtime.CompilerServices;

namespace Events.API.Models
{
    public record Resposne
    {
        public string Status { get; set; }
        public Event Event { get; set; }


    }
}
