using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App_practica_1
{
    class Conexionbd
    {
        SqlConnection conex = new SqlConnection();

        string cadenaConexion = "Data Source= DESKTOP-D46MFDH\\SQLEXPRESS; Initial Catalog=TiendaRopaUsada; Integrated Security = True";

        public bool evaluarUsuario(string name,string pass)
        {
            bool autenticador = false;
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT UsuarioID, Nombre, Apellido, Email, Contraseña, RolID FROM Usuarios";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read() && !autenticador)
                    {
                        int usuarioID = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apvfellido = reader.GetString(2);
                        string email = reader.GetString(3);
                        string contraseña = reader.GetString(4);
                        int rolID = reader.GetInt32(5);
                        if (nombre==name) {
                            if (contraseña == pass)
                            {
                                autenticador = true;
                            }
                        }
                    }
                }
                    
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return autenticador;
        }
        public string recuperarContraseña(string name)
        {
            string contra = "";
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT UsuarioID, Nombre, Apellido, Email, Contraseña, RolID FROM Usuarios";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read() && contra=="")
                    {
                        int usuarioID = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apvfellido = reader.GetString(2);
                        string email = reader.GetString(3);
                        string contraseña = reader.GetString(4);
                        int rolID = reader.GetInt32(5);
                        if (nombre == name)
                        {
                            contra = contraseña;
                        }
                    }
                }

            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return contra;
        }
    }
}
