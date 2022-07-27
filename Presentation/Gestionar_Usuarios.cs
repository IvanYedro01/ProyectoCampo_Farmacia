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
    public partial class Gestionar_Usuarios : Form
    {
        Usuario_BLL objectDOM=new Usuario_BLL();

        public Gestionar_Usuarios()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click_1(object sender, EventArgs e)
        {
            try
            {
                objectDOM.InsertUser(txtloginName.Text, txtpassword.Text, txtfirstName.Text, txtlastName.Text, cmbposition.Text, txtemail.Text);
                MessageBox.Show("Insert correctly");

            }
            catch (Exception ex)
            {
                MessageBox.Show("data could not be inserted: " + ex);
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
