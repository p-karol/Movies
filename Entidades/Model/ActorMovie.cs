using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Model
{
    public class ActorMovie
    {
        public int ActorMovieId { get; set; }
        public string Character { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public virtual Movie Movies { get; set; }
        public virtual Actor Actors { get; set; }
        //public virtual ICollection<Movie> Movies { get; set; }
        //public virtual ICollection<Actor> Actors { get; set; }
    }
}
