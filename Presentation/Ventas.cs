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

        Ventas_DAL ventas = new Ventas_DAL();

        private void Ventas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'farmaciaDataSet.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.farmaciaDataSet.Productos);
            cmbCliente.DataSource = cl.CargarCombo();
            cmbCliente.DisplayMember = "Telefono";
            cmbCliente.ValueMember = "Id";

            btnAgregarProductos.Enabled = false;
            btnCalcularTotal.Enabled = false;
            btnConfirmarVenta.Enabled = false;
            dateTimePicker1.Enabled = false;
            btnConsultarTotal.Enabled = false;

        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            txtCliente.Text=cmbCliente.Text;
            
            dateTimePicker1.Enabled = true;
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

                txtCantidadVender.Enabled = true;
                
            }
        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            try
            {
                double total = Convert.ToDouble(txtPrecioUnitario.Text) * Convert.ToDouble(txtCantidadVender.Text);
                lblTotal.Text = Convert.ToString(total);


                btnAgregarProductos.Enabled = true;
    
            }
            catch 
            {

                MessageBox.Show("Ingrese una cantidad");
            }
           
        }

        private void txtCantidadVender_Click(object sender, EventArgs e)
        {
            btnCalcularTotal.Enabled = true;
        }

      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnConsultarTotal_Click(object sender, EventArgs e)
        {

            decimal Total = 0;


            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                    Total += Convert.ToDecimal(row.Cells["Column9"].Value);

                
                label13.Text = Total.ToString();
            }

            btnConfirmarVenta.Enabled = true;
            btnConsultarTotal.Enabled = false;
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    ventas.Insertar(Convert.ToString(row.Cells["Column1"].Value), Convert.ToString(row.Cells["Column2"].Value), Convert.ToString(row.Cells["Column3"].Value), Convert.ToString(row.Cells["Column4"].Value), Convert.ToString(row.Cells["Column5"].Value), Convert.ToString(row.Cells["Column6"].Value), Convert.ToDouble(row.Cells["Column7"].Value), Convert.ToInt32(row.Cells["Column8"].Value), Convert.ToDouble(row.Cells["Column9"].Value));

                }
                MessageBox.Show("Se ha registrado la venta");

                this.productosTableAdapter.Fill(this.farmaciaDataSet.Productos);

                dataGridView2.Rows.Clear();

                btnConfirmarVenta.Enabled = false;
            }

        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double cantidadVenta = Convert.ToDouble(txtCantidadVender.Text);

            double resta = cantidad - cantidadVenta;

            if (cantidadVenta > 0)
            {
                if (resta >= 0)
                {
                    dataGridView2.Rows.Add(dateTimePicker1.Value.ToString("yyyy-MM-dd"), cmbCliente.Text, txtCodProducto.Text, txtProducto.Text, txtDescripcion.Text, txtMarca.Text, txtPrecioUnitario.Text, txtCantidadVender.Text, lblTotal.Text);
                    prod.ActualizarProd(Convert.ToString(resta), txtCodProducto.Text);
                    this.productosTableAdapter.Fill(this.farmaciaDataSet.Productos);


                    MessageBox.Show("Se ha agregado un producto");


                    txtCantidad.Clear();
                    txtCantidadVender.Clear();

                    btnAgregarProductos.Enabled = false;
                    btnCalcularTotal.Enabled = false;
                    txtCantidadVender.Enabled = false;
             
                    btnConsultarTotal.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No hay suficiente stock");
                    btnConfirmarVenta.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No hay suficiente stock");
                btnCalcularTotal.Enabled = false;
                btnAgregarProductos.Enabled = false;

            }
        }
    }
}
