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
    public partial class Stock : Form
    {
        Productos_BLL objetoCN = new Productos_BLL();

        private string idProducto = null;

        private bool Editar = false;

        public Stock()
        {
            InitializeComponent();
        }

        private void MostrarProdctos()
        {
            Productos_BLL objeto = new Productos_BLL();
            dataGridView1.DataSource = objeto.MostrarProd();
        }
     
        
        private void limpiarForm()
        {
            if (btnEliminar.Text=="Delete")
            {
                txtDescripcion.Text = "Description";
                txtMarca.Text = "Mark";
                txtPrecio.Text = "Price";
                txtStock.Text = "Stock";
                txtNombre.Text = "Name";
            }

            if (btnEliminar.Text=="Eliminar")
            {
                txtDescripcion.Text = "Descricpcion";
                txtMarca.Text = "Marca";
                txtPrecio.Text = "Precio";
                txtStock.Text = "Stock";
                txtNombre.Text = "Nombre";
            }
           
        }
      

        private void Stock_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'farmaciaDataSet2.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.farmaciaDataSet2.Productos);
            MostrarProdctos();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                try
                {
                    if (btnEditar.Text == "Editar")
                    {
                        if (String.IsNullOrEmpty(txtNombre.Text))
                        {
                            MessageBox.Show("Complete el nombre");
                        }

                        if (String.IsNullOrEmpty(txtDescripcion.Text))
                        {
                            MessageBox.Show("Complete la descripcion");
                        }

                        if (String.IsNullOrEmpty(txtMarca.Text))
                        {
                            MessageBox.Show("Complete la marca");
                        }

                        if (String.IsNullOrEmpty(txtPrecio.Text))
                        {
                            MessageBox.Show("Complete el precio");
                        }

                        if (String.IsNullOrEmpty(txtStock.Text))
                        {
                            MessageBox.Show("Complete el stock");
                        }
                        else
                        {
                            objetoCN.InsertarPRod(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                            MessageBox.Show("Se inserto correctamente");
                            MostrarProdctos();
                            limpiarForm();
                        }
                    }
                    if (btnEditar.Text == "Edit")
                    {

                        if (String.IsNullOrEmpty(txtNombre.Text))
                        {
                            MessageBox.Show("Complete the name");
                        }

                        if (String.IsNullOrEmpty(txtDescripcion.Text))
                        {
                            MessageBox.Show("Complete the description");
                        }

                        if (String.IsNullOrEmpty(txtMarca.Text))
                        {
                            MessageBox.Show("Complete the mark");
                        }

                        if (String.IsNullOrEmpty(txtPrecio.Text))
                        {
                            MessageBox.Show("Complete the price");
                        }

                        if (String.IsNullOrEmpty(txtStock.Text))
                        {
                            MessageBox.Show("Complete the stock");
                        }
                        else
                        {

                            objetoCN.InsertarPRod(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                            MessageBox.Show("Insert correctly");
                            MostrarProdctos();      
                        }
                   
                     
                     
                    }
                    
                }
                catch (Exception ex)
                {
                    if (btnGuardar.Text=="Guardar")
                    {
                        MessageBox.Show("No se pudo insertar los datos por: " + ex);
                    }
                    if (btnGuardar.Text=="Save")
                    {
                        MessageBox.Show("Data could not be inserted because: " + ex);
                    }
                   
                }
            }
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    if (btnEditar.Text == "Editar")
                    {
                        if (String.IsNullOrEmpty(txtNombre.Text))
                        {
                            MessageBox.Show("Complete el nombre");
                        }

                        if (String.IsNullOrEmpty(txtDescripcion.Text))
                        {
                            MessageBox.Show("Complete la descripcion");
                        }

                        if (String.IsNullOrEmpty(txtMarca.Text))
                        {
                            MessageBox.Show("Complete la marca");
                        }

                        if (String.IsNullOrEmpty(txtPrecio.Text))
                        {
                            MessageBox.Show("Complete el precio");
                        }

                        if (String.IsNullOrEmpty(txtStock.Text))
                        {
                            MessageBox.Show("Complete el stock");
                        }
                        else
                        {

                           objetoCN.EditarProd(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                           MessageBox.Show("Se edito correctamente");
                           MostrarProdctos();
                           limpiarForm();
                           Editar = false;
                            
                        }
                    }
                    if (btnEditar.Text == "Edit")
                    {

                        if (String.IsNullOrEmpty(txtNombre.Text))
                        {
                            MessageBox.Show("Complete the name");
                        }

                        if (String.IsNullOrEmpty(txtDescripcion.Text))
                        {
                            MessageBox.Show("Complete the description");
                        }

                        if (String.IsNullOrEmpty(txtMarca.Text))
                        {
                            MessageBox.Show("Complete the mark");
                        }

                        if (String.IsNullOrEmpty(txtPrecio.Text))
                        {
                            MessageBox.Show("Complete the price");
                        }

                        if (String.IsNullOrEmpty(txtStock.Text))
                        {
                            MessageBox.Show("Complete the stock");
                        }
                        else
                        {
                            objetoCN.EditarProd(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                            MessageBox.Show("Edit correctly");
                            MostrarProdctos();
                            limpiarForm();
                            Editar = false;
                        }
                    }   
                }

                catch (Exception ex)
                {
                    if (btnEditar.Text=="Edit")
                    {
                        MessageBox.Show("Data could not be edit because: " + ex);
                    }

                    if (btnEditar.Text=="Editar")
                    {
                        MessageBox.Show("No se pudo editar los datos por: " + ex);
                    }
                   
                }
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stockk"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                if (btnEditar.Text == "Editar")
                {
                    MessageBox.Show("Seleccione una fila por favor");
                }
                if (btnEditar.Text == "Edit")
                {
                    MessageBox.Show("Select a row please");
                }
            }
             
               
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (btnEliminar.Text=="Eliminar")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    objetoCN.EliminarPRod(idProducto);
                    MessageBox.Show("Eliminado correctamente");
                    MostrarProdctos();
                }
                else
                    MessageBox.Show("Seleccione una fila por favor");
            }

            if (btnEliminar.Text=="Delete")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    objetoCN.EliminarPRod(idProducto);
                    MessageBox.Show("Delete correctly");
                    MostrarProdctos();
                }
                else
                    MessageBox.Show("Select a row please");
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
    }
}
