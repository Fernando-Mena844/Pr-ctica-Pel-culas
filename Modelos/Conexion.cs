using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Reflection.Emit;

namespace Modelos
{
    internal class Conexion
    {
        private static string servidor = "Fernando_Mena\\SQLEXPRESS";
        private static string baseDeDatos = "Peliculas_DB";

        public static SqlConnection Conectar()
        {
            string cadena =
                $"Data Source={servidor};" +
                $" Initial Catalog={baseDeDatos};" +
                $" Integrated Security=true;";

            SqlConnection con = new SqlConnection(cadena);
            con.Open();
            return con;
        }
    }
}
