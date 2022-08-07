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
                if (btnSignIn.Text=="Registrar")
                {
                    if (String.IsNullOrEmpty(txtloginName.Text))
                    {
                        MessageBox.Show("Complete el nombre de inicio");
                    }

                    if (String.IsNullOrEmpty(txtpassword.Text))
                    {
                        MessageBox.Show("Complete la contraseña");
                    }

                    if (String.IsNullOrEmpty(txtfirstName.Text))
                    {
                        MessageBox.Show("Complete el nombre");
                    }

                    if (String.IsNullOrEmpty(txtlastName.Text))
                    {
                        MessageBox.Show("Complete el apellido");
                    }

                    if (String.IsNullOrEmpty(cmbposition.Text))
                    {
                        MessageBox.Show("Complete la posicion");
                    }

                    if (String.IsNullOrEmpty(txtemail.Text))
                    {
                        MessageBox.Show("Complete el email");
                    }
                    else
                    {
                        objectDOM.InsertUser(txtloginName.Text, txtpassword.Text, txtfirstName.Text, txtlastName.Text, cmbposition.Text, txtemail.Text);
                        MessageBox.Show("Se ha insertado correctamente");
                    }
                }

                else
                {
                    if (String.IsNullOrEmpty(txtloginName.Text))
                    {
                        MessageBox.Show("Complete the loginname");
                    }

                    if (String.IsNullOrEmpty(txtpassword.Text))
                    {
                        MessageBox.Show("Complete the password");
                    }

                    if (String.IsNullOrEmpty(txtfirstName.Text))
                    {
                        MessageBox.Show("Complete the name");
                    }

                    if (String.IsNullOrEmpty(txtlastName.Text))
                    {
                        MessageBox.Show("Complete the lastname");
                    }

                    if (String.IsNullOrEmpty(cmbposition.Text))
                    {
                        MessageBox.Show("Complete the position");
                    }

                    if (String.IsNullOrEmpty(txtemail.Text))
                    {
                        MessageBox.Show("Complete the email");
                    }
                    else
                    {
                        objectDOM.InsertUser(txtloginName.Text, txtpassword.Text, txtfirstName.Text, txtlastName.Text, cmbposition.Text, txtemail.Text);
                        MessageBox.Show("Insert correcty");
                    }
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Verifique los datos");
              
              
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
