using Entidades.Model;
using Entidades.ViewModel;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interface
{
    public interface IMovies
    {
        Task Inserir(Movie m);
        Task<List<Movie>> List();
        Task Delete(Movie m);
        Task<Movie> GetGenreById(int Id);
        Task Update(Movie m);
    }
}
