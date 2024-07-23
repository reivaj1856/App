using App_practica_1.UsuariosApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace App_practica_1
{
    public partial class Interfaz : Form
    {
        private Usuario usuario;
        private Conexionbd b1;
        public Interfaz(Usuario us)
        {
            InitializeComponent();
            usuario = us;
            b1 = new Conexionbd();
            label6.Text = usuario.Nombre;
            label7.Text = usuario.Email;
            ArrayList list = b1.getUsuarios();
            foreach (Usuario usuario in list)
            {
                string[] row = new string[]
                {
                    usuario.UsuarioID.ToString(),
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Email,
                    usuario.RolID.ToString()
                };
                dataGridView1.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registro r1 = new Registro(0,0);
            r1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Obtén el valor de las celdas en la fila seleccionada
                int usuarioID = int.Parse(selectedRow.Cells[0].Value.ToString());
                Usuario us=b1.getUsuarioID(usuarioID);
                Registro r1 = new Registro(0,us.RolID);
                string nombre = us.Nombre;
                string apellido = us.Apellido;
                string email = us.Email;
                string contraseña = us.Contraseña;
                int num = us.RolID-1;
                r1.llenar(nombre, apellido, email, contraseña, num);
                r1.ShowDialog();
            }
            else
            {
                MessageBox.Show("seleccione un usuario");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Obtén el valor de las celdas en la fila seleccionada
                int usuarioID = int.Parse(selectedRow.Cells[0].Value.ToString());
                Usuario us = b1.getUsuarioID(usuarioID);
                
            }
            else
            {
                MessageBox.Show("seleccione un usuario");
            }
        }
    }
}
