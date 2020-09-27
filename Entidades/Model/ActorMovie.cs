using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Model
{
    public class ActorMovie
    {
        public int ActorMovieId { get; set; }
        public string Character { get; set; }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("ActorId")]
        public int ActorId { get; set; }

        public virtual Movie Movies { get; set; }
        public virtual Actor Actors { get; set; }
        
    }
}
