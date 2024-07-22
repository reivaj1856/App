using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_practica_1
{
    public partial class Interfaz : Form
    {
        public Interfaz()
        {
            InitializeComponent();
            Conexionbd b1 = new Conexionbd();
            b1.pedirUsuario();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
