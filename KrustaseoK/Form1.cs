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
        private void dibugarRuta(PointLatLng start, PointLatLng end)
        {
            
            routeOverlay.Routes.Clear();
            routeOverlay.Markers.Clear();
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

        private async void button4_Click(object sender, EventArgs e)
        {
            //dddd
            await Task.Delay(2000);
            tabPage2.Parent = null;
            tabControl1.SelectedTab = tabPage1;

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

        private async void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (soloUnaRuta) return;
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lon = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            marker.Position = new PointLatLng(lat, lon);
            marker.ToolTipText = string.Format("Casa \n Latitud:{0} \n Longitud {1}", lat, lon);
            listBox1.Items.Add(lat);
            listBox2.Items.Add(lon);
            if (listBox1.Items.Count >= 1 && listBox2.Items.Count >= 1)
            {
                double startLat = Latinicial;
                double startLon = Loninicial;
                double endLat = lat;
                double endLon = lon;
                dibugarRuta(new PointLatLng(startLat, startLon), new PointLatLng(endLat, endLon));
                soloUnaRuta = true;
            }
            await Task.Delay(3000);
            tabControl1.SelectedTab = tabPage2;
            tabPage3.Parent = null;
            
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
