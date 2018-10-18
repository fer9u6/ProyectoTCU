using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ProyectoTCU
{
    public partial class Classroom : Form
    {
        /*

        Menu1erGrado m1;
        classroom2 c2;
        MenuClassroom mc;
        int pared,contador,sonidoActual,rondas;
        Dictionary<int, SoundPlayer> sonidos;
        Dictionary<int, String> palabras;
        Dictionary<int, Image> parejas;
        List<int> usados;
        List<int> sonidosAsignados;
        Mensaje mensaje;
        controlSonidos csonidos;




        public Classroom()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            sonidos = new Dictionary<int, SoundPlayer>();
            usados = new List<int>();
            parejas = new Dictionary<int, Image>();
            palabras = new Dictionary<int, String>();
            sonidosAsignados = new List<int>(); //sonidos sonidosAsignados
            mensaje = new Mensaje();
            csonidos = new controlSonidos();
            pared = 0;
            contador = 0;
            rondas = 1;
            mensaje = new Mensaje();
            labelAnswer.Text = " ";

            

            //se declaran todos los sonidos
            SoundPlayer books = new SoundPlayer(Properties.Resources.books_audio);
            SoundPlayer redbook = new SoundPlayer(Properties.Resources.red_book_audio);
            SoundPlayer colorpencils= new SoundPlayer(Properties.Resources.color_pencils_audio);
            SoundPlayer eraser = new SoundPlayer(Properties.Resources.eraser_audio);
            SoundPlayer scissors= new SoundPlayer(Properties.Resources.scissors_audio);
            SoundPlayer sharpener= new SoundPlayer(Properties.Resources.sharpener_audio);
            SoundPlayer pencil = new SoundPlayer(Properties.Resources.pencil_audio);
            SoundPlayer  glue= new SoundPlayer(Properties.Resources.glue_audio);
           // SoundPlayer = new SoundPlayer(Properties.Resources.);

            // se declaran todas las imagenes
           Bitmap ipencil = (Bitmap)Properties.Resources.pencil;
            Bitmap ibooks = (Bitmap)Properties.Resources.books;
            Bitmap iredbook = (Bitmap)Properties.Resources.redbook;
            Bitmap icolorpencils = (Bitmap)Properties.Resources.colorpencils;
            Bitmap ieraser = (Bitmap)Properties.Resources.eraser;
           Bitmap ibluescissors = (Bitmap)Properties.Resources.blue_scissors_;
            Bitmap isharpener = (Bitmap)Properties.Resources.sharpener;
            Bitmap iglue = (Bitmap)Properties.Resources.glue;

            

            //por imagenes , palabras y sonidos tienen el mismo numero
            //se asignan numeros a las palabras

            palabras.Add(0, "Books");
            palabras.Add(1, "Red Book");
            palabras.Add(2, "Color pencils");
            palabras.Add(3, "Scissors");
            palabras.Add(4, "Sherpener");
            palabras.Add(5, "Pencil");
            palabras.Add(6, "Glue");
            palabras.Add(7, "Eraser");

            

            //se asignan numeros a los audios
            sonidos.Add(0, books);
            sonidos.Add(1, redbook);
            sonidos.Add(2,colorpencils);
            sonidos.Add(3,scissors );
            sonidos.Add(4, sharpener);
            sonidos.Add(5,pencil );
            sonidos.Add(6,glue );
            sonidos.Add(7,eraser );

            //se asignan las parejas
            //numero de sonido , imagen
            parejas.Add(0,ibooks);
            parejas.Add(1,iredbook);
            parejas.Add(2,icolorpencils);
           parejas.Add(3,ibluescissors);
            parejas.Add(4,isharpener);
           parejas.Add(5,ipencil);
            parejas.Add(6,iglue);
            parejas.Add(7,ieraser);

            asignar();
            

        }

        private void backB_Click(object sender, EventArgs e)
        {
            mc = new MenuClassroom();
            this.Hide();
            mc.Show();
        }

        /*
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // picturebox para todos
            PictureBox actual = sender as PictureBox;
            Image i = actual.Image;
            if (i == parejas[sonidoActual])
            {
                //MessageBox.Show("Correct answer");
                labelAnswer.Text = palabras[sonidoActual];
                pictureBoxRespuesta.Image = Properties.Resources.check;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();
                pictureBoxRespuesta.Image = null;
                labelAnswer.Text = " ";
                contador++;
                if (contador == 5) // ya se acabo la ronda
                {
                    rondas++;
                    contador = 0;
                    sonidosAsignados.Clear();
                    if (rondas == 3)
                    {
                        //MessageBox.Show("Congratulations!! Play the next level");
                        mensaje.winMesaje();
                        csonidos.sonidoGanar();
                        siguienteNivel();


                    }
                    else
                    {
                        asignar();
                    }
                }
                else { sonidoActual = sonidosAsignados[contador]; }
            }
            else {
                //MessageBox.Show("Bad answer");
                pictureBoxRespuesta.Image = Properties.Resources.equis;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();
                labelAnswer.Text = " ";
                pictureBoxRespuesta.Image = null;
               
            }

        }
        


        private void imagenRespuesta()
        {
            System.Threading.Thread.Sleep(2000);

        }



        /**
         * Se asigna la imagen de la pared,  se asigna aparte por las caracteristicas de la imagen
         **/

            /*
        private void asignarPared() {
            if (pared == 6)
            {
                pictureboxpared.Image = parejas[0];  //0 , 6
                sonidosAsignados.Add(0);
                pared = 0;
            }
            else
            {
                pictureboxpared.Image = parejas[6];
                pared = 6;
                sonidosAsignados.Add(6);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            classroom2 c2 = new classroom2();
            this.Hide();
            c2.Show();

        }

        private void Classroom_Load(object sender, EventArgs e)
        {
           // mensaje.neutralMensaje("Listen the sound and click on the right object");
        }

        private void asignar() {
           
            Random rn = new Random();
                //se elige un sonido
                int numSonido;
            int limite = 4;
            if (rondas == 2)
            {
                limite = 2;
                for (int i = 0; i < limite; i++)
                {
                    numSonido = rn.Next(0, sonidos.Count);
                    while (usados.Contains(numSonido) || numSonido == 0 || numSonido == 6)
                    {
                        numSonido = rn.Next(0, sonidos.Count);
                    }
                    usados.Add(numSonido);
                    sonidosAsignados.Add(numSonido);
                }

                //faltan otros dos sonidos por asignar
                for (int i = 0; i < limite; i++)
                {
                    numSonido = rn.Next(0, sonidos.Count);
                    while (sonidosAsignados.Contains(numSonido) || numSonido == 0 || numSonido == 6)
                    {
                        numSonido = rn.Next(0, sonidos.Count);
                    }
                    
                    sonidosAsignados.Add(numSonido);
                }

            }
            else  // primera ronda de 4
            {
                for (int i = 0; i < limite; i++)
                {
                    numSonido = rn.Next(0, sonidos.Count);
                    while (usados.Contains(numSonido) || numSonido == 0 || numSonido == 6)
                    {
                        numSonido = rn.Next(0, sonidos.Count);
                    }
                    usados.Add(numSonido);
                    sonidosAsignados.Add(numSonido);
                }
            }

            //numSonido es el numero de sonido a usar y asi se elige la imagen
            //solo puede ser goma o libros;
            sonidoActual = sonidosAsignados[0];//primer sonido

            pictureBox1g.Image = parejas[sonidosAsignados[0]] ;  //1,2,5
            pictureBox2peque.Image = parejas[sonidosAsignados[1]];     //7,6,4,3
            pictureBox3g.Image = parejas[sonidosAsignados[2]];
            pictureBox4peque.Image = parejas[sonidosAsignados[3]];

            asignarPared();
            for (int i = 0; i < sonidosAsignados.Count; i++)
            {
                int var = sonidosAsignados[i];
            }

        }
        private void siguienteNivel() {
            c2 = new classroom2();
            this.Hide();
            if (mensaje.getState() == false)
            {
                c2.Show();
                mensaje.neutralMensaje("Listen the sound and click on the right object.");
            }
            else {
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();

                c2.Show();
                mensaje.neutralMensaje("Listen the sound and click on the right object.");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
           int sonido = sonidosAsignados[contador];
            try {
                sonidos[sonido].Play();
              
              
            } catch(Exception ex) {
                MessageBox.Show("Error "+ ex.Message);
           }
        }

        */

    }
}
