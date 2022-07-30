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
using Services.Cache;
using Domain.Singleton;


namespace Presentation
{
    public partial class Log_in : Form
    {
        Principal p = new Principal();

        Gestionar_Clientes g = new Gestionar_Clientes();

        public Log_in()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario_BLL user = new Usuario_BLL();
           
            if (txtUsername.Text != "Username")
            {
                if (txtPassword.Text != "Password")
                {
                   var validLogin = user.LoginUser(txtUsername.Text, txtPassword.Text);


                    if (validLogin==true)
                    {
                        try{
                            if (cmbIdiomas.Text == "Español")
                            {
                               

                                SessionManager.Login();
                                p = new Principal();

                                CargarIdiomaEspañolPrincipal();

                                MessageBox.Show("Welcome " + UserLoginCache.firstName + ", " + UserLoginCache.position);
                                p.Show();
                                p.FormClosed += Logout;
                                SessionManager _session = SessionManager.GetInstance;

                             
                            }

                            if (cmbIdiomas.Text == "English")
                            {
                                

                                SessionManager.Login();
                                p = new Principal();

                                CargarIdiomaEnglishPrincipal();

                                MessageBox.Show("Welcome " + UserLoginCache.firstName + ", " + UserLoginCache.position);
                                p.Show();
                                p.FormClosed += Logout;
                                SessionManager _session = SessionManager.GetInstance;

                                

                            }
                            if (cmbIdiomas.Text=="")
                            {
                                MessageBox.Show("Seleccione un idioma");
                            }

                            //this.Close();
                        }
                        catch(Exception E)
                        {
                            MessageBox.Show(E.Message);
                        }
                    }
                    else
                    {
                        MsgError("Incorrect username or password entered.");
                        txtPassword.Text="Password";
                        txtUsername.Focus();
                    }
                }
                    else MsgError("Please enter password");
            }
                    else MsgError("Please enter username");

            }

        private void MsgError(string error)
        {
            label1.Text = "   " + error;
            label1.Visible = true;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtPassword.Text="Password";
            txtPassword.UseSystemPasswordChar = false;
            txtUsername.Text="Username";
            label1.Visible = false;
            
           
        }

        private void Log_in_Load(object sender, EventArgs e)
        {
            cmbIdiomas.DropDownStyle = ComboBoxStyle.DropDownList; 
        }


        public void CargarIdiomaEspañolLogin()
        {
            label2.Text = Idiomas.Español.label2;
            txtUsername.Text = Idiomas.Español.txtUsername;
            label1.Text = Idiomas.Español.label1;
            label4.Text = Idiomas.Español.label4;
            btnSeleccionar.Text = Idiomas.Español.btnSeleccionar;
            btnLogin.Text = Idiomas.Español.btnLogin;
        }
        public void CargarIdiomaEspañolPrincipal()
        {
            p.btnGestionarClientes.Text = Idiomas.Español.btnGestionarClientes;
            p.btnGestionar_Usuarios.Text = Idiomas.Español.btnGestionar_Usuarios;
            p.btnStock.Text = Idiomas.Español.btnStock;
            p.button1.Text = Idiomas.Español.button1;
            p.btnLogout.Text = Idiomas.Español.btnLogout;
            p.labelBienvenidos.Text = Idiomas.Español.labelBienvenidos;
        }

        public void CargarIdiomaEnglishLogin()
        {
            label2.Text = Idiomas.English.label2;
            txtUsername.Text = Idiomas.English.txtUsername;
            label1.Text = Idiomas.English.label1;
            label4.Text = Idiomas.English.label4;
            btnSeleccionar.Text = Idiomas.English.btnSeleccionar;
            btnLogin.Text = Idiomas.English.btnLogin;
        }

        public void CargarIdiomaEnglishPrincipal()
        {

            p.btnGestionarClientes.Text = Idiomas.English.btnGestionarClientes;
            p.btnGestionar_Usuarios.Text = Idiomas.English.btnGestionar_Usuarios;
            p.btnStock.Text = Idiomas.English.btnStock;
            p.button1.Text = Idiomas.English.button1;
            p.btnLogout.Text = Idiomas.English.btnLogout;
            p.labelBienvenidos.Text = Idiomas.English.labelBienvenidos;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbIdiomas.Text=="English")
            {
                CargarIdiomaEnglishLogin();
            }

            if (cmbIdiomas.Text=="Español")
            {
                CargarIdiomaEspañolLogin();
            }
        }
    }
    }

