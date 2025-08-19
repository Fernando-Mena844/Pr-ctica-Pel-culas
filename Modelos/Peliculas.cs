using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Peliculas
    {
        private int id;
        private string nombre;
        private string director;
        private DateTime fechaLanzamiento;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Director { get => director; set => director = value; }
        public DateTime FechaLanzamiento { get => fechaLanzamiento; set => fechaLanzamiento = value; }

        public static DataTable CargarPeliculas()
        {
            SqlConnection con = Conexion.Conectar();
            StringBuilder queryRead = new StringBuilder();
            queryRead.Append("select id_pelicula  as [Número de registro], ");
            queryRead.Append("nombre as Película, ");
            queryRead.Append("director as Director, ");
            queryRead.Append("fechaLanzamiento as [Fecha de lanzamiento] ");
            queryRead.Append("from peliculas");
            SqlDataAdapter ad = new SqlDataAdapter(queryRead.ToString(), con);

            DataTable dt = new DataTable();

            ad.Fill(dt);

            return dt;
        }

        public bool InsertarPeliculas()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string comando = " Insert into peliculas(nombre,director,fechaLanzamiento) values(@nombre, @director, @fechaLanzamiento);";
                SqlCommand cmd = new SqlCommand(comando, con);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@director", director);
                cmd.Parameters.AddWithValue("@fechaLanzamiento", fechaLanzamiento);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool ActualizarPeliculas()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "UPDATE peliculas set nombre=@nombre, director=@director, fechalanzamiento=@fecha where id_pelicula=@id";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@nombre",nombre);
            cmd.Parameters.AddWithValue("@director", director);
            cmd.Parameters.AddWithValue("@fecha", fechaLanzamiento);
            cmd.Parameters.AddWithValue("@id", id);

            if (cmd.ExecuteNonQuery()>0)
            {

                return true;
            }
            else
            {
                return false;
            }

        }
        public bool EliminarPelicula(int id)
        {
            try
            {
                SqlConnection conexion = Conexion.Conectar();
                string comando = "DELETE FROM peliculas WHERE id_pelicula=@id";
                SqlCommand cmd = new SqlCommand(comando, conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static DataTable BuscarPeliculas(string busqueda)
        {
            SqlConnection con = Conexion.Conectar();
            StringBuilder queryRead = new StringBuilder();
            queryRead.Append("select id_pelicula  as [Número de registro], ");
            queryRead.Append("nombre as Película, ");
            queryRead.Append("director as Director, ");
            queryRead.Append("fechaLanzamiento as [Fecha de lanzamiento] ");
            queryRead.Append("from peliculas where nombre like @busqueda or director like @busqueda");
            SqlDataAdapter ad = new SqlDataAdapter(queryRead.ToString(), con);
            ad.SelectCommand.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}
