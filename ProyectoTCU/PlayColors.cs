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
    public partial class PlayColors : Form
    {
        Colors c;
        Mensaje mensaje;
        Instructions instructions;
        bool isDragging,play;
        int yposition, xpuffle, ypuffle,stoolSize;
        int colorActual,numRonda,numIntento;  //4 rondas en total  
        int xstand1,xstand2,xstand3; //posicion x de los 3 stands;
        Dictionary<String, SoundPlayer> sonidos;
        Dictionary<Image,string> puffles;
        Dictionary<string,Image> puffles1;
        Dictionary<int,string> colores;
        List<int> usados;
        List<int> coloresActuales;
        Dictionary<Color,string> standsColors;
        Point pp1, pp2, pp3;
        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        public PlayColors()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            instructions = new Instructions();
            this.Closed += (s, ev) => Application.Exit();
            yposition = pictureBoxstool1.Location.Y;  //posicion de los stands
            xstand1 = pictureBoxstool1.Location.X;
            xstand2 = pictureBoxstool2.Location.X;
            xstand3 = pictureBoxstool3.Location.X;
            stoolSize = pictureBoxstool1.Size.Height;
            xpuffle = pictureBoxpuffle1.Location.X;  // incremento de
            ypuffle = pictureBoxpuffle1.Location.Y;  //incrmento 
            mensaje = new Mensaje();
            sonidos = new Dictionary<string, SoundPlayer>();
            puffles = new Dictionary<Image,String>();
            puffles1 = new Dictionary<string, Image>();
            colores = new Dictionary<int, string>();
            usados = new List<int>();
            coloresActuales = new List<int>();
            standsColors = new Dictionary<Color, string>();
            play = false;
            numRonda = 0;
            numIntento = 0;
            pp1 = pictureBoxpuffle1.Location; //se ocupan para devolverlos a su posicion inicial
            pp2 = pictureBoxpuffle2.Location;
            pp3 = pictureBoxpuffle3.Location;
            pictureBoxstool1.BackColor = Color.Black;
            pictureBoxstool2.BackColor = Color.Black;
            pictureBoxstool3.BackColor = Color.Black;
          
         


            //Estructuras
            sonidos.Add("blue", new SoundPlayer(Properties.Resources.blue_audio));
            sonidos.Add("yellow", new SoundPlayer(Properties.Resources.yellow_audio));
            sonidos.Add("red", new SoundPlayer(Properties.Resources.red_audio));
            sonidos.Add("black", new SoundPlayer(Properties.Resources.black_audio));
            sonidos.Add("white", new SoundPlayer(Properties.Resources.white_audio));
            sonidos.Add("gray", new SoundPlayer(Properties.Resources.gray_audio));
            sonidos.Add("green", new SoundPlayer(Properties.Resources.green_audio));
            sonidos.Add("orange", new SoundPlayer(Properties.Resources.orange_audio));
            sonidos.Add("purple", new SoundPlayer(Properties.Resources.purple_audio));
            sonidos.Add("brown", new SoundPlayer(Properties.Resources.brown_audio));
            sonidos.Add("pink", new SoundPlayer(Properties.Resources.pink_audio));

            Bitmap iblue = (Bitmap)Properties.Resources.blue_puffle;
            Bitmap ired = (Bitmap)Properties.Resources.red_puffle_m;
            Bitmap iyellow = (Bitmap)Properties.Resources.yellow_puffle_medium;
            Bitmap iblack = (Bitmap)Properties.Resources.black_puffle;
            Bitmap iwhite = (Bitmap)Properties.Resources.white_puffle_medium;
            Bitmap igray = (Bitmap)Properties.Resources.gray_puffle;
            Bitmap iorange = (Bitmap)Properties.Resources.orange_Puffle_medium;
            Bitmap ipurple = (Bitmap)Properties.Resources.purple_puffle_medium;
            Bitmap igreen = (Bitmap)Properties.Resources.green_puffle_medium;
            Bitmap ipink = (Bitmap)Properties.Resources.pink_puffle_medium;
            Bitmap ibrown = (Bitmap)Properties.Resources.brown_Puffle_medium;

            puffles1.Add("blue", iblue);
            puffles1.Add("yellow",iyellow);
            puffles1.Add("red",ired);
            puffles1.Add("black", iblack);
            puffles1.Add("white",iwhite);
            puffles1.Add("gray",igray);
            puffles1.Add("green",igreen);
            puffles1.Add("orange",iorange);
            puffles1.Add("purple",ipurple);
            puffles1.Add("brown",ibrown);
            puffles1.Add("pink",ipink);
            puffles1.Add("saddlebrown", ibrown);


            puffles.Add(iblue,"blue");
            puffles.Add(iyellow,"yellow");
            puffles.Add(ired,"red");
            puffles.Add(iblack,"black");
            puffles.Add(iwhite,"white");
            puffles.Add(igray,"gray");
            puffles.Add(igreen,"green");
            puffles.Add(iorange,"orange");
            puffles.Add(ipurple,"purple");
            puffles.Add(ibrown,"brown");
            puffles.Add(ipink,"pink");

            colores.Add(0,"blue");
            colores.Add(1,"brown");
            colores.Add(2,"red");
            colores.Add(3,"yellow");
            colores.Add(4,"orange");
            colores.Add(5,"gray");
            colores.Add(6,"white");
            colores.Add(7,"black");
            colores.Add(8,"purple");
            colores.Add(9,"green");
            colores.Add(10,"pink");
            //colores.Add(11, "saddlebrown");

            standsColors.Add(Color.Blue, "blue");
            standsColors.Add(Color.Red, "red");
            standsColors.Add(Color.Yellow, "yellow");
            standsColors.Add(Color.Green, "green");
            standsColors.Add(Color.Orange, "orange");
            standsColors.Add(Color.Purple, "purple");
            standsColors.Add(Color.Black, "black");
            standsColors.Add(Color.White, "white");
            standsColors.Add(Color.Gray, "gray");
            standsColors.Add(Color.Brown, "brown");
            standsColors.Add(Color.Pink, "pink");
            standsColors.Add(Color.SaddleBrown, "brown");



        }

        private void mostrar()
        {
            switch (numRonda)
            {
                case 0:
                    pictureBoxpuffle1.Image = puffles1["red"];
                    pictureBoxpuffle2.Image = puffles1["blue"];
                    pictureBoxpuffle3.Image = puffles1["yellow"];
                    pictureBoxstool1.BackColor = Color.FromName("red");
                    pictureBoxstool2.BackColor = Color.FromName("blue");
                    pictureBoxstool3.BackColor = Color.FromName("yellow");
                    usados.Add(0);
                    usados.Add(2);
                    usados.Add(3);
                    break;
                case 1:
                    pictureBoxpuffle1.Image = puffles1["black"];
                    pictureBoxpuffle2.Image = puffles1["gray"];
                    pictureBoxpuffle3.Image = puffles1["white"];
                    pictureBoxstool1.BackColor = Color.FromName("black");
                    pictureBoxstool2.BackColor = Color.FromName("gray");
                    pictureBoxstool3.BackColor = Color.FromName("white");
                    usados.Add(5);
                    usados.Add(6);
                    usados.Add(7);
                    break;
                case 2:
                    pictureBoxpuffle1.Image = puffles1["orange"];
                    pictureBoxpuffle2.Image = puffles1["purple"];
                    pictureBoxpuffle3.Image = puffles1["green"];
                    pictureBoxstool1.BackColor = Color.FromName("orange");
                    pictureBoxstool2.BackColor = Color.FromName("purple");
                    pictureBoxstool3.BackColor = Color.FromName("green");
                    usados.Add(4);
                    usados.Add(9);
                    usados.Add(8);
                    break;
                case 3:
                    pictureBoxpuffle1.Image = puffles1["pink"];
                    pictureBoxpuffle2.Image = puffles1["saddlebrown"];
                    pictureBoxpuffle3.Image = puffles1["black"];
                    pictureBoxstool1.BackColor = Color.FromName("pink");
                    pictureBoxstool2.BackColor = Color.FromName("saddlebrown");
                    pictureBoxstool3.BackColor = Color.FromName("black");
                    usados.Add(1);
                    usados.Add(10);
                    usados.Add(7);
                    break;

            }

            
            pictureBoxpuffle1.Location = pp1;
            pictureBoxpuffle2.Location = pp2;
            pictureBoxpuffle3.Location = pp3;
            elegirColor();
        }

        private void PlayColors_Load(object sender, EventArgs e)
        {

        }

        private void elegirColor()
        {
            //elige de la lista de usados los ultimos 3 numeros
            Random rn = new Random();
            int  i = rn.Next(0,3); //0-2
            int color= usados[i];   //en usados esta el numero identificador del los colores elegidos para la actual ronda
            while (coloresActuales.Contains(color))    //en colores actuales estan los colores que han usado en la ronda
            {
                i = rn.Next(0, 3);
                color = usados[i];
            }
            coloresActuales.Add(color);
            colorActual = color;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //sonido del color 
            if (play == true)
            {
                try
                {
                    sonidos[(colores[colorActual])].Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //play
            play = true;
            mostrar();
            button1.Hide();
            
        }

        private void pictureBoxpuffle1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
        }

        private void backB_Click(object sender, EventArgs e)
        {
            c = new Colors();
            c.Show();
            this.Hide();

        }

        private void pictureBoxpuffle1_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (isDragging) {
                Point p1 = ctrl.PointToScreen(e.Location);  // origen del movimiento
                Point p2 = ctrl.Parent.PointToClient(p1);   //fin del movimiento
                ctrl.Location = p2;

            }
        }

        /*
         * En este metodo se valora la posicion en la que el usuario dejo el objeto que arastro 
         */
        private void pictureBoxpuffle1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            Control ctrl = sender as Control;
            PictureBox stand = new PictureBox();
            PictureBox checkpicture = new PictureBox();
            if (ctrl.Location.Y > yposition - 120 && ctrl.Location.Y <= yposition + 100)// <= <=
            {
                Point p1 = ctrl.PointToScreen(e.Location);  //origen del movimiento
                Point p2 = ctrl.Parent.PointToClient(p1);   //fin del movimiento
                p2.Y = yposition -80;
                if (ctrl.Location.X > xstand1) {
                    p2.X = xstand1 + 10;
                    stand = pictureBoxstool1;
                    checkpicture = pictureBoxcheck1;
                }
                if (ctrl.Location.X > xstand2)
                {
                    p2.X = xstand2 + 10;
                    stand = pictureBoxstool2;
                    checkpicture = pictureBoxcheck2;
                }
                if (ctrl.Location.X > xstand3)
                {
                    p2.X = xstand3 + 10;
                    stand = pictureBoxstool3;
                    checkpicture = pictureBoxcheck3;
                }

                ctrl.Location = p2;    //se coloca la imagen en el centro del stand
            }
            PictureBox p = sender as PictureBox;
            Image im=p.Image;
            if (play || standsColors.ContainsKey(stand.BackColor))
            {
                validar(p, stand, checkpicture);
            }
        }

        private void validar(PictureBox p, PictureBox stand, PictureBox checkp)
        {
            //comprueba si el puffle colocado corresponde al color y al stand
            bool valido = false;
            String color;
           // p.Image = Properties.Resources.backpack;
            if (puffles.ContainsKey(p.Image)) 
            {
                color = puffles[p.Image];
            }
            else {
                color = "";
            }
            if (color == colores[colorActual])
            {
                if (standsColors.ContainsKey(stand.BackColor))
                {
                    Color prueba = stand.BackColor;
                    if (standsColors[stand.BackColor] == color)
                    {
                        valido = true;

                    }
                }
            }
            if (valido)
            {
                checkp.Image = Properties.Resources.check;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();
                checkp.Image = null;
                numIntento++;
                if (numIntento == 3)
                { //se cambia de ronda
                    numIntento = 0;
                    usados.Clear();
                    coloresActuales.Clear();
                    numRonda++;
                    if (numRonda == 4)
                    {
                        numRonda = 0;
                        fin();
                    }
                    else {
                        mostrar();
                    }   
                }
                else {
                    elegirColor();
                } 
            }
            else {
                checkp.Image = Properties.Resources.equis;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();
                checkp.Image = null;
            }
            


        }


        private void imagenRespuesta()
        {
            System.Threading.Thread.Sleep(2000);
        }

        private void fin()
        {
            usados.Clear();
            coloresActuales.Clear();
            play = false;
            button1.Show();
        }


    }


}
