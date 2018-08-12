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
    public partial class funcionesOrganos : Form
    {
        Dictionary<String,String> parejas;
        Dictionary<String, SoundPlayer> sonidos;
        List<int> iParejasUsadas;
        int fallos,iactual;
        Mensaje mensaje;
        controlSonidos sonido;
        int contador = 0;

        public funcionesOrganos()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            parejas = new Dictionary<String, string>();
            sonidos = new Dictionary<string, SoundPlayer>();
            parejas.Add("4", "It finishes the process of digesting food.\nIt absorbs water and salts.");
            parejas.Add("6", "It allows you to breathe.\nIt helps you to inhale and \nexhale the air.");
            parejas.Add("3","It cleans your blood.\nIt produces an important digestive liquid called bile.\nIt stores energy in the form of a sugar called glycogen.");
            parejas.Add("1","It is the boss of your body.\nIt controls everything you do, \neven when you are asleep.");
            parejas.Add("7","It stores the food you eat. \n" +
                "It breaks down the food into a liquid mixture to slowly \nempty that liquid mixture into the small intestine.");
            parejas.Add("2","It sends blood around your body.\nThe blood provides the oxygen and nutrients it needs.\nIt also carries away waste. ");
            parejas.Add("5","It filters waste out of your blood.");

            sonidos.Add("1", new SoundPlayer(Properties.Resources.itistheboss_audio));
            sonidos.Add("2", new SoundPlayer(Properties.Resources.itsends_audio));
            sonidos.Add("3", new SoundPlayer(Properties.Resources.itcleans_audio));
            sonidos.Add("4", new SoundPlayer(Properties.Resources.itfinishes_audio));
            sonidos.Add("5", new SoundPlayer(Properties.Resources.itfilters_audio));
            sonidos.Add("6", new SoundPlayer(Properties.Resources.itallowsyou_audio));
            sonidos.Add("7", new SoundPlayer(Properties.Resources.itstores_audio));

            fallos = 0;
            contador = 0;
            mensaje = new Mensaje();
            sonido = new controlSonidos();
            iParejasUsadas = new List<int>();

            label1.Text = ".  .   .   .";

        }

        public void mostrar() {
            Random rn = new Random();
            pictureBoxRespuesta.Image = null;
            if (contador < parejas.Count && fallos < 3)
            {
                iactual = rn.Next(0, parejas.Count);
                while (iParejasUsadas.Contains(iactual))
                {
                    iactual = rn.Next(0, parejas.Count);
                }
                iParejasUsadas.Add(iactual);
                label1.Text = parejas[parejas.ElementAt(iactual).Key];

            }
            else { //fin de juego
                if (fallos < 3)
                {
                    mensaje.winMesaje();
                    sonido.sonidoGanar();
                }
                else {
                    mensaje.looseMesaje();
                    sonido.sonidoPerder();
                }
                iParejasUsadas.Clear();
                contador = 0;
                fallos = 0;
                label1.Text = ".  .   .   .";
                playButton.Visible = true;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //validar
            Button b = sender as Button;
            if (b.Text == parejas.ElementAt(iactual).Key)
            {
                sonido.sonidoOpcionCorrecta();
                pictureBoxRespuesta.Image = Properties.Resources.check;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();

            }
            else {
                fallos++;
                sonido.sonidoPerderSebastian();
                pictureBoxRespuesta.Image = Properties.Resources.equis;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();
            }
            contador++;
            mostrar();
        }

        private void imagenRespuesta()
        {
            System.Threading.Thread.Sleep(1000);

        }

        private void backB_Click(object sender, EventArgs e)
        {
            Menu5toGrado m5 = new Menu5toGrado();
            this.Hide();
            m5.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mostrar();
            playButton.Visible = false;
            
        }

        private void audio_Button_Click(object sender, EventArgs e)
        {
            try
            {
                sonidos[parejas.ElementAt(iactual).Key].Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
