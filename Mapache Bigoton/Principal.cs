using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapache_Bigoton
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnAgregarCita_Click(object sender, EventArgs e)
        {
            Agregar_Citas agregar_citas = new Agregar_Citas();
            agregar_citas.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consultar_Citas consultar_Citas = new Consultar_Citas();
            consultar_Citas.Show();
            this.Hide();
        }

        private void btn_Salida_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
