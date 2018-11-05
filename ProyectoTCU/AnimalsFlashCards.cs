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
    public partial class AnimalsFlashCards : Form
    {
        Animals animals;
        Dictionary<int, Image>farmAnimals;
        Dictionary<int, Image> petsAnimals;
        Dictionary<int, Image> forestAnimals;
        Dictionary<int, Image> articAnimals;
        Dictionary<int, Image> savannahAnimals;
        Dictionary<int, Image> habitats;
        Dictionary<int, SoundPlayer> sonidos;
        int ImagesCount = 29;
        int currentImage = 1;
        int farmH = 1, petsH =9, forestH =15,savannahH =22;

        public AnimalsFlashCards()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
            farmAnimals = new Dictionary<int, Image>();
            petsAnimals = new Dictionary<int, Image>();
            forestAnimals = new Dictionary<int, Image>();
            articAnimals = new Dictionary<int, Image>();
            savannahAnimals = new Dictionary<int, Image>();
            habitats = new Dictionary<int, Image>(); 
            sonidos = new Dictionary<int, SoundPlayer>();

            farmAnimals.Add(1,Properties.Resources.farm);
            farmAnimals.Add(2,Properties.Resources.cow);
            farmAnimals.Add(3, Properties.Resources.horse);
            farmAnimals.Add(4, Properties.Resources.pig);
            farmAnimals.Add(5, Properties.Resources.duck);
            farmAnimals.Add(6, Properties.Resources.chicken);
            farmAnimals.Add(7, Properties.Resources.goose);
            farmAnimals.Add(8, Properties.Resources.sheep);

            petsAnimals.Add(9, Properties.Resources.pets);
            petsAnimals.Add(10,Properties.Resources.dog);
            petsAnimals.Add(11, Properties.Resources.cat);
            petsAnimals.Add(12, Properties.Resources.tortoise);
            petsAnimals.Add(13, Properties.Resources.hamster);
            petsAnimals.Add(14,Properties.Resources.rabbit);

            forestAnimals.Add(15, Properties.Resources.Forest);
            forestAnimals.Add(16,Properties.Resources.wolf);
            forestAnimals.Add(17, Properties.Resources.tiger);
            forestAnimals.Add(18, Properties.Resources.bear);
            forestAnimals.Add(19, Properties.Resources.monkey);
            forestAnimals.Add(20,Properties.Resources.deer);
            forestAnimals.Add(21, Properties.Resources.snake);

            savannahAnimals.Add(22, Properties.Resources.savannah);
            savannahAnimals.Add(23,Properties.Resources.lion);
            savannahAnimals.Add(24, Properties.Resources.zebra);
            savannahAnimals.Add(25, Properties.Resources.hippo);
            savannahAnimals.Add(26, Properties.Resources.rhino);
            savannahAnimals.Add(27, Properties.Resources.elephant);
            savannahAnimals.Add(28, Properties.Resources.giraffe);
            savannahAnimals.Add(29, Properties.Resources.crocodile);

           // habitats.Add(26, Properties.Resources.pets);
           // habitats.Add(27, Properties.Resources.farm);
           // habitats.Add(28, Properties.Resources.Forest);
           // habitats.Add(29, Properties.Resources.savannah);

            sonidos.Add(1, new SoundPlayer(Properties.Resources.farmaudio));
            sonidos.Add(2, new SoundPlayer(Properties.Resources.cowaudio));
            sonidos.Add(3, new SoundPlayer(Properties.Resources.horseaudio));
            sonidos.Add(4, new SoundPlayer(Properties.Resources.pigaudio));
            sonidos.Add(5, new SoundPlayer(Properties.Resources.duckaudio));
            sonidos.Add(6, new SoundPlayer(Properties.Resources.chickenaudio));
            sonidos.Add(7, new SoundPlayer(Properties.Resources.gooseaudio));
            sonidos.Add(8, new SoundPlayer(Properties.Resources.sheepaudio));


            sonidos.Add(9, new SoundPlayer(Properties.Resources.petsaudio));
            sonidos.Add(10, new SoundPlayer(Properties.Resources.dogaudio));
            sonidos.Add(11, new SoundPlayer(Properties.Resources.cataudio));
            sonidos.Add(12, new SoundPlayer(Properties.Resources.tortoiseaudio));
            sonidos.Add(13, new SoundPlayer(Properties.Resources.hamsteraudio));
            sonidos.Add(14, new SoundPlayer(Properties.Resources.rabbitaudio));

            sonidos.Add(15, new SoundPlayer(Properties.Resources.forestaudio));
            sonidos.Add(16, new SoundPlayer(Properties.Resources.wolfaudio));
            sonidos.Add(17, new SoundPlayer(Properties.Resources.tigeraudio));
            sonidos.Add(18, new SoundPlayer(Properties.Resources.bearaudio));
            sonidos.Add(19, new SoundPlayer(Properties.Resources.monkeyaudio));
            sonidos.Add(20, new SoundPlayer(Properties.Resources.deeraudio));
            sonidos.Add(21, new SoundPlayer(Properties.Resources.snakeaudio));

            sonidos.Add(22, new SoundPlayer(Properties.Resources.savannahaudio));
            sonidos.Add(23, new SoundPlayer(Properties.Resources.lionaudio));
            sonidos.Add(24, new SoundPlayer(Properties.Resources.zebraaudio));
            sonidos.Add(25, new SoundPlayer(Properties.Resources.hippoaudio));
            sonidos.Add(26, new SoundPlayer(Properties.Resources.rhinoaudio));
            sonidos.Add(27, new SoundPlayer(Properties.Resources.elephantaudio));
            sonidos.Add(28, new SoundPlayer(Properties.Resources.giraffeaudio));
            sonidos.Add(29, new SoundPlayer(Properties.Resources.crocodileaudio));

            mostrar();
           
        }

        private void backB_Click(object sender, EventArgs e)
        {
            animals = new Animals();
            this.Hide();
            animals.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //sound
            try {
                sonidos[currentImage].Play();
            }
            catch (Exception ex) {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void AnimalsFlashCards_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //siguiente
            currentImage++;
            if (currentImage > ImagesCount) {
                currentImage = 1;
            }
            mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //anterior
            currentImage--;
            if (currentImage < 1)
            {
                currentImage = ImagesCount;
            }
            mostrar();
        }

        private void mostrar() {
            if (currentImage < 9)
            {
                pictureBox1.Image = farmAnimals[currentImage];
                label1.Text = "Farm Animals";
            }
            else {
                if (currentImage < 15)
                {
                    pictureBox1.Image = petsAnimals[currentImage];
                        label1.Text = "Pets Animals";
                }
                else {
                    if (currentImage < 22)
                    {
                        pictureBox1.Image = forestAnimals[currentImage];
                        label1.Text = "Forest Animals";
                    }
                    else {
                        pictureBox1.Image = savannahAnimals[currentImage];
                        label1.Text = "Savannah Animals";
                    }
                }
            }    
        }


    }
}
