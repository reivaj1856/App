using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_practica_1
{
    using System;

    namespace UsuariosApp
    {
        public class Usuario
        {
            // Atributos de la clase
            public int UsuarioID { get; private set; }
            public string Nombre { get; private set; }
            public string Apellido { get; private set; }
            public string Email { get; private set; }
            public int RolID { get; private set; }
            public string Contraseña { get; private set; }

            // Constructor
            public Usuario(int usuarioID, string nombre, string apellido, string email,string contraseña, int rolID)
            {
                UsuarioID = usuarioID;
                Nombre = nombre;
                Apellido = apellido;
                Email = email;
                Contraseña = contraseña;
                RolID = rolID;
            }

            // Métodos para cambiar el estado de los atributos
            public void CambiarNombre(string nuevoNombre)
            {
                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    Nombre = nuevoNombre;
                }
                else
                {
                    throw new ArgumentException("El nombre no puede estar vacío.");
                }
            }

            public void CambiarApellido(string nuevoApellido)
            {
                if (!string.IsNullOrEmpty(nuevoApellido))
                {
                    Apellido = nuevoApellido;
                }
                else
                {
                    throw new ArgumentException("El apellido no puede estar vacío.");
                }
            }

            public void CambiarEmail(string nuevoEmail)
            {
                if (!string.IsNullOrEmpty(nuevoEmail))
                {
                    Email = nuevoEmail;
                }
                else
                {
                    throw new ArgumentException("El email no puede estar vacío.");
                }
            }
            public void CambiarContraseña(string nuevoContraseña)
            {
                if (!string.IsNullOrEmpty(nuevoContraseña))
                {
                    Email = nuevoContraseña;
                }
                else
                {
                    throw new ArgumentException("La contraseña no puede estar vacío.");
                }
            }

            public void CambiarRolID(int nuevoRolID)
            {
                if (nuevoRolID > 0)
                {
                    RolID = nuevoRolID;
                }
                else
                {
                    throw new ArgumentException("El RolID debe ser mayor a 0.");
                }
            }

            public override string ToString()
            {
                return $"UsuarioID: {UsuarioID}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, RolID: {RolID}";
            }
        }
    }

}
