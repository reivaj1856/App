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
            Conexionbd b1 = new Conexionbd();
            string cuenta = textBox1.Text;
            string contraseña = textBox2.Text;
            if (b1.evaluarUsuario(cuenta, contraseña))
            {
                Usuario us = b1.getUsuario(cuenta,contraseña);
                if (us.RolID==3)
                {
                    Interfaz i1 = new Interfaz(us);
                    i1.ShowDialog();
                }
                if (us.RolID==1)
                {
                    Venta v1 = new Venta();
                    v1.ShowDialog();
                }
                if (us.RolID == 2)
                {
                    VentaUsuario v2= new VentaUsuario();
                    v2.ShowDialog();
                }
            }
            else {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }
    }
}
