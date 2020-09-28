using Entidades.Model;
using Entidades.ViewModel;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interface
{
    public interface IActors
    {
        Task Inserir(Actor Actor);
        Task<List<Actor>> List();
        Task Delete(Actor Actor);
        Task<Actor> GetActorById(int Id);
        Task Update(Actor Actor);

        //Task<ICollection<ActorSummary>> getActorSummary();
    }
}
