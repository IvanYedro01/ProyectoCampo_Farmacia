using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class Ventas_DAL
    {

        private ConnetionToSQL conexion = new ConnetionToSQL();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void Insertar(string fecha ,string dni_cliente, string cod_producto, string producto, string descripcion, string marca, double precio_unitario, int cantidad_venta, double total)
        {
            comando.Connection = conexion.Conectar();
            comando.CommandText = "InsetarVentas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@dni_cliente", dni_cliente);
            comando.Parameters.AddWithValue("@cod_producto", cod_producto);
            comando.Parameters.AddWithValue("@producto", producto);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio_unitario", precio_unitario);
            comando.Parameters.AddWithValue("@cantidad_venta", cantidad_venta);
            comando.Parameters.AddWithValue("@total", total);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.Desconectar();
        }

      
       
    }
}
