using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bitacora_BLL
    {
        private Bitacora_BLL bitacora = new Bitacora_BLL();

        public DataTable MostrarHistorial()
        {
            DataTable tabla = new DataTable();
            tabla = bitacora.MostrarHistorial();
            return tabla;
        }
    }
}
