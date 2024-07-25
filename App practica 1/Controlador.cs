using App_practica_1.UsuariosApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_practica_1
{
    public class Controlador
    {
        private Conexionbd b1;
        public Controlador()
        {
            b1 = new Conexionbd();
        }
        public void IniciarSesion (string cuenta,string contraseña){
            
            Conexionbd b1 = new Conexionbd();

            if (b1.evaluarUsuario(cuenta, contraseña))
            {
                Usuario us = b1.getUsuario(cuenta, contraseña);
                if (us.RolID == 3)
                {
                    Interfaz i1 = new Interfaz(us);
                    i1.ShowDialog();
                }
                if (us.RolID == 1)
                {
                    Venta v1 = new Venta();
                    v1.ShowDialog();
                }
                if (us.RolID == 2)
                {
                    VentaUsuario v2 = new VentaUsuario();
                    v2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }
        public ArrayList getDatos() {
           
            return b1.getUsuarios();
        }
        public Usuario getUsuarioID(int usuarioID) {
            return b1.getUsuarioID(usuarioID);
        }
        public void agregarUsuario(string nombre,string apellido,string email,string contraseña,int num) { 
            b1.AgregarUsuario(nombre, apellido, email, contraseña, num);
        }
        public void eliminarUsuario(int usuarioID)
        {
            b1.EliminarUsuario(usuarioID);
        }
        public void 
    }
}
