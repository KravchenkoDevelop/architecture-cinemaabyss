<<<<<<< HEAD
﻿namespace Events.API.Models;

public record Movie(int MovieId, string Title, string Description, string Action, int? UserId, double? Rating);


=======
﻿namespace Events.API.Models
{
    public record Movie : ItemBase
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        string Action { get; set; }

        public int? UserId { get; set; }

        double? Rating { get; set; } = 0;
    }
}
>>>>>>> d01950b ()
