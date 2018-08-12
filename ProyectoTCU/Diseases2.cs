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
    public partial class Diseases2 : Form
    {
        Diseases d1;
        Dictionary<int, String> enfermedades;
        Dictionary<int, SoundPlayer>enfermedades_audios;
        Dictionary<String, String> recomendaciones;
        List<int> usadas;
        Mensaje mensaje;
        controlSonidos sonidos;
        int eActual,contadorRecomendaciones,fallos;
        bool play;
        public Diseases2()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            sonidos = new controlSonidos();
            enfermedades = new Dictionary<int, string>();
            enfermedades_audios = new Dictionary<int, SoundPlayer>();
            enfermedades.Add(0, "Fever");
            enfermedades.Add(1, "Toothache");
            enfermedades.Add(2, "Cough");
            enfermedades.Add(3, "Chiken pox");
            enfermedades.Add(4, "Stomachache");
            enfermedades.Add(5, "Sore throat");
            enfermedades.Add(6, "Sunburn");
            enfermedades.Add(7, "Headache");
            enfermedades.Add(8, "Backache");
            enfermedades.Add(9, "Bloody nose");
            enfermedades.Add(10, "Broken arm");
            enfermedades.Add(11, "Bruise");
            enfermedades.Add(12, "Cut");
            enfermedades.Add(13, "Insect bite");

            enfermedades_audios.Add(0, new SoundPlayer(Properties.Resources.fever_audio));
            enfermedades_audios.Add(1, new SoundPlayer(Properties.Resources.toothache_audio));
            enfermedades_audios.Add(2, new SoundPlayer(Properties.Resources.cough_audio));
            enfermedades_audios.Add(3, new SoundPlayer(Properties.Resources.chickenpox_audio));
            enfermedades_audios.Add(4, new SoundPlayer(Properties.Resources.stomachache_audio));
            enfermedades_audios.Add(5, new SoundPlayer(Properties.Resources.sorethroat_audio));
            enfermedades_audios.Add(6, new SoundPlayer(Properties.Resources.sunburn_audio));
            enfermedades_audios.Add(7, new SoundPlayer(Properties.Resources.headache_audio));
            enfermedades_audios.Add(8, new SoundPlayer(Properties.Resources.backache_audio));
            enfermedades_audios.Add(9, new SoundPlayer(Properties.Resources.bloodynose_audio));
            enfermedades_audios.Add(10, new SoundPlayer(Properties.Resources.brokenarm_audio));
            enfermedades_audios.Add(11, new SoundPlayer(Properties.Resources.bruise_audio));
            enfermedades_audios.Add(12, new SoundPlayer(Properties.Resources.cut_audio));
            enfermedades_audios.Add(13, new SoundPlayer(Properties.Resources.insectbite_audio));

            recomendaciones = new Dictionary<string, string>();
            recomendaciones.Add("Cough", "Take cough syrup.");
            recomendaciones.Add("Toothache","Go to the dentist.");
            recomendaciones.Add("Sore throat","Drink lemon tea.");
            recomendaciones.Add("Chiken pox","Go to the doctor.");
            recomendaciones.Add("Stomachache", "Do not eat junk food.");
            recomendaciones.Add("Sunburn","Keep your skin hydrated.");
            recomendaciones.Add("Fever","Take a pill.");
            recomendaciones.Add("Headache","Take a rest.");
           
            play = false;
            fallos = 0;
            contadorRecomendaciones = 0;
            usadas = new List<int>();
            mensaje = new Mensaje();
        }

        public void mostrar()
        {
            Random rn = new Random();
            pictureBoxRespuesta.Image = null;

            if (contadorRecomendaciones <= 7 && fallos <3)
            {
                eActual = rn.Next(0, 8);
                while (usadas.Contains(eActual))
                {
                    eActual = rn.Next(0, 8);
                }
                usadas.Add(eActual);
                label1.Text = enfermedades[eActual];
                try
                {
                    enfermedades_audios[eActual].Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }

                //respuesta incorrecta 
                int resIncorrecta =rn.Next(0, 8);
                while (resIncorrecta == eActual) {
                    resIncorrecta = rn.Next(0, 8);
                }

                int r = rn.Next(0, 2);
                if (r == 0)
                {
                    o1.Text = recomendaciones[enfermedades[eActual]];
                    o3.Text = recomendaciones[enfermedades[resIncorrecta]];
                }
                else {
                    o3.Text = recomendaciones[enfermedades[eActual]];
                    o1.Text = recomendaciones[enfermedades[resIncorrecta]];
                }
                //mostrar imagen de enfermedad
                pictureBox1.Image = imageListEnfermedades.Images[eActual];
            }
            else {
                if (fallos < 3)
                {
                    mensaje.winMesaje();
                    sonidos.sonidoGanar();
                    
                }
                else {
                    mensaje.looseMesaje();
                    sonidos.sonidoPerder();
                }
                contadorRecomendaciones = 0;
                usadas.Clear();
                play = false;
                o1.Text = "";
                o3.Text = "";
                playButton.Visible = true;
                fallos = 0;
            }


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            mostrar();
            playButton.Visible = false;
            play = true;
        }

        private void backB_Click(object sender, EventArgs e)
        {
            d1 = new Diseases();
            this.Hide();
            d1.Show();
        }

        private void o1_Click(object sender, EventArgs e)
        {
            //validar

            Button b = sender as Button;
            if(play == true)
            {
                if (b.Text == recomendaciones[enfermedades[eActual]])
                {
                    pictureBoxRespuesta.Image = Properties.Resources.check;
                    Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                    taskA.Wait();
                }
                else {
                    pictureBoxRespuesta.Image = Properties.Resources.equis;
                    Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                    taskA.Wait();
                    fallos++;
                }
                contadorRecomendaciones++;
                mostrar();

            }
        }

        private void imagenRespuesta()
        {
            System.Threading.Thread.Sleep(1000);

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
            


        }
    }
}
