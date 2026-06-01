
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace VideoTech
{
    class Program
    {
        static void Main(string[] args)
        {
            //crear una lista de peliculas con Add()
            List<Pelicula> peliculas = new List<Pelicula>();
            peliculas.Add(new Pelicula("El Padrino", "Francis Ford Coppola", 1972));
            peliculas.Add(new Pelicula("El Padrino II", "Francis Ford Coppola", 1974));
            peliculas.Add(new Pelicula("El Padrino III", "Francis Ford Coppola", 1990));

            // Muestra por consola todas las películas con un foreach y ToString()
            foreach (Pelicula p in peliculas)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();

            //  Recorre la lista y muestra solo las películas cuyo director contenga el texto "Nolan". Usa Contains() de String
            Console.WriteLine("Películas con director que contiene 'Nolan':");
            foreach (Pelicula p in peliculas)
            {
                if (p.Director.Contains("Nolan"))
                {
                    Console.WriteLine(p.ToString());
                }
            }

            //Muestra por consola la fecha actual en formato corto. Usa DateTime.Now y ToShortDateString().
            Console.WriteLine();
            Console.WriteLine(DateTime.Now.ToShortDateString());

            //Crear método GuardarPeliculas(List<Pelicula> lista, string ruta) que guarde todas las películas en un fichero de texto, con cada película en una línea y los campos separados por;.
           public void GuardarPeliculas(List<Pelicula> lista, string ruta)
            {
                using (StreamWriter sw = new StreamWriter(ruta))
                {
                    foreach (Pelicula p in lista)
                    {
                        sw.WriteLine($"{p.Titulo};{p.Director};{p.Anyo};{p.Disponible}");
                    }
                }
                







            }
        
    }
}
