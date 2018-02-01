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

                //List<int>botonesUsados;
                //botonesUsados = new List<int>();
                //int indiceBotones = 0;
                //for (int i = 0; i < botones.Count; i++)
                //{
                //    indiceBotones= rn.Next(0, botones.Count);
                //    while (botonesUsados.Contains(indiceBotones))
                //    {
                //        indiceBotones =rn.Next(0, botones.Count);
                //    }
                //    botonesUsados.Add(indiceBotones);
                //}
                //for (int i = 0; i < botones.Count-1; i++) {
                //    //botones[botonesUsados[i]].Text = 
                //    }
                o1.Text = enfermedades[rn.Next(0, enfermedades.Count)];//cualquier string 
                o2.Text = enfermedades[rn.Next(0, enfermedades.Count)];//cualquier string 
                o3.Text = enfermedades[rn.Next(0, enfermedades.Count)];//cualquier string 
                o4.Text = enfermedades[rn.Next(0, enfermedades.Count)];//cualquier string 
                botones[rn.Next(0, botones.Count)].Text = enfermedades[key];
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
