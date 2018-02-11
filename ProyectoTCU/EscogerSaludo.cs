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
    public partial class EscogerSaludos : Form
    {
        bool play;
        int contador, fallos, imagenA;
        List<String> timeGreetings;
        List<String> formalGreetings;
        List<String> rformalGreetings;
        List<String> rinformalGreetings;
        List<String> informalGreetings;
        List<String> byeGreetings;
        controlSonidos sonidos;
        Menu4toGrado m4;
        Mensaje mensaje;
        Dictionary<int, List<String>> respuestas; // numero de imagelist  y posibles respuestas
        String respuesta;
        List<int> imostradas = new List<int>();

        public EscogerSaludos()
        {
            InitializeComponent();
            fallos = 0;
            contador = 0;
            play = false;
            sonidos = new controlSonidos();


            timeGreetings = new List<string>();
            formalGreetings = new List<string>();
            informalGreetings = new List<string>();
            rformalGreetings = new List<string>();
            rinformalGreetings = new List<string>();
            byeGreetings = new List<string>();
            respuestas = new Dictionary<int, List<String>>();
            mensaje = new Mensaje();

            timeGreetings.Add("Good Afternoon");
            timeGreetings.Add("Good Morning");
            timeGreetings.Add("Good Night");
            timeGreetings.Add("Good Evening");
            formalGreetings.Add("Hello, how are you?");
            formalGreetings.Add("Hello! Ms Richards/Mr Richards");
            rformalGreetings.Add("Fine thank you. And you?");
            rformalGreetings.Add("Very well, thank you. And you?");
            informalGreetings.Add("Hi, how are you?");
            informalGreetings.Add("Hi, how is it going?");
            informalGreetings.Add("Hey , what's new?");
            informalGreetings.Add("Hi there, What's up?");
            rinformalGreetings.Add("Hi, I am good. How are you?");
            rinformalGreetings.Add("Hi! , great. And you?");
            rinformalGreetings.Add("I am doing all right. And you?");
            byeGreetings.Add("Bye");
            byeGreetings.Add("See you later");
            respuestas.Add(0, timeGreetings);
            respuestas.Add(1, timeGreetings);
            respuestas.Add(2, timeGreetings);
            respuestas.Add(3, timeGreetings);
            respuestas.Add(4, timeGreetings);
            respuestas.Add(5, formalGreetings);
            respuestas.Add(6, formalGreetings);
            respuestas.Add(7, formalGreetings);
            respuestas.Add(8, formalGreetings);
            respuestas.Add(9, formalGreetings);
            respuestas.Add(10, informalGreetings);
            respuestas.Add(11, informalGreetings);
            respuestas.Add(12, informalGreetings);
            respuestas.Add(13, informalGreetings);
            respuestas.Add(14, rinformalGreetings);
            respuestas.Add(15, rformalGreetings);
            respuestas.Add(16, rinformalGreetings);
            respuestas.Add(17, rinformalGreetings);
            respuestas.Add(18, byeGreetings);
            respuestas.Add(19, byeGreetings);

            instrucciones();

        }

        private void TiposdeSaludos_Load(object sender, EventArgs e)
        {

        }

        public void instrucciones() {
            mensaje.neutralMensaje("Choose the correct option \n according to the situation");
        }
        public void mostrarInicio()
        {
            const string message =
      "In this game you have to choose the correct greeting for each situation";
            const string caption = "Form Closing";
            if (this.Visible == true)
            {
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                }
            }
        }


        private void mostrarImagen()
        {
            pictureBoxRespuesta.Image = null;
            Random rn = new Random();
            imagenA = rn.Next(0, imageList1.Images.Count);
            while (imostradas.Contains(imagenA))
            {
                imagenA = rn.Next(0, imageList1.Images.Count);
            }
            pictureBox1.Image = imageList1.Images[imagenA];
            imostradas.Add(imagenA);

            //opciones de respuestas
            int op1 = rn.Next(0, formalGreetings.Count);
            int op2 = rn.Next(0, rinformalGreetings.Count);
            int op3 = rn.Next(0, rformalGreetings.Count);
            int op4 = rn.Next(0, informalGreetings.Count);
            int op5 = rn.Next(0, byeGreetings.Count);

            o2.Text = rinformalGreetings[op2];

            List<String> l = respuestas[imagenA];
            if (l == formalGreetings || l == rformalGreetings)
            {
                labelpista.Text = "Formal";
            }
            else
            {
                if (l == informalGreetings || l == rinformalGreetings)
                {
                    labelpista.Text = "Informal";
                }
                else
                {
                    labelpista.Text = ". . .";
                }
            }

            if (imagenA <= 4)//saludos tiempo
            {
                if (imagenA < 3)
                {//buenas noches
                    o3.Text = "Good Night";
                    o1.Text = "Good Morning";
                    o4.Text = formalGreetings[op1];
                }
                else
                {
                    if (imagenA == 3) { o3.Text = "Good Morning"; o4.Text = "Good Evening"; }
                    if (imagenA == 4) { o4.Text = "Good Afternoon"; o3.Text = "Good Night"; }
                }
            }
            else
            {
                o1.Text = formalGreetings[op1];
                o3.Text = rformalGreetings[op3];
                o4.Text = informalGreetings[op4];
            }
            if (imagenA >= 18)
            {
                o4.Text = byeGreetings[op5];
                o1.Text = formalGreetings[op1];
                o3.Text = rformalGreetings[op3];
            }

        }

        private void validar()
        {
            contador++;
            List<String> l = respuestas[imagenA];
            bool resultado = false;
            if (l.Contains(respuesta) && l != timeGreetings) { resultado = true; }
            if (imagenA < 5)
            { //saludo de tiempo
                if (imagenA < 3)
                {
                    if (respuesta == "Good Night" || respuesta == "Good Evening")
                    {
                        resultado = true;
                    }
                }
                if (imagenA == 3 && respuesta == "Good Morning") { resultado = true; }
                if (imagenA == 4 && respuesta == "Good Afternoon") { resultado = true; }
            }

            if (resultado == true)
            {
                //const string message = "correct answer";
                //const string caption = "";
                //MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                pictureBoxRespuesta.Image = Properties.Resources.check;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();

            }
            else
            {
                //const string message =
                //"fail";
                //const string caption = "";
                //MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                pictureBoxRespuesta.Image = Properties.Resources.equis;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();

                fallos += 1;
            }

            if (contador < 10 && fallos < 3)
            {
                mostrarImagen();
            }
            else
            {
                imostradas.Clear();
                String res = "";
                if (fallos == 3) {
                    //res = "You Lose , try again!";
                    mensaje.looseMesaje();
                    sonidos.sonidoPerder();
                }
                else
                {
                    //res = "Congratulations!";
                    mensaje.winMesaje();
                    sonidos.sonidoGanar();
                }

                playButton.Visible = true;
                o1.Text = "";
                o2.Text = "";
                o3.Text = "";
                o4.Text = "";
                contador = 0;
                fallos = 0;
            }
        }

        private void imagenRespuesta()
        {
            System.Threading.Thread.Sleep(1000);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (play == true)
            {
                respuesta = o2.Text;
                validar();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (play == true)
            {
                respuesta = o4.Text;
                validar();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {



        }

        private void o1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (play == true)
            {
                respuesta = b.Text;
                validar();
            }
        }

        private void o3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void o1_Click_1(object sender, EventArgs e)
        {

        }

        private void backB_Click(object sender, EventArgs e)
        {
            m4 = new Menu4toGrado();
            this.Hide();
            m4.Show();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //play
            play = true;
            playButton.Visible = false;
            mostrarImagen();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu4toGrado mp = new Menu4toGrado();
            mp.Show();
            this.Hide();
        }
    }
}
