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
    public partial class Neighborhood : Form
    {
        Menu1erGrado m1;
        MenuNeighborhood mn;
        Dictionary<String, String> preguntasRespuestas;
        int contador;
        int actual;
        Mensaje mensaje;
        controlSonidos sonidos;
        List<int> usadas;
        public Neighborhood()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            preguntasRespuestas = new Dictionary<string, string>();
            usadas = new List<int>();
            mensaje = new Mensaje();
            sonidos = new controlSonidos();

            preguntasRespuestas.Add("Where is the park?","Between the fire station and the bakery.");
            preguntasRespuestas.Add("Where is the restaurant?","Behind the supermarket.");
            preguntasRespuestas.Add("Where is the school?","Next to the hardware store.");
            preguntasRespuestas.Add("Where is the gas station?","Across from the school.");
            preguntasRespuestas.Add("Where is the supermarket?", "On the corner of Main street and Apple street.");
            preguntasRespuestas.Add("Where is the pet shop?","In front of the bus stop.");
            preguntasRespuestas.Add("Where is the bus stop?","Behind the pet shop.");
            preguntasRespuestas.Add("Where is the police station?","Far from the gym.");
            preguntasRespuestas.Add("Where is the book store?","Near to the park.");
            preguntasRespuestas.Add("Where is the hospital?","Next to the drug store.");

            contador = 0;
            o1.Text = "";
            o2.Text = "";

            mostrarPregunta();
        }

        private void backB_Click(object sender, EventArgs e)
        {
            mn = new MenuNeighborhood();
            this.Hide();
            mn.Show();
        }

        private void mostrarPregunta() {
            Random rn = new Random();
            if (contador < preguntasRespuestas.Count)
            {
                actual = rn.Next(0, preguntasRespuestas.Count);
                while (usadas.Contains(actual))
                {
                    actual = rn.Next(0, preguntasRespuestas.Count);
                }
                usadas.Add(actual);
                labelquestion.Text = preguntasRespuestas.ElementAt(actual).Key;

                int butones = rn.Next(0, 2);
                if (butones == 0)
                {
                    o1.Text = preguntasRespuestas[preguntasRespuestas.ElementAt(actual).Key];
                    o2.Text = preguntasRespuestas[preguntasRespuestas.ElementAt(rn.Next(0, preguntasRespuestas.Count)).Key];
                }
                else
                {
                    o2.Text = preguntasRespuestas[preguntasRespuestas.ElementAt(actual).Key];
                    o1.Text = preguntasRespuestas[preguntasRespuestas.ElementAt(rn.Next(0, preguntasRespuestas.Count)).Key];
                }
            }
            else {
                //MessageBox.Show("Game over :)");
                mensaje.winMesaje();
                sonidos.sonidoGanar();
                contador = 0;
                o1.Text = "";
                o2.Text = "";
            }

        }

        private void o1_Click(object sender, EventArgs e)
        {
            if (contador < preguntasRespuestas.Count)
            {
                //validar
                Button b = sender as Button;
                if (b.Text == preguntasRespuestas[preguntasRespuestas.ElementAt(actual).Key])
                {
                    // MessageBox.Show("correct answer");
                    pictureBoxRespuesta.Image = Properties.Resources.check;
                    sonidos.sonidoOpcionCorrecta();
                    Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                    taskA.Wait();
                    pictureBoxRespuesta.Image = null;
                    contador++;
                    mostrarPregunta();
                }
                else
                {
                    // MessageBox.Show("bad answer");
                    pictureBoxRespuesta.Image = Properties.Resources.equis;
                    sonidos.sonidoPerderSebastian();
                    Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                    taskA.Wait();
                    pictureBoxRespuesta.Image = null;
                }
            }
        }

        private void imagenRespuesta()
        {
            System.Threading.Thread.Sleep(2000);

        }

        private void Neighborhood_Load(object sender, EventArgs e)
        {

        }

        private void labelquestion_Click(object sender, EventArgs e)
        {

        }
    }
}
