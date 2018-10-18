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
    public partial class FlashCardsNumbers : Form
    {
        Numbers numbers;
        Dictionary<int, Image> images;
        Dictionary<int, SoundPlayer> sounds;
        int currentImage;
            
        public FlashCardsNumbers()
        {
            InitializeComponent();
            images = new Dictionary<int, Image>();
            sounds = new Dictionary<int, SoundPlayer>();
            currentImage = 1;

            images.Add(1, Properties.Resources.one);
            images.Add(2, Properties.Resources.two);
            images.Add(3, Properties.Resources.three);
            images.Add(4, Properties.Resources.four);
            images.Add(5, Properties.Resources.five);
            images.Add(6, Properties.Resources.six);
            images.Add(7, Properties.Resources.seven);
            images.Add(8, Properties.Resources.eight);
            images.Add(9, Properties.Resources.nine);
            images.Add(10, Properties.Resources.ten);

            sounds.Add(1, new SoundPlayer(Properties.Resources.one_audio));
            sounds.Add(2, new SoundPlayer(Properties.Resources.two_audio));
            sounds.Add(3, new SoundPlayer(Properties.Resources.three_audio));
            sounds.Add(4, new SoundPlayer(Properties.Resources.four_audio));
            sounds.Add(5, new SoundPlayer(Properties.Resources.five_audio));
            sounds.Add(6, new SoundPlayer(Properties.Resources.six_audio));
            sounds.Add(7, new SoundPlayer(Properties.Resources.seven_audio));
            sounds.Add(8, new SoundPlayer(Properties.Resources.eight_audio));
            sounds.Add(9, new SoundPlayer(Properties.Resources.nine_audio));
            sounds.Add(10, new SoundPlayer(Properties.Resources.ten_audio));

            mostrar();
        }

        private void mostrar()
        {
            pictureBox1.Image = images[currentImage];
        }

        private void backB_Click(object sender, EventArgs e)
        {
            //back
            numbers = new Numbers();
            numbers.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //next
            currentImage++;
            if (currentImage == 11)
            {
                currentImage = 1;
            }
            mostrar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //prev
            currentImage--;
            if (currentImage == 0)
            {
                currentImage = 10;
            }
            mostrar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //sound
            try
            {
                sounds[currentImage].Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
