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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registro r1 = new Registro();
            r1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Recuperacion r1 = new Recuperacion();
            r1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Interfaz i1 = new Interfaz();
            i1.ShowDialog();
        }
    }
}
