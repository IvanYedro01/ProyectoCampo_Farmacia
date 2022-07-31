using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace Presentation
{
    public partial class Gestionar_Clientes : Form
    {
        Clientes_BLL objetoCN = new Clientes_BLL();

        private string idCliente = null;

        private bool Editar = false;

        public Gestionar_Clientes()
        {
            InitializeComponent();
        }

        private void MostrarClientes()
        {
            Clientes_BLL objeto = new Clientes_BLL();
            dataGridView1.DataSource = objeto.MostrarClientes();
        }


        private void limpiarForm()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                try
                {
                    if (btnGuardar.Text=="Guardar")
                    {
                        if (String.IsNullOrEmpty(txtNombre.Text))
                        {
                            MessageBox.Show("Complete el nombre");
                        }

                        if (String.IsNullOrEmpty(txtApellido.Text))
                        {
                            MessageBox.Show("Complete el apellido");
                        }

                        if (String.IsNullOrEmpty(txtTelefono.Text))
                        {
                            MessageBox.Show("Complete el telefono");
                        }

                        if (String.IsNullOrEmpty(txtEmail.Text))
                        {
                            MessageBox.Show("Complete el email");
                        }
                        else
                        {
                            objetoCN.InsertarClientes(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text);
                            MessageBox.Show("Se inserto correctamente");
                            MostrarClientes();
                            limpiarForm();
                        }
                    }
                    if (btnGuardar.Text == "Save")
                    {
                        if (String.IsNullOrEmpty(txtNombre.Text))
                        {
                            MessageBox.Show("Complete the name");
                        }

                        if (String.IsNullOrEmpty(txtApellido.Text))
                        {
                            MessageBox.Show("Complete the lastname");
                        }

                        if (String.IsNullOrEmpty(txtTelefono.Text))
                        {
                            MessageBox.Show("Complete the phone");
                        }

                        if (String.IsNullOrEmpty(txtEmail.Text))
                        {
                            MessageBox.Show("Complete the email");
                        }
                        else
                        {
                            objetoCN.InsertarClientes(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text);
                            MessageBox.Show("Insert correctly");
                            MostrarClientes();
                            limpiarForm();
                        }
                    }
      
                   
                }
                catch (Exception)
                {
                    if (btnGuardar.Text=="Guardar")
                    {
                        MessageBox.Show("Por favor ingrese bien los datos ");
                    }
                    else
                    {
                        MessageBox.Show("Enter the data correctly please");
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

                        if (String.IsNullOrEmpty(txtApellido.Text))
                        {
                            MessageBox.Show("Complete el apellido");
                        }

                        if (String.IsNullOrEmpty(txtTelefono.Text))
                        {
                            MessageBox.Show("Complete el telefono");
                        }

                        if (String.IsNullOrEmpty(txtEmail.Text))
                        {
                            MessageBox.Show("Complete el email");
                        }
                        else
                        {
                            objetoCN.EditarCLientes(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text, idCliente);
                            MessageBox.Show("Se edito correctamente");
                            MostrarClientes();
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

                        if (String.IsNullOrEmpty(txtApellido.Text))
                        {
                            MessageBox.Show("Complete the lastname");
                        }

                        if (String.IsNullOrEmpty(txtTelefono.Text))
                        {
                            MessageBox.Show("Complete the phone");
                        }

                        if (String.IsNullOrEmpty(txtEmail.Text))
                        {
                            MessageBox.Show("Complete the email");
                        }
                        else
                        {
                            objetoCN.EditarCLientes(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text, idCliente);
                            MessageBox.Show("Edit correctly");
                            MostrarClientes();
                            limpiarForm();
                            Editar = false;
                        }
                    }

                  
                   
                }
                catch (Exception ex)
                {
                    if (btnEditar.Text=="Editar")
                    {
                        MessageBox.Show("No se pudo editar los datos por: " + ex);
                    }
                    else
                    {
                        MessageBox.Show("Could not be edit the data because: " + ex);
                    }
                   
                }
            }
        }

        private void Gestionar_Clientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'farmaciaDataSet3.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.farmaciaDataSet3.Clientes);
            MostrarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
               
                idCliente = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                if (btnEditar.Text=="Editar")
                {
                    MessageBox.Show("Seleccione una fila por favor");
                }
                else
                {
                    MessageBox.Show("Select a row please");
                }
            }
               
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (btnEliminar.Text=="Eliminar")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idCliente = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    objetoCN.EliminarClientes(idCliente);
                    MessageBox.Show("Eliminado correctamente");
                    MostrarClientes();

                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtTelefono.Text = "";
                    txtEmail.Text = "";
                }
                else
                    MessageBox.Show("seleccione una fila por favor");
            }

            if (btnEliminar.Text == "Delete")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idCliente = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    objetoCN.EliminarClientes(idCliente);
                    MessageBox.Show("Delete correctly");
                    MostrarClientes();

                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtTelefono.Text = "";
                    txtEmail.Text = "";
                }
                else
                    MessageBox.Show("Select a row please");
            }


        }
    }
}
