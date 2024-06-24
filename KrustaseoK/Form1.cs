using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrustaseoK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            tabPage4.Parent = null;
            tabPage5.Parent = null;
            tabPage6.Parent = null;
            tabPage7.Parent = null;
            tabPage8.Parent = null;
            tabPage9.Parent = null;
            /*label60.Parent = null;
            label57.Parent = null;
            label55.Parent = null;
            label59.Parent = null;
            textBox16.Parent = null;
            textBox12.Parent = null;
            textBox13.Parent = null;
            textBox15.Parent = null;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            consulta consulta = new consulta();
            MySqlDataReader ver;
            ver = consulta.filtroInicioSesion(textBox1.Text,textBox2.Text);

            if (ver.HasRows)
            {
                while (ver.Read())
                {
                    string usuarioColumna = "Usuario";
                    int indiceUsuarioColumna = ver.GetOrdinal(usuarioColumna);
                    string usuario = ver.GetString(indiceUsuarioColumna);

                    string contraseñaColumna = "Contraseña";
                    int indiceContraseñaColumna = ver.GetOrdinal(contraseñaColumna);
                    string contraseña = ver.GetString(indiceContraseñaColumna);

                    if (textBox1.Text == usuario || textBox2.Text== contraseña)
                    {
                        
                            MessageBox.Show("Se a Iniciado Sesion Correctamente");
                            textBox1.Clear();
                            textBox2.Clear();

                            tabControl1.TabPages.Insert(1, tabPage4);
                            tabControl1.TabPages.Insert(1, tabPage5);
                            tabPage1.Parent = null;
                                              
                    } else
                    {
                        MessageBox.Show("Inicio de Sesion Incorrecto");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                        return;
                    }
                   
                }
            }
            consulta.cerrar();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            consulta consulta = new consulta();
            consulta.agregarRegistro(textBox3.Text, textBox4.Text, textBox8.Text, textBox5.Text, textBox9.Text, listBox1.Text, listBox2.Text, textBox6.Text);
            MessageBox.Show("Registro Exitoso");
            consulta.cerrar();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage2);
            
            tabPage1.Parent = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1,tabPage1);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
            tabPage2.Parent = null;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            consulta consulta = new consulta();
            consulta.agregarPago(textBox18.Text,textBox17.Text,comboBox1.Text);
            MessageBox.Show("Pago Exitoso");
            tabControl1.TabPages.Insert(1, tabPage6);
            tabPage9.Parent=null;
            consulta.cerrar();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1,tabPage4);
            tabControl1.TabPages.Insert(1, tabPage5);
            tabPage9.Parent = null;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1,tabPage9);
            tabPage4.Parent = null;
            tabPage5.Parent = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metPago = "";
            if (comboBox1.SelectedItem!= null)
            {
                metPago += comboBox1.SelectedItem.ToString();
                if (metPago!= "Tarjeta de Credito")
                {
                    label60.Parent = this;
                    label57.Parent = this;
                    label55.Parent = this;
                    label59.Parent = this;
                    textBox16.Parent = this;
                    textBox12.Parent = this;
                    textBox13.Parent = this;
                    textBox15.Parent = this;
                }
                else
                {
                    label60.Parent = null;
                    label57.Parent = null;
                    label55.Parent = null;
                    label59.Parent = null;
                    textBox16.Parent = null;
                    textBox12.Parent = null;
                    textBox13.Parent = null;
                    textBox15.Parent = null;
                }

            } 
            
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            consulta consulta = new consulta();
            consulta.tablapedido(listBox5.Text,listBox6.Text,listBox10.Text,listBox9.Text,listBox8.Text,listBox7.Text);
            consulta.cerrar();

        }
    }
}
