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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            tabControl1.TabPages.Insert(2, tabPage2);
            tabControl1.SelectedTab = tabPage2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void label24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            listBox5.Items.Add("Hamburguesa de res ");
            listBox6.Items.Add("$ 135.00 ");
            if (string.IsNullOrWhiteSpace(textBox1.Text)) {

                string texto = textBox2.Text;
                listBox9.Items.Add(texto);
            }
            else
            {
                string texto = textBox8.Text;
                listBox9.Items.Add(texto);
            }
            listBox8.Items.Add(Latinicial);
            listBox7.Items.Add(Loninicial);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void label25_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 4;
            listBox5.Items.Add("Hamburguesa de pollo ");
            listBox6.Items.Add("$ 120.00 ");
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {

                string texto = textBox2.Text;
                listBox9.Items.Add(texto);
            }
            else
            {
                string texto = textBox8.Text;
                listBox9.Items.Add(texto);
            }
            listBox8.Items.Add(Latinicial);
            listBox7.Items.Add(Loninicial);

        }

        private void label26_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            listBox5.Items.Add("Hamburguesa de cordero ");
            listBox6.Items.Add("$ 155.00 ");
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {

                string texto = textBox2.Text;
                listBox9.Items.Add(texto);
            }
            else
            {
                string texto = textBox8.Text;
                listBox9.Items.Add(texto);
            }
            listBox8.Items.Add(Latinicial);
            listBox7.Items.Add(Loninicial);
        }

        private void label27_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            listBox5.Items.Add("Hamburguesa de pescado ");
            listBox6.Items.Add("$ 115.00 ");
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {

                string texto = textBox2.Text;
                listBox9.Items.Add(texto);
            }
            else
            {
                string texto = textBox8.Text;
                listBox9.Items.Add(texto);
            }
            listBox8.Items.Add(Latinicial);
            listBox7.Items.Add(Loninicial);
        }

        private void label28_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            listBox5.Items.Add("Carne extra");
            listBox6.Items.Add("$ 35.00 ");
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {

                string texto = textBox2.Text;
                listBox9.Items.Add(texto);
            }
            else
            {
                string texto = textBox8.Text;
                listBox9.Items.Add(texto);
            }
            listBox8.Items.Add(Latinicial);
            listBox7.Items.Add(Loninicial);
        }
    }
}
