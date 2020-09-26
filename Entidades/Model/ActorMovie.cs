using System;
namespace Entidades.Model
{
    public class ActorMovie
    {
        public int ActorMovieId { get; set; }
        public string Character { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}
