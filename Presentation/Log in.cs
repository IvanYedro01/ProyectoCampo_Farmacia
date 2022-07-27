﻿using System;
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
                            SessionManager.Login();
                            Principal principal = new Principal();
                            MessageBox.Show("Welcome " + UserLoginCache.firstName + ", " + UserLoginCache.position);
                            principal.Show();
                            principal.FormClosed += Logout;
                            SessionManager _session = SessionManager.GetInstance;

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


        public void CargarIdiomaEspañol()
        {
            label2.Text = Idiomas.Español.label2;
            txtUsername.Text = Idiomas.Español.txtUsername;
            label1.Text = Idiomas.Español.label1;
            label4.Text = Idiomas.Español.label4;
        }
        

        public void CargarIdiomaEnglish()
        {
            label2.Text = Idiomas.English.label2;
            txtUsername.Text = Idiomas.English.txtUsername;
            label1.Text = Idiomas.English.label1;
            label4.Text = Idiomas.English.label4;
            
        }


        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbIdiomas.Text == "Español")
            {
                CargarIdiomaEspañol();
            }

            if (cmbIdiomas.Text == "English")
            {
                CargarIdiomaEnglish();

            }
        }
    }
    }

