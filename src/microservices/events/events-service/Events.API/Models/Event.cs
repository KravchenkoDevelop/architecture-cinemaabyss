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
