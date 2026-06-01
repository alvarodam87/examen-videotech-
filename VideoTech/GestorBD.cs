using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VideoTech
{
    internal class GestorBD
    {
        // Campo de clase para que sea accesible en todos los métodos
        private MySqlConnectionStringBuilder builder;

        public GestorBD()
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "videotech";
        }

        public void Insertar(Pelicula p)
        {
            // Usamos builder.ConnectionString directamente
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO peliculas (titulo, director, anyo, disponible) VALUES (@titulo, @director, @anyo, @disponible)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@titulo", p.Titulo);
                    command.Parameters.AddWithValue("@director", p.Director);
                    command.Parameters.AddWithValue("@anyo", p.Anyo);
                    command.Parameters.AddWithValue("@disponible", p.Disponible);
                    command.ExecuteNonQuery();
                }
            } // Aquí se cierra el 'using' y la conexión (el paréntesis que te faltaba estaba aquí)
        }

        public List<Pelicula> ObtenerTodos()
        {
            List<Pelicula> peliculas = new List<Pelicula>();
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM peliculas";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Asegúrate de que los nombres de las columnas coincidan con tu tabla
                            string titulo = reader.GetString("titulo");
                            string director = reader.GetString("director");
                            int anyo = reader.GetInt32("anyo");
                            bool disponible = reader.GetBoolean("disponible");

                            Pelicula p = new Pelicula(titulo, director, anyo);
                            p.Disponible = disponible;
                            peliculas.Add(p);
                        }
                    }
                }
            }
            return peliculas;
        }
    }
}
