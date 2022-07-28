using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class Clientes_DAL
    {
        private ConnetionToSQL conexion = new ConnetionToSQL();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.Conectar();
            comando.CommandText = "MostrarClientes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.Desconectar();
            return tabla;

        }
        public void Insertar(string nombre, string apellido, string telefono, string email)
        {
            comando.Connection = conexion.Conectar();
            comando.CommandText = "InsetarClientes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@email", email);
       
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.Desconectar();
        }
        public void Editar(string nombre, string apellido, string telefono, string email, int id)
        {
            comando.Connection = conexion.Conectar();
            comando.CommandText = "EditarClientes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@email", email);
      
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.Desconectar();
        }
        public void Eliminar(int id)
        {
            comando.Connection = conexion.Conectar();
            comando.CommandText = "EliminarClientes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idClientes", id); 
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.Desconectar();
        }

        public DataTable CargarCombo()
        {
            SqlDataAdapter da = new SqlDataAdapter("CargarCombobox", conexion.Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
