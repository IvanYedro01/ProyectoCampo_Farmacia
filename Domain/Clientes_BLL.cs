using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;

namespace Domain
{
    public class Clientes_BLL
    {
        private Clientes_DAL objetoCD = new Clientes_DAL();

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarClientes(string nombre, string apellido, string telefono, string email)
        {
            objetoCD.Insertar(nombre, apellido, telefono, email);
        }
        public void EditarCLientes(string nombre, string apellido, string telefono, string email, string id)
        {
            objetoCD.Editar(nombre, apellido, telefono, email, Convert.ToInt32(id));
        }
        public void EliminarClientes(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
