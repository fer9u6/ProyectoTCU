using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTCU
{
    public partial class Diseases2 : Form
    {
        Diseases d1;
        Dictionary<int, String> enfermedades;
        Dictionary<String, String> recomendaciones;
        List<int> usadas;
        int eActual,contadorRecomendaciones;
        bool play;
        public Diseases2()
        {
            InitializeComponent();
            enfermedades = new Dictionary<int, string>();
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

            recomendaciones = new Dictionary<string, string>();
            recomendaciones.Add("Cough", "Take cough syrup.");
            recomendaciones.Add("Toothache","Go to the dentist.");
            recomendaciones.Add("Sore throat","Drink lemon tea.");
            recomendaciones.Add("Chiken pox","Go to the doctor.");
            recomendaciones.Add("Stomachache","Drink peppermint tea.");
            recomendaciones.Add("Sunburn","Keep your skin hydrated.");
            recomendaciones.Add("Fever","Take an ibuprofen.");
            recomendaciones.Add("Headache","Take a rest.");
            // recomendaciones.Add("Take a rest.", "Headache");

            play = false;
            contadorRecomendaciones = 0;
            usadas = new List<int>();
        }

        public void mostrar()
        {
            Random rn = new Random();
            
            if (contadorRecomendaciones <= 7)
            {
                eActual = rn.Next(0, 8);
                while (usadas.Contains(eActual))
                {
                    eActual = rn.Next(0, 8);
                }
                usadas.Add(eActual);
                label1.Text = enfermedades[eActual];

                int r = rn.Next(0, 2);
                if (r == 0)
                {
                    o1.Text = recomendaciones[enfermedades[eActual]];
                    o3.Text = recomendaciones[enfermedades[rn.Next(0, 8)]];
                }
                else {
                    o3.Text = recomendaciones[enfermedades[eActual]];
                    o1.Text = recomendaciones[enfermedades[rn.Next(0, 8)]];
                }

            }
            else {
                contadorRecomendaciones = 0;
                MessageBox.Show("Game over :)");
                usadas.Clear();
                play = false;
                o1.Text = "";
                o3.Text = "";
                playButton.Visible = true;
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
                    MessageBox.Show("Correct answer");
                    contadorRecomendaciones++;
                    mostrar();
                }
                else {
                    MessageBox.Show("Bad answer");
                }

            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
            


        }
    }
}
