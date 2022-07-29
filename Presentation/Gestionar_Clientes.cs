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
            txtNombre.Text = "Nombre";
            txtApellido.Text = "Apellido";
            txtTelefono.Text = "Telefono";
            txtEmail.Text = "Email";
           
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
                    objetoCN.InsertarClientes(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text);
                    MessageBox.Show("se inserto correctamente");
                    MostrarClientes();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarCLientes(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text, idCliente);
                    MessageBox.Show("se edito correctamente");
                    MostrarClientes();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
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
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idCliente = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarClientes(idCliente);
                MessageBox.Show("Eliminado correctamente");
                MostrarClientes();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}
