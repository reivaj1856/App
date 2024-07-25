using App_practica_1.UsuariosApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_practica_1
{
    public partial class Registro : Form
    {
        private Controlador controlador;
        private int numero;
        public Registro(int num,int num1)
        {
            numero = num1;
            InitializeComponent();
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            if (num==1)
            {
                comboBox2.SelectedIndex= 1;
                comboBox2.Enabled = false;
            }
            else
            {
                comboBox2.SelectedIndex= 0;
            }
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numero==0)
            {
                string nombre = textBox1.Text;
                string apellido = textBox2.Text;
                string email = textBox3.Text;
                string contraseña = textBox4.Text;
                int num = comboBox2.SelectedIndex + 1;
                if (nombre != "" && apellido != "" && email != "" && contraseña != "")
                {
                    controlador.agregarUsuario(nombre, apellido, email, contraseña, num);
                    Close();
                }
                else
                {
                    MessageBox.Show("rellene todos los espacios");
                }
            }
            else
            {
                string nombre = textBox1.Text;
                string apellido = textBox2.Text;
                string email = textBox3.Text;
                string contraseña = textBox4.Text;
                int num = comboBox2.SelectedIndex + 1;
                if (nombre != "" && apellido != "" && email != "" && contraseña != "")
                {
                    b1.ActualizarTodosUsuarios(numero,nombre, apellido, email, contraseña, num);
                    Close();
                }
                else
                {
                    MessageBox.Show("rellene todos los espacios");
                }
            }
        }
        public void llenar(string nombre,string apellido,string email,string contraseña,int num)
        {
            textBox1.Text=nombre;
            textBox2.Text=apellido;
            textBox3.Text=email;
            textBox4.Text=contraseña;
            comboBox2.SelectedIndex =num;
        }
    }
}
