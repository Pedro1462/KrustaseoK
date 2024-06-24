using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KrustaseoK
{
    internal class consulta
    {
        private MySqlConnection conex;
        public void conectar()
        {
            string server = "localhost";
            string database = "prueba";
            string user = "root";
            string pwd = " ";
            string cadenaConexion = "server=" + server + ";database=" + database + ";" + "Uid=" + user + ";pwd=" + pwd + ";";

            conex = new MySqlConnection(cadenaConexion);

        }
        public void cerrar()
        {
            conex.Close();
        }
        public void Historial(string nombre, string correo, string telefono)
        {
            string consulta = "INSERT INTO `personas` (`id_nombre`, `Nombre`, `Correo`, `telefono`) VALUES (NULL, '" + nombre + "', '" + correo + "', '" + telefono + "')";
            conectar();
            conex.Open();
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            MySqlDataReader ejecuta;
            ejecuta = comando.ExecuteReader();
            cerrar();
        }
    }
}
