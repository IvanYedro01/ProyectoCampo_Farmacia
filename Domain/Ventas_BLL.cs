using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;

namespace Domain
{
    public class Ventas_BLL
    {
        Ventas_DAL objetoCD = new Ventas_DAL();

        public void InsertarVenta(string fecha, string dni_cliente, string cod_producto, string producto, string descripcion, string marca, double precio_unitario, int cantidad_venta, double total)
        {
            objetoCD.Insertar(fecha, dni_cliente, cod_producto, producto, descripcion, marca, precio_unitario, cantidad_venta, total);
        }
    }
}
