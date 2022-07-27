using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAcces
{
    public class ConnetionToSQL
    {

        private SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-K8OML1K\\SQLEXPRESS;Initial Catalog=farmacia;Integrated Security=True");

        public static string CN= ("Data Source=DESKTOP-K8OML1K\\SQLEXPRESS;Initial Catalog=DBPRUEBAS;Integrated Security=True");


        public SqlConnection Conectar()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public SqlConnection Desconectar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }
    }
}
