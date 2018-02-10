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
    public partial class Diseases : Form
    {
        Menu4toGrado m4;
        Diseases2 d2;
        Dictionary<int,String> enfermedades;
        List<int> keysUsadas;
        int contador,imagenActual;
        List<Button> botones;
        bool play;
       
        public Diseases()
        {
            InitializeComponent();
            enfermedades = new Dictionary<int, string>();
            keysUsadas = new List<int>();
            botones = new List<Button>();
            contador = 0;

            botones.Add(o1);
            botones.Add(o2);
            botones.Add(o3);
            botones.Add(o4);

            enfermedades.Add(0,"Fever");
            enfermedades.Add(1, "Toothache");
            enfermedades.Add(2, "Cough");
            enfermedades.Add(3, "Chiken pox");
            enfermedades.Add(4, "Stomachache");
            enfermedades.Add(5, "Sore throat");
            enfermedades.Add(6, "Sunburn");
            enfermedades.Add(7,"Headache");
            enfermedades.Add(8,"Backache");
            enfermedades.Add(9, "Bloody nose");
            enfermedades.Add(10, "Broken arm");
            enfermedades.Add(11, "Bruise");
            enfermedades.Add(12, "Cut");
            enfermedades.Add(13,"Insect bite");

        }

        private void backB_Click(object sender, EventArgs e)
        {
            m4 = new Menu4toGrado();
            this.Hide();
            m4.Show();
        }

        public void asignar()
        {
            Random rn = new Random();
            int key = 0;
            if (contador < enfermedades.Count)
            {
               key = rn.Next(0, imageListEnfermedades.Images.Count);
                while (keysUsadas.Contains(key)) {
                    key = rn.Next(0, imageListEnfermedades.Images.Count);
                }

                keysUsadas.Add(key);
                imagenActual = key;
                pictureBox1.Image = imageListEnfermedades.Images[key];
                //opciones
                //para que no se repitan se hace una lista provicional llamada opciones
                List<int> opciones;
                opciones = new List<int>();
                int o = rn.Next(0, enfermedades.Count);
                for (int i = 0; i < 4; i++)
                {
                    while (opciones.Contains(o) || o == key)
                    {
                        o = rn.Next(0, enfermedades.Count);
                    }
                    opciones.Add(o);
                }
                o1.Text = enfermedades[opciones[0]];//cualquier string 
                o2.Text = enfermedades[opciones[1]];//cualquier string 
                o3.Text = enfermedades[opciones[2]];//cualquier string 
                o4.Text = enfermedades[opciones[3]];//cualquier string 
                botones[rn.Next(0, botones.Count)].Text = enfermedades[key]; //el string elegido
            }
            else
            {
                MessageBox.Show("Game over :)");
                playButton.Visible = true;
                contador = 0;
                foreach (Button b in botones) {
                    b.Text = "";
                }
                play = false;
                keysUsadas.Clear();
            }
           




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
            play = true;
            asignar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d2 = new Diseases2();
            this.Hide();
            d2.Show();
        }

        private void o1_Click(object sender, EventArgs e)
        {
            if (play == true)
            {
                Button b = sender as Button;
                if (b.Text == enfermedades[imagenActual])
                {
                    MessageBox.Show("Correct Answer");
                    contador++;
                    asignar();
                }
                else
                {
                    MessageBox.Show("Bad Answer");
                }
            }
        }
    }
}
