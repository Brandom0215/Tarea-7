using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_LINQ

{
    internal class Program
    {
        static void Main(string[] args)
        {

            LinqQueries queries = new LinqQueries();

            //Todas las colecciones 
            //ImprimirValores(queries.TodaLaColeccion());

            //Libros despues del 2000 
            //ImprimirValores(queries.LibrosDespuesDel2000 ());

           // ImprimirValores(queries.LibrosMas250PaginasConPalabrasInAction());

            //Console.WriteLine($" Todos los libros tiene status?{queries.TodosLosLibrosTienenStatus()} ");

     
            //Console.WriteLine($"¡Agun libro fue publicado en 2005 ? {queries.AlgunLibroPublicadoEn2005()}");

            //ImprimirValores(queries.CategoriaPython());


            //ImprimirValores(queries.LibrosdeJavaPorNombreAscendente());

            //ImprimirValores(queries.LibrosConMasDe450PaginasEnOrdenDescendente());

      
            //ImprimirValores(queries.Libros3RecientesJava());

         
            //ImprimirValores(queries.LibrosConMasDe400Paginas());

     
            ImprimirValores(queries.TresPrimerosLibrosDeLaColeccion());


            void ImprimirValores(IEnumerable<Book> listadelibros)
            {
                Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N.paginas", "Fecha publicacion");
                foreach(var item in listadelibros)
                {
                    Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
                }

            }

        }

    }
}