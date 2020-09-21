using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades.Model;
using Entidades.ViewModel;

namespace Dominio
{
    public interface IGenreDAO_EF
    {
        public  Task Inserir(Genre genre);
        public  Task<List<Genre>> List();
        public  Task Delete(Genre genre);
        public  Task<Genre> GetGenreById(int Id);
        public  Task Update(Genre genre);
        public  Task<ICollection<GenreSummary>> getGenreSummary();
    }
}
