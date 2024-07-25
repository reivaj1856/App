using App_practica_1.UsuariosApp;
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
        private Controlador c1;
        public Form1()
        {
            InitializeComponent();
            c1=new Controlador();
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
            Registro r1 = new Registro(1,0);
            r1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Recuperacion r1 = new Recuperacion();
            r1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c1.IniciarSesion(textBox1.Text,textBox2.Text);
        }
    }
}
