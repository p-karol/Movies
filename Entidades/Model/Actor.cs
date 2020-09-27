using System;
using System.Collections.Generic;

namespace Entidades.Model
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
