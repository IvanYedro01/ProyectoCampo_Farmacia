using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace DataAcces
{
    public class Bitacora_DAL
    {
        ConnetionToSQL con = new ConnetionToSQL();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = con.Conectar();
            comando.CommandText = "consultar_bitacora";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.Desconectar();
            return tabla;
        }
    }
}
