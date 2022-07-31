using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Cache;
using System.Runtime.InteropServices;
using Domain.Singleton;
using Domain;

namespace Presentation
{
    public partial class Principal : Form
    {
        Gestionar_Clientes g = new Gestionar_Clientes();

        Gestionar_Usuarios gu = new Gestionar_Usuarios();

        Stock s = new Stock();

        Ventas v = new Ventas();

        Bitacora b = new Bitacora();

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            LoadUserData();
            ManagePermission();
            
        }

        private void ManagePermission()
        {
            if (UserLoginCache.position==Positions.Vendedor)
            {
                btnGestionar_Usuarios.Enabled = false;
                btnBitacora.Enabled = false;
                
            }


        }

        private void LoadUserData()
        {
            lblName.Text = UserLoginCache.firstName;
            lblPosition.Text = UserLoginCache.position;
            lblEmail.Text = UserLoginCache.email;
      
        }

       
      

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (btnLogout.Text=="Cerrar Sesion")
            {
                if (MessageBox.Show("Esta seguro de cerrar sesion? ", "Advertencia",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();
                SessionManager.Logout();
                SessionManager _session = SessionManager.GetInstance;
               
            }

            if (btnLogout.Text=="Log out")
            {
                if (MessageBox.Show("Are you sure to log out? ", "Warning",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();
                SessionManager.Logout();
                SessionManager _session = SessionManager.GetInstance;
              
            }
           
        }


        
        private void btnBitacora_Click(object sender, EventArgs e)
        {
            if (button1.Text=="Sales")
            {
                b = new Bitacora();
                b.dataGridView1.Columns["codigoDataGridViewTextBoxColumn"].HeaderText = "Code";
                b.dataGridView1.Columns["usuarioDataGridViewTextBoxColumn"].HeaderText = "User";
                b.dataGridView1.Columns["tablaDataGridViewTextBoxColumn"].HeaderText = "Table";
                b.dataGridView1.Columns["accionDataGridViewTextBoxColumn"].HeaderText = "Action";
                b.dataGridView1.Columns["registroDataGridViewTextBoxColumn"].HeaderText = "Register";
                b.dataGridView1.Columns["nombreDataGridViewTextBoxColumn"].HeaderText = "Name";
                b.dataGridView1.Columns["descripcionDataGridViewTextBoxColumn"].HeaderText = "Description";
                b.dataGridView1.Columns["fechahoraDataGridViewTextBoxColumn"].HeaderText = "Date Hour";

                AbrirFormInPanel(b);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;
            }

            if (button1.Text=="Ventas")
            {
                b = new Bitacora();
                b.dataGridView1.Columns["codigoDataGridViewTextBoxColumn"].HeaderText = "Codigo";
                b.dataGridView1.Columns["usuarioDataGridViewTextBoxColumn"].HeaderText = "Usuario";
                b.dataGridView1.Columns["tablaDataGridViewTextBoxColumn"].HeaderText = "Tabla";
                b.dataGridView1.Columns["accionDataGridViewTextBoxColumn"].HeaderText = "Accion";
                b.dataGridView1.Columns["registroDataGridViewTextBoxColumn"].HeaderText = "Registro";
                b.dataGridView1.Columns["nombreDataGridViewTextBoxColumn"].HeaderText = "Nombre";
                b.dataGridView1.Columns["descripcionDataGridViewTextBoxColumn"].HeaderText = "Descripcion";
                b.dataGridView1.Columns["fechahoraDataGridViewTextBoxColumn"].HeaderText = "Fecha hora";


                AbrirFormInPanel(b);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;
            }
        

        }

        private void AbrirFormInPanel(object FormHijo)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);
            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Contenedor.Controls.Add(fh);
            this.Contenedor.Tag = fh;
            fh.Show();
            
        }

        public void CargarIdiomaEnglishGestionarUsuarios()
        {
            gu.btnSignIn.Text = Idiomas.English3.btnSignIn;
            gu.label1.Text = Idiomas.English3.label1;
            gu.label2.Text = Idiomas.English3.label2;
            gu.label3.Text = Idiomas.English3.label3;
            gu.label4.Text = Idiomas.English3.label4;
            gu.label5.Text = Idiomas.English3.label5;
        }

        public void CargarIdiomaEspañolGestionarUsuarios()
        {
            gu.btnSignIn.Text = Idiomas.Español3.btnSignIn;
            gu.label1.Text = Idiomas.Español3.label1;
            gu.label2.Text = Idiomas.Español3.label2;
            gu.label3.Text = Idiomas.Español3.label3;
            gu.label4.Text = Idiomas.Español3.label4;
            gu.label5.Text = Idiomas.Español3.label5;
        }

        private void btnRegistrar_Usuario_Click(object sender, EventArgs e)
        {
            if (btnGestionar_Usuarios.Text=="Gestionar Usuarios")
            {
                gu = new Gestionar_Usuarios();
                CargarIdiomaEspañolGestionarUsuarios();
                AbrirFormInPanel(gu);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;

            }

            if (btnGestionar_Usuarios.Text=="Manage users")
            {
                gu = new Gestionar_Usuarios();
                CargarIdiomaEnglishGestionarUsuarios();
                AbrirFormInPanel(gu);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;
            }
         
        }


        public void CargarIdiomaEnglishStock()
        {
            s.btnGuardar.Text = Idiomas.English4.btnGuardar;
            s.btnEditar.Text = Idiomas.English4.btnEditar;
            s.btnEliminar.Text = Idiomas.English4.btnEliminar;
            s.label1.Text = Idiomas.English4.label1;
            s.label2.Text = Idiomas.English4.label2;
            s.label3.Text = Idiomas.English4.label3;
            s.label4.Text = Idiomas.English4.label4;
            s.label5.Text = Idiomas.English4.label5;
            s.dataGridView1.Columns["Nombre"].HeaderText = "Name";
            s.dataGridView1.Columns["Descripcion"].HeaderText = "Description";
            s.dataGridView1.Columns["Marca"].HeaderText = "Mark";
            s.dataGridView1.Columns["Precio"].HeaderText = "Price";


        }

        public void CargarIdiomaEspañolStock()
        {
            s.btnGuardar.Text = Idiomas.Español4.btnGuardar;
            s.btnEditar.Text = Idiomas.Español4.btnEditar;
            s.btnEliminar.Text = Idiomas.Español4.btnEliminar;
            s.label1.Text = Idiomas.Español4.label1;
            s.label2.Text = Idiomas.Español4.label2;
            s.label3.Text = Idiomas.Español4.label3;
            s.label4.Text = Idiomas.Español4.label4;
            s.label5.Text = Idiomas.Español4.label5;
            s.dataGridView1.Columns["Nombre"].HeaderText = "Nombre";
            s.dataGridView1.Columns["Descripcion"].HeaderText = "Descripcion";
            s.dataGridView1.Columns["Marca"].HeaderText = "Marca";
            s.dataGridView1.Columns["Precio"].HeaderText = "Precio";
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (btnGestionarClientes.Text=="Gestionar Clientes")
            {
                s = new Stock();
                CargarIdiomaEspañolStock();
                AbrirFormInPanel(s);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;
            }

            if (btnGestionarClientes.Text=="Manage clients")
            {
                s = new Stock();
                CargarIdiomaEnglishStock();
                AbrirFormInPanel(s);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;
            }
       
        }


        public void CargarIdiomaEnglishGestionarClientes()
        {
            g.btnGuardar.Text = Idiomas.English2.btnGuardar;
            g.btnEditar.Text = Idiomas.English2.btnEditar;
            g.btnEliminar.Text = Idiomas.English2.btnEliminar;
            g.label1.Text = Idiomas.English2.label1;
            g.label2.Text = Idiomas.English2.label2;
            g.labelPhone.Text = Idiomas.English2.labelPhone;
            g.label4.Text = Idiomas.English2.label4;
            g.dataGridView1.Columns["Nombre"].HeaderText = "Name";
            g.dataGridView1.Columns["Apellido"].HeaderText = "Last Name";
            g.dataGridView1.Columns["Telefono"].HeaderText = "Phone";


        }

        public void CargarIdiomaEspañolGestionarClientes()
        {
            g.btnGuardar.Text = Idiomas.Español2.btnGuardar;
            g.btnEditar.Text = Idiomas.Español2.btnEditar;
            g.btnEliminar.Text = Idiomas.Español2.btnEliminar;
            g.label1.Text = Idiomas.Español2.label1;
            g.label2.Text = Idiomas.Español2.label2;
            g.labelPhone.Text = Idiomas.Español2.labelPhone;
            g.label4.Text = Idiomas.Español2.label4;
            g.dataGridView1.Columns["Nombre"].HeaderText = "Nombre";
            g.dataGridView1.Columns["Apellido"].HeaderText = "Apellido";
            g.dataGridView1.Columns["Telefono"].HeaderText = "Telefono";
        }

        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            if (btnGestionarClientes.Text=="Manage clients")
            {
                g = new Gestionar_Clientes();
                CargarIdiomaEnglishGestionarClientes();
                AbrirFormInPanel(g);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;

            }

            if (btnGestionarClientes.Text=="Gestionar Clientes")
            {
                g = new Gestionar_Clientes();
                CargarIdiomaEspañolGestionarClientes();
                AbrirFormInPanel(g);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;
            }
           
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (VerticalMain.Width == 200)
            {
                VerticalMain.Width = 50;
            }

            else
                VerticalMain.Width = 200;
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        public void CargarIdiomaEnglishVentas()
        {
            v.btnSeleccionarCliente.Text = Idiomas.English5.btnSeleccionarCliente;
            v.label1.Text = Idiomas.English5.label1;
            v.label11.Text = Idiomas.English5.label11;
            v.label3.Text = Idiomas.English5.label3;
            v.label4.Text = Idiomas.English5.label4;
            v.label5.Text = Idiomas.English5.label5;
            v.label6.Text = Idiomas.English5.label6;
            v.label7.Text = Idiomas.English5.label7;
            v.label8.Text = Idiomas.English5.label8;
            v.label9.Text = Idiomas.English5.label9;
            v.label10.Text = Idiomas.English5.label10;
            v.btnCalcularTotal.Text = Idiomas.English5.btnCalcularTotal;
            v.btnConsultarTotal.Text = Idiomas.English5.btnConsultarTotal;
            v.btnAgregarProductos.Text = Idiomas.English5.btnAgregarProductos;
            v.btnConfirmarVenta.Text = Idiomas.English5.btnConfirmarVenta;
            v.dataGridView1.Columns["nombreDataGridViewTextBoxColumn"].HeaderText = "Name";
            v.dataGridView1.Columns["marcaDataGridViewTextBoxColumn"].HeaderText = "Mark";
            v.dataGridView1.Columns["descripcionDataGridViewTextBoxColumn"].HeaderText = "Description";
            v.dataGridView1.Columns["precioDataGridViewTextBoxColumn"].HeaderText = "Price";

            v.dataGridView2.Columns["Column1"].HeaderText = "Date";
            v.dataGridView2.Columns["Column2"].HeaderText = "DNI Client";
            v.dataGridView2.Columns["Column4"].HeaderText = "Product";
            v.dataGridView2.Columns["Column5"].HeaderText = "Description";
            v.dataGridView2.Columns["Column6"].HeaderText = "Mark";
            v.dataGridView2.Columns["Column7"].HeaderText = "Price Uni";
            v.dataGridView2.Columns["Column8"].HeaderText = "Amount";
  



        }
        public void CargarIdiomaEspañolVentas()
        {
            v.btnSeleccionarCliente.Text = Idiomas.Español5.btnSeleccionarCliente;
            v.label1.Text = Idiomas.Español5.label1;
            v.label11.Text = Idiomas.Español5.label11;
            v.label3.Text = Idiomas.Español5.label3;
            v.label4.Text = Idiomas.Español5.label4;
            v.label5.Text = Idiomas.Español5.label5;
            v.label6.Text = Idiomas.Español5.label6;
            v.label7.Text = Idiomas.Español5.label7;
            v.label8.Text = Idiomas.Español5.label8;
            v.label9.Text = Idiomas.Español5.label9;
            v.label10.Text = Idiomas.Español5.label10;
            v.btnCalcularTotal.Text = Idiomas.Español5.btnCalcularTotal;
            v.btnConsultarTotal.Text = Idiomas.Español5.btnConsultarTotal;
            v.btnAgregarProductos.Text = Idiomas.Español5.btnAgregarProductos;
            v.btnConfirmarVenta.Text = Idiomas.Español5.btnConfirmarVenta;
            v.dataGridView1.Columns["nombreDataGridViewTextBoxColumn"].HeaderText = "Nombre";
            v.dataGridView1.Columns["marcaDataGridViewTextBoxColumn"].HeaderText = "Marca";
            v.dataGridView1.Columns["descripcionDataGridViewTextBoxColumn"].HeaderText = "Descripcion";
            v.dataGridView1.Columns["precioDataGridViewTextBoxColumn"].HeaderText = "Precio";

            v.dataGridView2.Columns["Column1"].HeaderText = "Fehca";
            v.dataGridView2.Columns["Column2"].HeaderText = "DNI Cliente";
            v.dataGridView2.Columns["Column4"].HeaderText = "Producto";
            v.dataGridView2.Columns["Column5"].HeaderText = "Descripcion";
            v.dataGridView2.Columns["Column6"].HeaderText = "Marca";
            v.dataGridView2.Columns["Column7"].HeaderText = "Precio Uni";
            v.dataGridView2.Columns["Column8"].HeaderText = "Cantidad";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="Ventas")
            {
                v = new Ventas();
                CargarIdiomaEspañolVentas();
                AbrirFormInPanel(v);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;
            }

            if (button1.Text=="Sales")
            {
                v = new Ventas();
                CargarIdiomaEnglishVentas();
                AbrirFormInPanel(v);
                pictureBox10.Hide();
                lblFecha.Visible = false;
                lblHora.Visible = false;
            }
        }
    }
}
