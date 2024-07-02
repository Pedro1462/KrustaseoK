﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
namespace KrustaseoK
{
    public partial class Form1 : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        GMapOverlay routeOverlay;
        double Latinicial = 21.1977162234265;
        double Loninicial = -86.8570518493652;
        private bool soloUnaRuta = false;
        string pedido = null;
        string total = null;
        string orden = null;
        string direccion = null;
        string segundaDireccion = null;
        public bool reiniciar = false;
        double lat ;
        double lon;
        private bool registro = false;


        void sucursal()
        {

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(Latinicial, Loninicial);
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 15;
            gMapControl1.AutoScroll = true;

            markerOverlay = new GMapOverlay("Sucursal");
            marker = new GMarkerGoogle(new PointLatLng(Latinicial, Loninicial), GMarkerGoogleType.green);
            markerOverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Sucursal \n Latitud:{0} \n Longitud {1}", Latinicial, Loninicial);
            gMapControl1.Overlays.Add(markerOverlay);


            routeOverlay = new GMapOverlay("routes");
            gMapControl1.Overlays.Add(routeOverlay);

        }
        private void limpiarRuta()
        {
            routeOverlay.Routes.Clear();
            routeOverlay.Markers.Clear();
            soloUnaRuta = false;
        }

        private void dibugarRuta(PointLatLng start, PointLatLng end)
        {
            limpiarRuta();

            GMarkerGoogle startMarker = new GMarkerGoogle(start, GMarkerGoogleType.green);
            GMarkerGoogle endMarker = new GMarkerGoogle(end, GMarkerGoogleType.red);
            routeOverlay.Markers.Add(startMarker);
            routeOverlay.Markers.Add(endMarker);
            var points = new List<PointLatLng> { start, end };
            GMapRoute route = new GMapRoute(points, "MyRoute")
            {
                Stroke = new Pen(Color.Red, 3)
            };
            routeOverlay.Routes.Add(route);
            gMapControl1.ZoomAndCenterMarkers("routes");
        
    }
        Form2 ventana = new Form2();
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
            //tabPage10.Parent = null;
            label60.Visible = false;
            label57.Visible = false;
            label55.Visible = false;
            label59.Visible = false;
            textBox16.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox15.Visible = false;
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
            MySqlDataReader ver = consulta.filtroInicioSesion(textBox1.Text, textBox2.Text);


            if (ver.HasRows)
            {
                ver.Read();

                string usuario = ver.GetString(ver.GetOrdinal("Usuario"));
                string contraseña = ver.GetString(ver.GetOrdinal("Contraseña"));
                string indiceDir1 = ver.GetString(ver.GetOrdinal("Direccion1"));
                string indiceDir2 = ver.GetString(ver.GetOrdinal("Direccion2"));

                textBox21.Text = indiceDir1;
                textBox22.Text = indiceDir2;


                if (textBox1.Text == usuario && textBox2.Text == contraseña)
                {
                    orden = textBox1.Text;
                    listBox9.Items.Add(textBox1.Text);
                    MessageBox.Show("Se ha iniciado sesión correctamente");
                    textBox1.Clear();
                    textBox2.Clear();

                    tabControl1.TabPages.Insert(1, tabPage5);
                    tabPage1.Parent = null;
                }
                else
                {
                    MessageBox.Show("Inicio de sesión incorrecto");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                    return;
                }


            }


            ver.Close();
            consulta.cerrar();
            
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private  void button4_Click(object sender, EventArgs e)
        {
            //dddd
            /*await Task.Delay(2000);
            tabPage2.Parent = null;
            tabControl1.SelectedTab = tabPage1;*/
            /*
            string nombre = textBox3.Text;
            string apellido = textBox4.Text;
            string usuario = textBox8.Text;
            string numerocelular = textBox5.Text;
            string correo =textBox9.Text;
            string direccionparte1 = listBox1.SelectedItem.ToString();
            string direccionparte2 = listBox2.SelectedItem.ToString();
            string contraseña = textBox6.Text;*/
            


            consulta consulta = new consulta();
            
            consulta.agregarRegistro(textBox3.Text, textBox4.Text, textBox8.Text, textBox5.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox6.Text);
            MessageBox.Show("Registro Exitoso");
            if (tabPage1.Parent == null)
            {
                tabControl1.TabPages.Insert(1,tabPage1 );
            }
            foreach (TabPage tabpage in tabControl1.TabPages)
            {
                if( tabpage != tabPage1)
                {
                    tabpage.Parent = null;
                }
            }

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
            sucursal();
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            
        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void gMapControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(3, tabPage3);
            tabControl1.SelectedTab = tabPage3;
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
            textBox20.Text = comboBox1.Text;


            tabControl1.TabPages.Insert(1, tabPage6);
                tabPage9.Parent = null;
            
            MessageBox.Show("Cobro Exitoso");
            consulta.cerrar();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1,tabPage4);
            tabControl1.TabPages.Insert(1, tabPage5);
            tabPage9.Parent = null;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Efectivo");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage9);
            tabPage4.Parent = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            if (comboBox1.Text!= null)
            {
                if (comboBox1.Text == "Efectivo")
                {
                    label60.Visible = false;
                    label57.Visible=false;
                    label55.Visible = false;
                    label59.Visible= false;
                    textBox16.Visible = false;
                    textBox12.Visible= false;
                    textBox13.Visible= false;
                    textBox15.Visible= false;
                    
                } else if(comboBox1.Text == "Tarjeta Credito/Debito")
                {
                    label60.Visible = true;
                    label57.Visible = true;
                    label55.Visible = true;
                    label59.Visible = true;
                    textBox16.Visible = true;
                    textBox12.Visible = true;
                    textBox13.Visible = true;
                    textBox15.Visible = true;
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
            tabControl1.TabPages.Insert(1, tabPage7);
            tabPage6.Parent = null;

            consulta consulta = new consulta();
          string texto = textBox8.Text;
             listBox9.Items.Add(texto);
         


            consulta.tablapedido(textBox14.Text,textBox19.Text,textBox20.Text,listBox9.Text,textBox21.Text,textBox22.Text);
            consulta.cerrar();

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            consulta consulta = new consulta();

            MySqlDataReader ver;
            ver = consulta.leer();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            if (ver .HasRows) 
            {
               while (ver .Read()) 
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = ver.GetValue(0);
                    dataGridView1.Rows[n].Cells[1].Value = ver.GetString(1);
                    dataGridView1.Rows[n].Cells[2].Value = ver.GetString(2);
                    dataGridView1.Rows[n].Cells[3].Value = ver.GetString(3);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*tabControl1.TabPages.Insert(1, tabPage4);
            tabPage5.Parent = null;*/

        }

        private void label24_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage4);
            tabPage5.Parent = null;
            textBox14.Text ="Hamburguesa de res ";
            textBox19.Text = "$ 135.00 ";
            string texto = textBox8.Text;
            listBox9.Items.Add(texto);
            


        }

        private void label25_Click(object sender, EventArgs e)
        {


            tabControl1.TabPages.Insert(1, tabPage4);
            tabPage5.Parent = null;
            textBox14.Text="Hamburguesa de pollo ";
            textBox19.Text = "$ 120.00 ";
            string texto = textBox8.Text;
            listBox9.Items.Add(texto);
          
        }

        private void label26_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage4);
            tabPage5.Parent = null;
            textBox14.Text="Hamburguesa de cordero ";
            textBox19.Text = "$ 155.00 ";
            string texto = textBox8.Text;
            listBox9.Items.Add(texto);
           
        }

        private void label27_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage4);
            tabPage5.Parent = null;
            textBox14.Text = "Hamburguesa de pescado ";
            textBox19.Text = "$ 115.00 ";
            string texto = textBox8.Text;
            listBox9.Items.Add(texto);
           
        }

        private void label28_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage6);
            tabPage5.Parent = null;
            textBox14.Text = "Carne extra";
            textBox19.Text = "$ 35.00 ";
            string texto = textBox8.Text;
            listBox9.Items.Add(texto);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage5);
            tabPage6.Parent = null;
        }

        private void listBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage8);
            tabPage7.Parent = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (RadioButton radioButton in groupBox1.Controls)
            {
                if (radioButton.Checked == true)
                {
                    label20.Text = label20.Text + " Pan: " + radioButton.Text + ", ";
                }
            }
            foreach (CheckBox checkBox in groupBox5.Controls)
            {
                if (checkBox.Checked == true)
                {
                    label20.Text += checkBox.Text + "  , ";
                }
            }
            foreach (CheckBox checkBox in groupBox6.Controls)
            {
                if (checkBox.Checked == true)
                {
                    label20.Text += checkBox.Text + "  , ";
                }
            }
            /*foreach (RadioButton radioButton in groupBox2.Controls)
            {
                if (radioButton.Checked == true)
                {
                    label20.Text = label20.Text + "con carne: " + radioButton.Text + ", ";

                }
            }*/
            foreach (RadioButton radioButton in groupBox3.Controls)
            {
                if (radioButton.Checked == true)
                {
                    label20.Text = label20.Text + radioButton.Text + "  ,";
                }
            }
            foreach (RadioButton radioButton in groupBox4.Controls)
            {
                if (radioButton.Checked == true)
                {
                    label20.Text = label20.Text + radioButton.Text + "  ,";
                }
            }
            string pedido = label20.Text;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label20.Text = "Su orden es una hamburguesa con: ";
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private async void  gMapControl1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (soloUnaRuta) return;
             lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
             lon = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            marker.Position = new PointLatLng(lat, lon);
            marker.ToolTipText = string.Format("Casa \n Latitud:{0} \n Longitud {1}", lat, lon);

            textBox10.Text = lat.ToString();
            textBox11.Text = lon.ToString();
            double startLat = Latinicial;
                double startLon = Loninicial;
                double endLat = lat;
                double endLon = lon;
           
            dibugarRuta(new PointLatLng(startLat, startLon), new PointLatLng(endLat, endLon));
             
            
            await Task.Delay(3000);
            if (registro == true) {
               
                tabControl1.SelectedTab = tabPage2;
                tabPage3.Parent = null;
            }else if(registro == false) {
               
                tabControl1.TabPages.Insert(1, tabPage4);
                tabPage3.Parent = null;
            }
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            registro = true;
            tabControl1.TabPages.Insert(1, tabPage3);
            tabControl1.SelectedTab = tabPage3;
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            /*tabControl1.TabPages.Insert(1, tabPage10);
            tabPage9.Parent = null;*/

        }

        private void button22_Click(object sender, EventArgs e)
        {
           /* tabControl1.TabPages.Insert(1, tabPage9);
            tabPage10.Parent = null;*/
        }

        private void button21_Click(object sender, EventArgs e)
        {
            /*tabControl1.TabPages.Insert(1, tabPage9);
            tabPage10.Parent = null;
            

            foreach(RadioButton radioButton in groupBox7.Controls)
            {
                if (radioButton.Checked == true)
                {
                    textBox21.Text += radioButton.Text;
                }
            }*/
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage5);
            tabPage4.Parent = null;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load_1(object sender, EventArgs e)
        {
            limpiarRuta();
       
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            tabControl1.TabPages.Insert(1, tabPage3);
            tabPage4.Parent = null;
            tabControl1.SelectedTab = tabPage3;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage5);
            tabPage7.Parent = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(1, tabPage1);
            tabPage7.Parent = null;
          
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
             tabControl1.TabPages.Insert(1, tabPage7);
           tabPage8.Parent = null;

        }

        private void label28_Click_1(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_2(object sender, EventArgs e)
        {
            radioButton5.Checked = radioButton6.Checked;
            radioButton7.Checked = radioButton8.Checked;
        }

        private void button21_Click_1(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void lblStep1_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            ventana.Visible = true;
        }
    }
}
