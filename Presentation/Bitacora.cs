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
    public partial class Bitacora : Form
    {
        public Bitacora()
        {
            InitializeComponent();
        }
        private void Bitacora_Load(object sender, EventArgs e)
        {
            MostrarBitacora();

        }
        private void MostrarBitacora()
        {
            Bitacora_BLL bitacora = new Bitacora_BLL();
            dataGridView1.DataSource = bitacora.MostrarHistorial();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Bitacora_Load_2(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'farmaciaDataSet1.bitacora' Puede moverla o quitarla según sea necesario.
            this.bitacoraTableAdapter1.Fill(this.farmaciaDataSet1.bitacora);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
