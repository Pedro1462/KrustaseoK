using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;

namespace KrustaseoK
{
    internal class consulta
    {
        private MySqlConnection conex;

        public void conectar()
        {
            string server = "b8gzqgh1at93jwhkfsev-mysql.services.clever-cloud.com";
            string database = "b8gzqgh1at93jwhkfsev";
            string user = "u5u0qktw32aj5tze";
            string pwd = "RupNwrM5fbfUfx7sflCU";
            string cadenaConexion = "server=" + server + ";database=" + database + ";uid=" + user + ";pwd=" + pwd + ";";
            conex = new MySqlConnection(cadenaConexion);
        }

        public void cerrar() 
        {
            conex.Close();
        }

        public void agregarRegistro(string nombre, string apellido, string usuario, string noCel, string correo, string direccion1,string direccion2, string contraseña)
        {
            string consulta = "INSERT INTO `registro`(`id_registro`,`Nombre`,`Apellido`, `Usuario`, `noCel`,`Correo`,`Direccion1`, `Direccion2`,`Contraseña`) VALUES(NULL,'" + nombre + "','" + apellido + "', '" + usuario + "','" + noCel+ "','" + correo + "', '" + direccion1+ "','" + direccion2+ "','" + contraseña + "')";
            conectar();
            conex.Open();
            MySqlCommand comando = new MySqlCommand(consulta,conex);
            MySqlDataReader ejecuta = comando.ExecuteReader();
            cerrar();
        }

        public MySqlDataReader filtroInicioSesion(string filtroInicioSesionUsuario, string filtroInicioSesionContraseña)
        {
            string consulta = "SELECT Usuario, Contraseña FROM `registro` WHERE Usuario= '"+ filtroInicioSesionUsuario+"' AND Contraseña = '"+filtroInicioSesionContraseña+"';";
            conectar();
            conex.Open();
            MySqlCommand commando = new MySqlCommand( consulta,conex);
            return commando.ExecuteReader();
        }

        public void agregarPago( string nombre, string apellido, string metodoPago)
        {
            string consulta = "INSERT INTO `metodoPago`(`id_metodoPago`,`Nombre`,`Apellido`, `metodoPago`) VALUES(NULL,'" + nombre + "','" + apellido + "', '" + metodoPago+ "')";
            conectar();
            conex.Open();
            MySqlCommand comando = new MySqlCommand (consulta,conex);
            MySqlDataReader ejecuta = comando.ExecuteReader();
            cerrar();
        }

        public void tablapedido(string pedido, string total, string metodoPago, string orden, string direccion1, string direccion2)
        {
            string consulta = "INSERT INTO `tablapedido`(`id_pedido`,`Pedido`,`Total`, `MetodoPago`, `Orden`, `Direccion1`, `Direccion2`) VALUES(NULL,'" + pedido + "','" + total + "', '" + metodoPago + "', '" + orden + "', '" + direccion1 + "', '" + direccion2 + "')";
            conectar();
            conex.Open();
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            MySqlDataReader ejecuta = comando.ExecuteReader();
            cerrar();

        }
    }
}
