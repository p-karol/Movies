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
        }

    }
}
