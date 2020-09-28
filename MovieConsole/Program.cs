using Dominio;
using Entidades.Model;
using Entidades.ViewModel;
using Microsoft.EntityFrameworkCore;

using Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieConsole
{
    class Program
    {

        static async Task Main(String[] args)
        {
                FachadaDominio fachada = new FachadaDominio();

                var relat = await fachada.getRelatorioGeneros();

                Console.WriteLine("Relatorio - generos");

                foreach (GenreSummary gen in relat.OrderByDescending(g => g.Faturamento))
                {
                    Console.WriteLine("\nGenero: {0}", gen.Categoria);
                    Console.WriteLine("\tFaturamento total: {0:C}\n\tAvaliação média: {1,6:N2}\n\tNumero de filmes: {2,2}",
                                    gen.Faturamento, gen.Avaliacao, gen.Quantidade);
                }

                var movies = await fachada.ListMovies();

                Console.WriteLine("Relatorio - filmes");
                List<Movie> filmes = movies;
                foreach(Movie filme in filmes)
                {
                    Console.WriteLine("\t{0}", filme.Title);
                }

                //testes com LINQ de Actors e ActorMovies
                MovieContext db = new MovieContext();
                Console.WriteLine();
                Console.WriteLine("Entrega Exercício LINQ - 28/09");

                //Questao 1
                Console.WriteLine();
                Console.WriteLine("Listar o elenco do um determinado filme (Jurassic Park): ");

                var actorsJurassic = db.ActorMovies.Where(m => m.Movies.Title == "Jurassic Park").Select(m => m.Actors);
                
                foreach (Actor actor in actorsJurassic)
                {
                    Console.WriteLine("\t{0}", actor.Name);
                }

                //Questao 2
                Console.WriteLine();
                Console.WriteLine("Listar todos os atores que já desempenharam o personagem “James Bond”?) ");

                //var actorsJamesBond = db.ActorMovies.Where(a => a.Character == "James Bond").Select(a => a.Actors);
                var actorsJamesBond = db.ActorMovies
                    .Where(a => a.Character == "James Bond")
                    .Select(a => new {
                        Name = a.Actors.Name,
                        Filme = a.Movies.Title
                    });

                foreach (var actor in actorsJamesBond)
                {
                    Console.WriteLine("\t{0} em {1}.", actor.Name, actor.Filme);
                }

                //Questao 3
                Console.WriteLine();
                Console.WriteLine("Informar qual o ator desempenhou mais vezes o personagem “James Bond”?) ");

                var realJameBond = from c in db.ActorMovies
                                   where c.Character == "James Bond"
                                   group c by c.Actors.Name into grpCharacter
                                   orderby grpCharacter.Count() descending
                     select new
                     {
                         Ator = grpCharacter.Key,
                         Quantidade = grpCharacter.Count()
                     }
                     ;
                foreach (var actor in realJameBond)
                {
                    Console.WriteLine("\t{0} em {1} oportunidades.", actor.Ator, actor.Quantidade);
                }







        }

    }
}
