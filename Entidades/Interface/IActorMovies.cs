using Entidades.Model;
using Entidades.ViewModel;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interface
{
    public interface IActorMovies
    {
        Task Inserir(ActorMovie ActorMovie);
        Task<List<ActorMovie>> List();
        Task Delete(ActorMovie ActorMovie);
        Task<ActorMovie> GetActorMovieById(int Id);
        Task Update(ActorMovie ActorMovie);

        //Task<ICollection<ActorMovieSummary>> getActorMovieSummary();
    }
}
