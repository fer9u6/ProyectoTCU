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
    public partial class PrepositionsCity : Form
    {
        
        ListenPlaces lp;
        Neighborhood nei;
        MenuNeighborhood mn;
        Dictionary<Image, String> imagenPrepo;
        Dictionary<Image, SoundPlayer> imagenSonido;
        int contador;
        public PrepositionsCity()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            imagenPrepo = new Dictionary<Image, string>();
            imagenPrepo.Add(Properties.Resources.across_from,"Across from");
            imagenPrepo.Add(Properties.Resources.behind, "Behind ");
            imagenPrepo.Add(Properties.Resources.between, "Between ");
            imagenPrepo.Add(Properties.Resources.in_front_of, "In front of ");
            imagenPrepo.Add(Properties.Resources.near, "Near");
            imagenPrepo.Add(Properties.Resources.far_from, "Far from");
            imagenPrepo.Add(Properties.Resources.next_to, "Next to");
            imagenPrepo.Add(Properties.Resources.on_the_corner, "On the corner");

            imagenSonido = new Dictionary<Image, SoundPlayer>();

            imagenSonido.Add(Properties.Resources.across_from,new SoundPlayer(Properties.Resources.across_from_audio));
            imagenSonido.Add(Properties.Resources.behind,  new SoundPlayer(Properties.Resources.behind_audio));
            imagenSonido.Add(Properties.Resources.between,new SoundPlayer(Properties.Resources.between_audio));
            imagenSonido.Add(Properties.Resources.in_front_of, new SoundPlayer(Properties.Resources.in_front_of_audio));
            imagenSonido.Add(Properties.Resources.near, new SoundPlayer(Properties.Resources.near_audio));
            imagenSonido.Add(Properties.Resources.far_from, new SoundPlayer(Properties.Resources.far_from_audio));
            imagenSonido.Add(Properties.Resources.next_to, new SoundPlayer(Properties.Resources.next_to_audio));
            imagenSonido.Add(Properties.Resources.on_the_corner, new SoundPlayer(Properties.Resources.on_the_corner_audio));

            contador = 0;
            mostrar();
            
            
        }

        private void mostrar() {
            if (contador < imagenPrepo.Count)
            {
                pictureBox1.Image = imagenPrepo.ElementAt(contador).Key;
                label2.Text = imagenPrepo[pictureBox1.Image];


            }
            else {
                MessageBox.Show("You are ready to play");
                contador = 0;
               
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void backB_Click(object sender, EventArgs e)
        {
            mn= new MenuNeighborhood();
            this.Hide();
            mn.Show();
        }

        private void audio_Button_Click(object sender, EventArgs e)
        {
            try {
                imagenSonido[imagenSonido.ElementAt(contador).Key].Play();
            }
            catch (Exception ex) {

                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void pictureBox_next_Click(object sender, EventArgs e)
        {
            contador++;
            mostrar();
        }

        private void buttonplay_Click(object sender, EventArgs e)
        {
            nei = new Neighborhood();
            this.Hide();
            nei.Show();
        }

        
    }
}
