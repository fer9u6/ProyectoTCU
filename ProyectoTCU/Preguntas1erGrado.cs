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
    public partial class Preguntas1erGrado : Form
    {
        Menu1erGrado m1er;

        controlSonidos sonidos = new controlSonidos();

        int score = 0;
        int i = -1; //La cantidad de preguntas hechas hasta el momento
        string verResp = ""; //Aquí se va a guardar la respuesta cuando se quiera verificar 

        static string[] questions = new string[]
        {
            "                         Say to this kid:",
            "                         The kid is ________.",
            "                         Say to this kid:",
            "                         The kid is ________.",
            "                         The kid is ________.",
            "                         The kid is ________.",
            "                         The kid is ________.",
            "                         This is your ________.",
            "                         This is your ________.",
            "                         This is your ________.",
            "                         This is your ________.",
            "                         This is your ________."
        };

        int[] numbers = new int[4] { 1, 2, 3, 4 }; //Para que la posicion de las respuestas sea al azar

        //new string[]{ }
        Dictionary<string[], int> allAnswers = new Dictionary<string[], int>()
        {
            { new string[]{"Hello.", "Pencil.", "Cake.", "Foot." }, 0},
            { new string[]{"embarrassed.", "angry.", "scared.", "sad."}, 1},
            { new string[]{"Red.", "Bottle.", "Good bye.", "Circle."}, 2},
            { new string[]{"happy.", "surprised.", "scared.", "angry."}, 3},
            {new string[]{"angry.", "scared.", "surprised.", "sad."}, 4},
            { new string[]{"surprised.", "happy.", "sad.", "angry."}, 5},
            {new string[]{"surprised.", "scared.", "sad.", "happy."}, 6},
            { new string[]{"grandfather.", "uncle.", "mother.", "sister."}, 7},
            {new string[]{"grandmother.", "mother.", "father.", "aunt."}, 8},
            { new string[]{"uncle.", "father.", "sister.", "grandmother."}, 9},
            {new string[]{"aunt.", "father.", "grandfather.", "mother."}, 10},
            { new string[]{ "grandfather.", "mother.", "sister.", "father." }, 11}
        };

        string[] quizAnswers = new string[] 
        {
            "Hello.", "sad.", "Good bye.", "happy.", "scared.",
            "angry.", "surprised.", "mother.", "grandmother.",
            "father.", "grandfather.", "sister."
        };

        Image[] images = new Image[questions.Length];

        //Que esto ocurra siempre que el juego inicie y cuando se confirme que una respuesta es correcta
        private void asignarPregYResp()
        {
            sameBackColor();

            if (i+1 < questions.Length)
            {
                i++;
            }
            else
            {
                if(score>6)
                {
                    sonidos.sonidoTerminarBien();
                }
                else
                {
                    sonidos.sonidoTerminar();
                }
                MyMsgBox.Show("FINISH!\nFinal score: " + +score + " / " + questions.Length.ToString(), "", "OK");
                InitializeComponent();
                m1er = new Menu1erGrado();
                m1er.Show();
                this.Hide();
                return;
            }

            KeyValuePair<string[], int> pair;

            labelQuant.Text = (i+1).ToString() + " / " + questions.Length.ToString() +
                "                  Score: " + score + " / " + questions.Length.ToString();

            labelQuestion.Text = questions[i];
            Image im = imageList1.Images[i]; //La imagen de la lista de imagenes
            labelQuestion.Image = im; 
            int cant;
            Random rand = new Random();
            numbers = new int[4] { 0, 1, 2, 3 };
            pair = allAnswers.ElementAt(i);
            labelAnswer1.Text = pair.Key[numbers[cant = rand.Next(0, numbers.Length)]]; 
            numbers = numbers.Where(w => w != numbers[cant]).ToArray();
            labelAnswer2.Text = pair.Key[numbers[cant = rand.Next(0, numbers.Length)]];
            numbers = numbers.Where(w => w != numbers[cant]).ToArray();
            labelAnswer3.Text = pair.Key[numbers[cant = rand.Next(0, numbers.Length)]];
            numbers = numbers.Where(w => w != numbers[cant]).ToArray();
            labelAnswer4.Text = pair.Key[numbers[cant = rand.Next(0, numbers.Length)]];
            //numbers = numbers.Where(w => w != numbers[cant]).ToArray();

            /*
            Image ima = Image.FromFile("image.png"); // read in image
            ilabel.Size = new Size(i.Width, i.Height); //set label to correct size
            ilabel.Image = i; // put image on label
            this.Controls.Add(ilabel); // add label to container (a form, for instance)
            */

            labelNext.Visible = false;
        }

        public Preguntas1erGrado()
        {
            InitializeComponent();
            asignarPregYResp();
        }

        private void sameBackColor()
        {
            labelAnswer1.BackColor = tableLayoutPanel1.BackColor;
            labelAnswer2.BackColor = tableLayoutPanel1.BackColor;
            labelAnswer3.BackColor = tableLayoutPanel1.BackColor;
            labelAnswer4.BackColor = tableLayoutPanel1.BackColor;
        }

        private void labelAnswer1_Click(object sender, EventArgs e)
        {
            sonidos.sonidoOpcion();
            sameBackColor();
            labelAnswer1.BackColor = Color.LightSteelBlue;
            verResp = labelAnswer1.Text;
            labelNext.Visible = true;

        }

        private void labelAnswer2_Click(object sender, EventArgs e)
        {
            sonidos.sonidoOpcion();
            sameBackColor();
            labelAnswer2.BackColor = Color.LightSteelBlue;
            verResp = labelAnswer2.Text;
            labelNext.Visible = true;
        }

        private void labelAnswer3_Click(object sender, EventArgs e)
        {
            sonidos.sonidoOpcion();
            sameBackColor();
            labelAnswer3.BackColor = Color.LightSteelBlue;
            verResp = labelAnswer3.Text;
            labelNext.Visible = true;
        }

        private void labelAnswer4_Click(object sender, EventArgs e)
        {
            sonidos.sonidoOpcion();
            sameBackColor();
            labelAnswer4.BackColor = Color.LightSteelBlue;
            verResp = labelAnswer4.Text;
            labelNext.Visible = true;
        }

        //Cada vez que se tenga que verificar si una respuesta es correcta
        private void labelNext_Click(object sender, EventArgs e)
        {
            if (verResp.Equals(quizAnswers[i])) //REVISAR
            {
                sonidos.sonidoGanarSebastian();
                MyMsgBox.Show("CORRECT!", ":)", "OK");
                score++;
                asignarPregYResp();
            }

            else 
            {
                sonidos.sonidoPerderSebastian();
                MyMsgBox.Show("Incorrect...\nCorrect answer: " + quizAnswers[i], ":(", "OK");
                asignarPregYResp();

            }
        }

        //Devolverse al menu anterior
        private void labelReturn_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m1er = new Menu1erGrado();
            m1er.Show();
            this.Hide();
        }
    }
}
