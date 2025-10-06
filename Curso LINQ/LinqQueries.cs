using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_LINQ

{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public LinqQueries()
        { 
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});

            }
        }
        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }


        public IEnumerable<Book> LibrosDespuesDel2000()
        {
            // extension method 
            // return librosCollection.Where(p => p.PublishedDate.Year > 2000);


            //query expresion  
            return from l in librosCollection where l.PublishedDate.Year > 2000 select l;

        }

        public IEnumerable<Book> LibrosMas250PaginasConPalabrasInAction()
        {
            //Extension method 
            //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

            //query expresion 
            return from l in librosCollection where l.PageCount > 250 && l.Title.Contains(" in Action") select l;
            
        

        }

        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection.All(p => p.Status != string.Empty);
        }

        public bool AlgunLibroPublicadoEn2005()
        {
            return librosCollection.Any(p => p.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book>CategoriaPython ()
        {

            return librosCollection.Where(p => p.Categories.Contains("Python"));

        }


        public IEnumerable<Book> LibrosdeJavaPorNombreAscendente()
        {
            return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
        }

        public IEnumerable<Book> LibrosConMasDe450PaginasEnOrdenDescendente()
        {
            return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
        }

        public IEnumerable<Book> Libros3RecientesJava()
        {
            return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);

        }


        public IEnumerable<Book> LibrosConMasDe400Paginas()
        {

            return librosCollection.Where(p => p.PageCount > 400).Skip(2).Take(2);
        }

        public IEnumerable<Book> TresPrimerosLibrosDeLaColeccion()
        {
            return librosCollection.Take(3).Select(p => new Book {Title =p.Title, PageCount = p.PageCount});
        }


    }
}