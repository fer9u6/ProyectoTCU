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
    public partial class colorsCards : Form
    {
        Colors c = new Colors();
        Dictionary<Bitmap, SoundPlayer>imagenColores = new Dictionary<Bitmap, SoundPlayer>();
        List<Bitmap> listaImagenes = new List<Bitmap>();
        int indice;

        public colorsCards()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
            indice = 0;
            //inicializando los recursos
            SoundPlayer blue_a = new SoundPlayer(Properties.Resources.blue_audio);
            SoundPlayer red_a = new SoundPlayer(Properties.Resources.red_audio);
            SoundPlayer yellow_a = new SoundPlayer(Properties.Resources.yellow_audio);
            SoundPlayer orange_a = new SoundPlayer(Properties.Resources.orange_audio);
            SoundPlayer green_a = new SoundPlayer(Properties.Resources.green_audio);
            SoundPlayer purple_a = new SoundPlayer(Properties.Resources.purple_audio);
            SoundPlayer pink_a = new SoundPlayer(Properties.Resources.pink_audio);
            SoundPlayer brown_a = new SoundPlayer(Properties.Resources.brown_audio);
            SoundPlayer gray_a = new SoundPlayer(Properties.Resources.gray_audio);
            SoundPlayer black_a = new SoundPlayer(Properties.Resources.black_audio);
            SoundPlayer white_a = new SoundPlayer(Properties.Resources.white_audio);
            SoundPlayer colors_a = new SoundPlayer(Properties.Resources.colors_audio);

            // se declaran todas las flashcards
            Bitmap blue_fc = (Bitmap)Properties.Resources.bluefc;
            Bitmap red_fc = (Bitmap)Properties.Resources.redfc;
            Bitmap yellow_fc = (Bitmap)Properties.Resources.yellowfc;
            Bitmap orange_fc = (Bitmap)Properties.Resources.orangefc;
            Bitmap green_fc = (Bitmap)Properties.Resources.greenfc;
            Bitmap purple_fc = (Bitmap)Properties.Resources.purplefc;
            Bitmap brown_fc = (Bitmap)Properties.Resources.brownfc;
            Bitmap pink_fc = (Bitmap)Properties.Resources.pinkfc;
            Bitmap black_fc = (Bitmap)Properties.Resources.blackfc;
            Bitmap white_fc = (Bitmap)Properties.Resources.whitefc;
            Bitmap gray_fc = (Bitmap)Properties.Resources.grayfc;
            Bitmap colors_fc = (Bitmap)Properties.Resources.colorsfc1;


            listaImagenes.Add(colors_fc);
            listaImagenes.Add(blue_fc);
            listaImagenes.Add(red_fc);
            listaImagenes.Add(yellow_fc);
            listaImagenes.Add(orange_fc);
            listaImagenes.Add(purple_fc);
            listaImagenes.Add(green_fc);
            listaImagenes.Add(pink_fc);
            listaImagenes.Add(brown_fc);
            listaImagenes.Add(white_fc);
            listaImagenes.Add(black_fc);
            listaImagenes.Add(gray_fc);

            //metiendo los recursos al diccionario

            imagenColores.Add(colors_fc,colors_a);
            imagenColores.Add(blue_fc, blue_a);
            imagenColores.Add(red_fc, red_a);
            imagenColores.Add(yellow_fc, yellow_a);
            imagenColores.Add(green_fc, green_a);
            imagenColores.Add(orange_fc, orange_a);
            imagenColores.Add(purple_fc,purple_a);
            imagenColores.Add(gray_fc, gray_a);
            imagenColores.Add(black_fc, black_a);
            imagenColores.Add(white_fc, white_a);
            imagenColores.Add(brown_fc, brown_a);
            imagenColores.Add(pink_fc, pink_a);


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //siguiente
            indice++;
            if (indice == listaImagenes.Count) {
                indice = 0;
            }
            pictureBox2.Image = listaImagenes.ElementAt(indice);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //anterior
            indice--;
            if (indice == -1) {
                indice = listaImagenes.Count - 1;
            }
            pictureBox2.Image = listaImagenes.ElementAt(indice);
        }

        private void backB_Click(object sender, EventArgs e)
        {
            c = new Colors();
            c.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                imagenColores[listaImagenes.ElementAt(indice)].Play();
     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
