using System;
using System.Collections.Generic;
using System.Text;

namespace VideoTech
{
    internal class Pelicula
    {
        private string titulo;
        private string director;
        private int anyo;
        private bool disponible;

        //constructor con parametros
        public Pelicula(string titulo, string director, int anyo)
        {
            this.titulo = titulo;
            this.director = director;
            this.anyo = anyo;
            this.disponible = true; // por defecto, la película está disponibles
        }

        //metodos get y set
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Director
        {
            get { return director; }
            set { director = value; }
        }
        public int Anyo
        {
            get { return anyo; }
            set { anyo = value; }
        }

        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }
        //metodo ToString() devuelvva titulo, director y año de la película
        public override string ToString()
        {
            return $"Título: {titulo}, Director: {director}, Año: {anyo}, Disponible: {disponible}";
        }

    }
}
