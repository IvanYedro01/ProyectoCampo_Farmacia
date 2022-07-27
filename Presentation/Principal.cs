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
            if (MessageBox.Show("Are you sure to log out? ", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
                SessionManager.Logout();
                SessionManager _session = SessionManager.GetInstance;
            {

            }
        }


        
        private void btnBitacora_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Bitacora());

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
        private void btnRegistrar_Usuario_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Gestionar_Usuarios());
        }


        private void btnStock_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Stock());
        }

        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Gestionar_Clientes());
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
    }
}
