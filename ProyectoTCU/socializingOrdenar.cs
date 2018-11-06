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
    public partial class socializingOrdenar : Form
    {
        
        Menu4toGrado m4;
        bool isDragging;
        int ypanel, fraseA, intentos, fallos, xlabel, ylabel, panelSize;
        List<Label> labels;
        List<int> frasesUsadas;
        List<String> frases;
        Mensaje mensaje;
        controlSonidos sonidos;


        public socializingOrdenar()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
            ypanel = panel1.Location.Y;
            panelSize = panel1.Size.Height;

            xlabel = label1.Location.X;  // incremento de 150
            ylabel = label1.Location.Y +50;  //incrmento 60

            labels = new List<Label>();
            frases = new List<string>();
            frasesUsadas = new List<int>();
            sonidos = new controlSonidos();

            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);

            //importante el espacio al final
            frases.Add("Hi Gina, how is it going? ");
            frases.Add("Hello Ms Jonhson, how are you? ");
            frases.Add("Nice to meet you ");
            frases.Add("Nice to meet you too ");
            frases.Add("Bye, see you later ");
            frases.Add("Hi there, this is my fiend Luke ");
            frases.Add("Hi, my name is Elizabeth ");
            frases.Add("What's his name? ");
            frases.Add("Hello, i'm Joe ");
            frases.Add("Hello, how are you? ");
         
            intentos = 0;
            fallos = 0;
            mensaje = new Mensaje();

            foreach (Label l in labels)
            {
                l.Text = "     ";
            }

        }

        private void backB_Click(object sender, EventArgs e)
        {
            m4 = new Menu4toGrado();
            this.Hide();
            m4.Show();
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {


        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (isDragging)
            {
                Point p1 = ctrl.PointToScreen(e.Location);
                Point p2 = ctrl.Parent.PointToClient(p1);
                ctrl.Location = p2;
                //p2.Y = ypanel + 50;
                //ctrl.Location = p2;

            }
        }

        private void validar()
        {
            String respuesta = "";
            SortedList<int, Label> labelsres = new SortedList<int, Label>();
            foreach (Label l in labels) {
                if (l.Location.Y == (ypanel + 50)) { // si fueron elegidas como respuestas
                    int coord = l.Location.X;
                    labelsres.Add(coord, l);

                }
            }

            foreach (KeyValuePair<int, Label> p in labelsres) {
                Label var = p.Value;
                respuesta += var.Text;
                respuesta += " ";
            }

            if (respuesta.Equals(frases[fraseA]))
            {
                //correcta
                pictureBoxRespuesta.Image = Properties.Resources.check;
               Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
               taskA.Wait();
               
               
            }
            else {
                //mala
                pictureBoxRespuesta.Image = Properties.Resources.equis;
               Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();
                

                fallos += 1;
            }
            //notificacion de buena o mala respuesta
            
            intentos += 1;

            if (intentos < 10 && fallos < 3)
            {
                mostrar();
            }
            else {
                if (fallos >= 3)
                {
                    mensaje.looseMesaje();
                    sonidos.sonidoPerder();
                    
                }
                else {
                    mensaje.winMesaje();
                    sonidos.sonidoGanar();
                }

                
                finalizarPartida();

            }


        }

        private void imagenRespuesta()
        {
            System.Threading.Thread.Sleep(1000);
  
        }

        private void finalizarPartida() {
            fallos = 0;
            intentos = 0;
            frasesUsadas.Clear();
            playButton.Visible = true;

            foreach (Label l in labels)
            {
                l.Text = "     ";
            }

        }

        private void ordenar() {
            //para poner las etiquetas en su lugar
                int o = 0;
                Point p = new Point();
                p.X = xlabel;
                p.Y = ylabel;
                foreach (Label l in labels)
                {
                    l.Text = "     ";
                    if (o < 5)
                    {
                        l.Location = p;
                        p.X += 150;
                    }
                    else
                    {
                        l.Location = p;
                        p.X += 150;
                    }
                    o++;
                    if (o == 5)
                    {
                        p.Y = ylabel + 60;
                        p.X = xlabel;
                    }
                }
            

        }

        private void mostrar() {
            ordenar();
            pictureBoxRespuesta.Image = null;
            Random rn = new Random();
            fraseA = rn.Next(0, frases.Count); // frase a mostrar

            while(frasesUsadas.Contains(fraseA)) {
                fraseA = rn.Next(0, frases.Count);
            }
            frasesUsadas.Add(fraseA);

            char espacio =' ';
            String[] partes = frases[fraseA].Split(espacio);
            int num = partes.Length;   
            List<int> labesUsadas = new List<int>();
            for(int i = 0; i < num; i++)
            {
                int lb = rn.Next(0, num);
                while (labesUsadas.Contains(lb)) {
                    lb = rn.Next(0, num+1);
                }
                labesUsadas.Add(lb);
                labels[lb].Text = partes[i];// se le asigna a un label una parte de la frase
            }

            foreach (Label l in labels) {
                if (l.Text == "     " || l.Text == "")
                {
                    l.Visible = false;
                }
                else {
                    l.Visible = true;
                }
            }


        }
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            Control ctrl = sender as Control;
            if (ctrl.Location.Y > ypanel-10 && ctrl.Location.Y <= ypanel+ 100)// <= <=
            {
                Point p1 = ctrl.PointToScreen(e.Location);
                Point p2 = ctrl.Parent.PointToClient(p1);
                p2.Y = ypanel + 50;
                ctrl.Location = p2;

            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
            mostrar();
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            validar();
        }

        private void socializingOrdenar_Load(object sender, EventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
        }

    }
}
