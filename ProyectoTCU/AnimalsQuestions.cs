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
    public partial class AnimalsQuestions : Form
    {
        Animals animals;
        Dictionary<int, Image> farmAnimals;
        Dictionary<int, Image> petsAnimals;
        Dictionary<int, Image> forestAnimals;
        Dictionary<int, Image> articAnimals;
        Dictionary<int, Image> savannahAnimals;
        Dictionary<int, Image> habitats;
        Dictionary<int, SoundPlayer> sonidos;
        Dictionary<int, String> words;
        controlSonidos sounds;
        List<int> used;
        int habitat,questionsCounter,currentImage;
        Random r;

        public AnimalsQuestions()
        {
            InitializeComponent();
            used = new List<int>();
            sounds = new controlSonidos();
            farmAnimals = new Dictionary<int, Image>();
            petsAnimals = new Dictionary<int, Image>();
            forestAnimals = new Dictionary<int, Image>();
            articAnimals = new Dictionary<int, Image>();
            savannahAnimals = new Dictionary<int, Image>();
            habitats = new Dictionary<int, Image>();
            sonidos = new Dictionary<int, SoundPlayer>();
            words = new Dictionary<int, string>();
            habitat = 1;
            questionsCounter = 1;
            r = new Random();

            farmAnimals.Add(1, Properties.Resources.farm);
            farmAnimals.Add(2, Properties.Resources.cowO);
            farmAnimals.Add(3, Properties.Resources.horseO);
            farmAnimals.Add(4, Properties.Resources.pigO);
            farmAnimals.Add(5, Properties.Resources.duckO);
            farmAnimals.Add(6, Properties.Resources.chickenO);
            farmAnimals.Add(7, Properties.Resources.gooseO);
            farmAnimals.Add(8, Properties.Resources.sheepO);
            petsAnimals.Add(9, Properties.Resources.pets);
            petsAnimals.Add(10, Properties.Resources.dogO);
            petsAnimals.Add(11, Properties.Resources.catO);
            petsAnimals.Add(12, Properties.Resources.tortoiseO);
            petsAnimals.Add(13, Properties.Resources.hamsterO);
            petsAnimals.Add(14, Properties.Resources.rabbitO);
            forestAnimals.Add(15, Properties.Resources.Forest);
            forestAnimals.Add(16, Properties.Resources.wolfO);
            forestAnimals.Add(17, Properties.Resources.tigerO);
            forestAnimals.Add(18, Properties.Resources.bearO);
            forestAnimals.Add(19, Properties.Resources.monkeyO);
            forestAnimals.Add(20, Properties.Resources.deerO);
            forestAnimals.Add(21, Properties.Resources.snakeO);
            savannahAnimals.Add(22, Properties.Resources.savannah);
            savannahAnimals.Add(23, Properties.Resources.lionO);
            savannahAnimals.Add(24, Properties.Resources.zebraO);
            savannahAnimals.Add(25, Properties.Resources.hippoO);
            savannahAnimals.Add(26, Properties.Resources.rhinoO);
            savannahAnimals.Add(27, Properties.Resources.elephantO);
            savannahAnimals.Add(28, Properties.Resources.giraffeO);
            savannahAnimals.Add(29, Properties.Resources.crocodileO);


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

            words.Add(1, "farm");
            words.Add(2, "cow");
            words.Add(3, "horse");
            words.Add(4, "pig");
            words.Add(5, "duck");
            words.Add(6,"chicken");
            words.Add(7, "goose");
            words.Add(8, "sheep");
            words.Add(9, "pets");
            words.Add(10, "dog");
            words.Add(11,"cat");
            words.Add(12, "tortoise");
            words.Add(13,"hamster");
            words.Add(14, "rabbit");
            words.Add(15, "forest");
            words.Add(16, "wolf");
            words.Add(17, "tiger");
            words.Add(18, "bear");
            words.Add(19, "monkey");
            words.Add(20, "deer");
            words.Add(21, "snake");
            words.Add(22, "savannah");
            words.Add(23, "lion");
            words.Add(24, "zebra");
            words.Add(25, "hippo");
            words.Add(26, "rhino");
            words.Add(27, "elephant");
            words.Add(28, "giraffe");
            words.Add(29, "crocodile");

            labelQuestion.Text = "This is a __________________.";
            pictureBoxRespuesta.Image = null;
            pictureBox1.Image = null;
            button1Answer.Text = "  __  ";
            button2Answer.Text = "  __  ";
            labelQuestion.Text = "";
            mostrar();
        }

       

        private void mostrar()
        {
            //  farm    2,8                    pets    10,14
            //  forest  15,2                   savannah  23,29
            if (questionsCounter <= 12)
            {
                //asing the image
                switch (habitat)
                {
                    case 1:
                        currentImage = r.Next(2, 9);
                        while (used.Contains(currentImage)) {
                            currentImage = r.Next(2, 9);
                        }
                        pictureBox1.Image = farmAnimals[currentImage];
                        break;
                    case 2:
                        currentImage = r.Next(10, 15);
                        while (used.Contains(currentImage))
                        {
                            currentImage = r.Next(10, 15);
                        }
                        pictureBox1.Image = petsAnimals[currentImage];
                        break;
                    case 3:
                        currentImage = r.Next(16, 22);
                        while (used.Contains(currentImage))
                        {
                            currentImage = r.Next(16, 22);
                        }
                        pictureBox1.Image = forestAnimals[currentImage];
                        break;
                    case 4:
                        currentImage = r.Next(23, 30);
                        while (used.Contains(currentImage))
                        {
                            currentImage = r.Next(23, 30);
                        }
                        pictureBox1.Image = savannahAnimals[currentImage];
                        break;
                }
                used.Add(currentImage);
                //posible answers
                int badAnswer = r.Next(2, 30);
                while (badAnswer == currentImage || badAnswer==9 || badAnswer == 22 || badAnswer == 16)
                {
                    badAnswer = r.Next(2, 30);
                }
                int b = r.Next(1, 3); //integers 1-2
                if (b == 1)
                { // the correct answer is in button 1
                    button1Answer.Text = words[currentImage];
                    button2Answer.Text = words[badAnswer];
                }
                else
                {
                    button2Answer.Text = words[currentImage];
                    button1Answer.Text = words[badAnswer];
                }
                habitat++;
                if (habitat == 5)
                {
                    habitat = 1;
                }
                questionsCounter++;
            }
            else {
                //fin
                pictureBox1.Image = null;
                playButton.Show();
                pictureBoxRespuesta.Image = null;
                pictureBox1.Image = null;
                button1Answer.Text = "  __  ";
                button2Answer.Text = "  __  ";
                labelQuestion.Text = "";

            }
           

        }

        private void backB_Click(object sender, EventArgs e)
        {
            animals = new Animals();
            this.Hide();
            animals.Show();
        }

        private void button1Answer_Click(object sender, EventArgs e)
        {
            //verify

            if (questionsCounter <= 12)
            {
                Button b = sender as Button;
                if (b.Text == words[currentImage])
                {
                    //correct
                    sounds.sonidoGanarSebastian();
                    try
                    {
                        sonidos[currentImage].Play();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message);
                    }
                    pictureBoxRespuesta.Image = Properties.Resources.check;
                    Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                    taskA.Wait();
                }
                else
                {
                    //bad
                    sounds.sonidoPerder();
                    pictureBoxRespuesta.Image = Properties.Resources.equis;
                    Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                    taskA.Wait();
                }
                pictureBoxRespuesta.Image = null;
                mostrar();
            }
            else {
               
                playButton.Show();
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            playButton.Hide();
            used.Clear();
            habitat = 1;
            questionsCounter = 1;
            b.Hide();
            mostrar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imagenRespuesta()
        {
            System.Threading.Thread.Sleep(1000);

        }
    }
}
