using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAcces;
using Domain;

namespace Presentation
{
    public partial class Ventas : Form
    {
     

        public Ventas()
        {
            InitializeComponent();
        }

        Clientes_DAL cl = new Clientes_DAL();

        Productos_BLL prod = new Productos_BLL();

        private void Ventas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'farmaciaDataSet.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.farmaciaDataSet.Productos);
            cmbCliente.DataSource = cl.CargarCombo();
            cmbCliente.DisplayMember = "Telefono";
            cmbCliente.ValueMember = "Id";

        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            txtCliente.Text=cmbCliente.Text;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtCodProducto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                txtProducto.Text = dataGridView1.SelectedCells[1].Value.ToString();
                txtDescripcion.Text = dataGridView1.SelectedCells[2].Value.ToString();
                txtMarca.Text = dataGridView1.SelectedCells[3].Value.ToString();
                txtPrecioUnitario.Text = dataGridView1.SelectedCells[4].Value.ToString();
                txtCantidad.Text = dataGridView1.SelectedCells[5].Value.ToString();
               

                
            }
        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            double total =Convert.ToDouble( txtPrecioUnitario.Text) * Convert.ToDouble (txtCantidad.Text);
            lblTotal.Text = Convert.ToString(total);

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double cantidadVenta = Convert.ToDouble(txtCantidadVender.Text);

            double resta = cantidad - cantidadVenta;

            if (resta > 0) 
            { 
              prod.ActualizarProd(Convert.ToString(resta), txtCodProducto.Text);
            }
            else
            {
                MessageBox.Show("No hay suficiente stock");
            }
        }
    }
}
