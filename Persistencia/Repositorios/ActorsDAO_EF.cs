using Entidades.Interface;
using Entidades.Model;
using Entidades.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Repositorios
{
    //public class ActorsDAO_EF : IActors, IDisposable
    public class ActorsDAO_EF : IDisposable

    {
        private MovieContext _context;

        public ActorsDAO_EF()
        {
            _context = new MovieContext();

        }
        public async Task Inserir(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

        }
        public async Task<List<Actor>> List()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task Delete(Actor actor)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

        }

        public async Task<Actor> GetActorById(int Id)
        {
            return await _context.Actors.FindAsync(Id);

        }

        public async Task Update(Actor actor)
        {
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();

        }

        /*
        public async Task<ICollection<Actorsummary>> getActorsummary()
        {
            var query = from f in _context.Movies
                        group f by f.Genre.Name into grpGen
                        select new Actorsummary
                        {
                            Categoria = grpGen.Key,
                            Faturamento = grpGen.Sum(e => e.Gross),
                            Avaliacao = grpGen.Average(e => e.Rating),
                            Quantidade = grpGen.Count()
                        };

            return await query.ToListAsync();

        }
        */


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }


        #endregion
    }
}
