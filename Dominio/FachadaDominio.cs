using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Interface;
using Entidades.ViewModel;
using Persistencia.Repositorios;

namespace Dominio
{
    public class FachadaDominio
    {
        IGenres genreDB = new GenresDAO_EF();
        IMovies moviesDB = new MoviesDAO_EF();

        public async Task<ICollection<GenreSummary>> getRelatorioGeneros()
        {
            return await genreDB.getGenreSummary();
        }


    }
}
