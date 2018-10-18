using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ProyectoTCU
{
    public partial class ListenPlaces : Form
    {
        
        Menu1erGrado m1;
        PrepositionsCity pc;
        Neighborhood nei;
        MenuNeighborhood mn;
        Dictionary<Image,String> places;
        Dictionary<Image, SoundPlayer> placesaudio;
        List<int> usadas;
        int imagenActual,contador;
       

        public ListenPlaces()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            places = new Dictionary<Image, String>();
            places.Add(Properties.Resources.xbakery,"Bakery");
            places.Add(Properties.Resources.bank,"Bank");
            places.Add(Properties.Resources.book_store,"Book store");
            places.Add(Properties.Resources.bus_station,"Bus station");
            places.Add(Properties.Resources.church,"Church");
            places.Add(Properties.Resources.drugstore,"Drug store");
            places.Add(Properties.Resources.fire_department,"Fire station");
            places.Add(Properties.Resources.gym,"Gym");
            places.Add(Properties.Resources.hardware_store,"Hardware");
            places.Add(Properties.Resources.Hospital,"Hospital");
            places.Add(Properties.Resources.mall,"Mall");
            places.Add(Properties.Resources.movie_theater,"Movie theater");
            places.Add(Properties.Resources.Park,"Park");
            places.Add(Properties.Resources.petshop,"Pet shop");
            places.Add(Properties.Resources.police_station,"Police station");
            places.Add(Properties.Resources.restaurant_i,"Restaurant");
            places.Add(Properties.Resources.stadium,"Stadium");
            places.Add(Properties.Resources.supermarket,"Supermarket");

            contador = 0;

            placesaudio = new Dictionary<Image, SoundPlayer>();
            usadas = new List<int>();

            placesaudio.Add(Properties.Resources.xbakery, new SoundPlayer(Properties.Resources.bakery_audio));
            placesaudio.Add(Properties.Resources.bank, new SoundPlayer(Properties.Resources.bank_audio));
            placesaudio.Add(Properties.Resources.book_store, new SoundPlayer(Properties.Resources.book_store_audio));
            placesaudio.Add(Properties.Resources.bus_station, new SoundPlayer(Properties.Resources.bus_stop_audio));
            placesaudio.Add(Properties.Resources.church, new SoundPlayer(Properties.Resources.church_audio));
            placesaudio.Add(Properties.Resources.drugstore, new SoundPlayer(Properties.Resources.drug_store_audio));
            placesaudio.Add(Properties.Resources.fire_department, new SoundPlayer(Properties.Resources.fire_station_audio));
            placesaudio.Add(Properties.Resources.gym, new SoundPlayer(Properties.Resources.gym_audio));
            placesaudio.Add(Properties.Resources.hardware_store, new SoundPlayer(Properties.Resources.hardware_store_audio));
            placesaudio.Add(Properties.Resources.xhospital, new SoundPlayer(Properties.Resources.hospital_audio));
            placesaudio.Add(Properties.Resources.mall, new SoundPlayer(Properties.Resources.mall_audio));
            placesaudio.Add(Properties.Resources.movie_theater, new SoundPlayer(Properties.Resources.movie_theater_audio));
            placesaudio.Add(Properties.Resources.Park, new SoundPlayer(Properties.Resources.park_audio));
            placesaudio.Add(Properties.Resources.petshop, new SoundPlayer(Properties.Resources.pet_shop_audio));
            placesaudio.Add(Properties.Resources.xpolice_station, new SoundPlayer(Properties.Resources.police_station_audio));
            placesaudio.Add(Properties.Resources.restaurant_i, new SoundPlayer(Properties.Resources.restaurant_audio));
            placesaudio.Add(Properties.Resources.stadium, new SoundPlayer(Properties.Resources.stadium_audio));
            placesaudio.Add(Properties.Resources.supermarket, new SoundPlayer(Properties.Resources.supermarket_audio));

            asignar();
            
            
        }

        private void asignar() {
            Random rn = new Random();
            if (contador < places.Count)
            {
                imagenActual = rn.Next(0, places.Count);
                while (usadas.Contains(imagenActual))
                {
                    imagenActual = rn.Next(0, places.Count);
                }
                usadas.Add(imagenActual);
                pictureBox1.Image = places.ElementAt(imagenActual).Key;
                label2.Text = places[pictureBox1.Image];
            }
            else {

                usadas.Clear();
                
            }
        }

        private void ListenPlaces_Load(object sender, EventArgs e)
        {

        }

       
        private void backB_Click(object sender, EventArgs e)
        {
            mn = new MenuNeighborhood();
            this.Hide();
            mn.Show();
        }

        private void audio_Button_Click(object sender, EventArgs e)
        {
            Image sa = placesaudio.ElementAt(imagenActual).Key;
            try
            {
                placesaudio[sa].Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void pictureBox_next_Click(object sender, EventArgs e)
        {
            contador++;
            asignar();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nei = new Neighborhood();
            this.Hide();
            nei.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
