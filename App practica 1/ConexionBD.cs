using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using App_practica_1.UsuariosApp;

namespace App_practica_1
{
    class Conexionbd
    {
        SqlConnection conex = new SqlConnection();

        //string cadenaConexion = "Data Source= DESKTOP-VSFDTI4\\SQLSERVEREXPRESS; Initial Catalog=TiendaRopaUsada; Integrated Security = True";
        string cadenaConexion = "Data Source= DESKTOP-D46MFDH\\SQLEXPRESS; Initial Catalog=TiendaRopaUsada; Integrated Security = True";

        public bool evaluarUsuario(string name, string pass)
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
                        if (nombre == name) {
                            if (contraseña == pass)
                            {
                                autenticador = true;
                            }
                        }
                    }
                }
                conex.Close();
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

                    while (reader.Read() && contra == "")
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
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return contra;
        }

        public Usuario getUsuario(string name, string pass)
        {
            Usuario autenticador = null;
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT UsuarioID, Nombre, Apellido, Email, Contraseña, RolID FROM Usuarios";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read() && autenticador == null)
                    {
                        int usuarioID = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apvfellido = reader.GetString(2);
                        string email = reader.GetString(3);
                        string contraseña = reader.GetString(4);
                        int rolID = reader.GetInt32(5);

                        if (nombre == name)
                        {
                            if (contraseña == pass)
                            {
                                autenticador = new Usuario(usuarioID, nombre, apvfellido, email, contraseña, rolID);
                            }
                        }
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return autenticador;
        }
        public ArrayList getUsuarios()
        {
            ArrayList list = new ArrayList();
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT UsuarioID, Nombre, Apellido, Email, Contraseña, RolID FROM Usuarios";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int usuarioID = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apvfellido = reader.GetString(2);
                        string email = reader.GetString(3);
                        string contraseña = reader.GetString(4);
                        int rolID = reader.GetInt32(5);
                        list.Add(new Usuario(usuarioID, nombre, apvfellido, email, contraseña, rolID));
                        
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }
            return list;
        }
        public Usuario getUsuarioID(int id)
        {
            Usuario us = null;
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT UsuarioID, Nombre, Apellido, Email, Contraseña, RolID FROM Usuarios";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int usuarioID = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apvfellido = reader.GetString(2);
                        string email = reader.GetString(3);
                        string contraseña = reader.GetString(4);
                        int rolID = reader.GetInt32(5);
                        if (usuarioID == id)
                        {
                            us = new Usuario(usuarioID, nombre, apvfellido, email, contraseña, rolID);
                        }
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }
            return us;
        }
        public void AgregarUsuario(string nombre, string apellido, string email, string contraseña, int rolID)
        {
            using (SqlConnection conex = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conex.Open();
                    string query = "INSERT INTO Usuarios ( Nombre, Apellido, Email, Contraseña, RolID) " +
                                   "VALUES ( @Nombre, @Apellido, @Email, @Contraseña, @RolID)";

                    using (SqlCommand command = new SqlCommand(query, conex))
                    {
                        // Agregar parámetros para evitar inyecciones SQL
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Contraseña", contraseña); // Considera usar un hash para la contraseña
                        command.Parameters.AddWithValue("@RolID", rolID);

                        // Ejecutar la consulta de inserción
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Usuario agregado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se agregó ningún usuario.");
                        }
                    }
                    conex.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + e.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public void ActualizarTodosUsuarios(int usuarioID,string nuevoNombre, string nuevoApellido, string nuevoEmail, string nuevaContraseña, int nuevoRolID)
        {
            using (SqlConnection conex = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conex.Open();
                    string query = "UPDATE Usuarios SET Nombre = @NuevoNombre, Apellido = @NuevoApellido, Email = @NuevoEmail, Contraseña = @NuevaContraseña, RolID = @NuevoRolID WHERE UsuarioID = @UsuarioID";

                    using (SqlCommand command = new SqlCommand(query, conex))
                    {
                        // Agregar parámetros para evitar inyecciones SQL
                        command.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                        command.Parameters.AddWithValue("@NuevoApellido", nuevoApellido);
                        command.Parameters.AddWithValue("@NuevoEmail", nuevoEmail);
                        command.Parameters.AddWithValue("@NuevaContraseña", nuevaContraseña); // Considera usar un hash para la contraseña
                        command.Parameters.AddWithValue("@NuevoRolID", nuevoRolID);
                        command.Parameters.AddWithValue("@UsuarioID", usuarioID);

                        // Ejecutar la consulta de actualización
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("Todos los usuarios actualizados exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se actualizaron usuarios.");
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error al conectar con la base de datos: " + e.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public void EliminarUsuario(int usuarioID)
        {
            using (SqlConnection conex = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conex.Open();
                    string query = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID";

                    using (SqlCommand command = new SqlCommand(query, conex))
                    {
                        command.Parameters.AddWithValue("@UsuarioID", usuarioID);

                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("Usuario eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el usuario con el ID proporcionado.");
                        }
                    }
                    conex.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error al conectar con la base de datos: " + e.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
