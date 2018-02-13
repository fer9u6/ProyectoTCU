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
    public partial class Preguntas6toGrado : Form
    {
        Menu6toGrado m6to;

        int score = 0;
        int i = -1; //La cantidad de preguntas hechas hasta el momento
        string verResp = ""; //Aquí se va a guardar la respuesta cuando se quiera verificar 

        controlSonidos sonidos = new controlSonidos();

        static string[] questions = new string[]
        {
            "When you need to borrow a phone, you should ask:",
            "You should know how to speak English because ________.",
            "When you look for someone at the phone that is not available, you should say:",
            "When you need to go to the bathroom, you should ask:",
            "If you ask for someone at the phone, you should ask:",
            "________ are really important for tourism in Costa Rica.",
            "After going to the bathroom, you should always:",
            "A popular Costa Rican dish is ________.",
            "You shouldn't ________ while you are eating.",
            "Costa Rican and British people like to watch ________ on T.V."
        };

        int[] numbers = new int[4] { 1, 2, 3, 4 }; //Para que la posicion de las respuestas sea al azar

        Dictionary<string[], int> allAnswers = new Dictionary<string[], int>()
        {
            { new string[]{"How are you?", "Can I use your phone?", "Who are you?", "Can I go to the bathroom?"}, 0},
            { new string[]{"you can confuse people.", "it is important to get a job.", "you get to know new jokes.", "you can talk with your dog."}, 1},
            { new string[]{"Tell him/her to run away.", "Tell him/her to call me back.", "I don't like you.", "Tell him/her that I don't know"}, 2},
            { new string[]{"May I go to the classroom?", "How old are you?", "Where am I?", "May I go to the bathroom?"}, 3},
            {new string[]{"May I speak to...?", "What?", "Who are you?", "What time is it?"}, 4},
            { new string[]{"Beaches", "Plantations", "Fast food chains", "Dogs"}, 5},
            {new string[]{"Raise your hand.", "Use your phone.", "Call an ambulance.", "Wash your hands."}, 6},
            { new string[]{"beans.", "gallo pinto.", "fried chicken.", "potato."}, 7},
            {new string[]{"use a spoon", "smile", "use your phone", "think"}, 8},
            { new string[]{"airplanes", "baseball games", "football games", "skating"}, 9}
        };

        string[] quizAnswers = new string[] 
        {
            "Can I use your phone?", "it is important to get a job.", "Tell him/her to call me back.",
            "May I go to the bathroom?", "May I speak to...?", "Beaches",
            "Wash your hands.", "gallo pinto.", "use your phone", "football games"
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
                if (score > 6)
                {
                    sonidos.sonidoTerminarBien();
                }
                else
                {
                    sonidos.sonidoTerminar();
                }
                MyMsgBox.Show("FINISH!\nFinal score: " + +score + " / " + questions.Length.ToString(), "", "OK");
                InitializeComponent();
                m6to = new Menu6toGrado();
                m6to.Show();
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

            labelNext.Visible = false;
        }

        public Preguntas6toGrado()
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
            sameBackColor();
            labelAnswer1.BackColor = Color.LightSteelBlue;
            verResp = labelAnswer1.Text;
            labelNext.Visible = true;

        }

        private void labelAnswer2_Click(object sender, EventArgs e)
        {
            sameBackColor();
            labelAnswer2.BackColor = Color.LightSteelBlue;
            verResp = labelAnswer2.Text;
            labelNext.Visible = true;
        }

        private void labelAnswer3_Click(object sender, EventArgs e)
        {
            sameBackColor();
            labelAnswer3.BackColor = Color.LightSteelBlue;
            verResp = labelAnswer3.Text;
            labelNext.Visible = true;
        }

        private void labelAnswer4_Click(object sender, EventArgs e)
        {
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
            m6to = new Menu6toGrado();
            m6to.Show();
            this.Hide();
        }
    }
}
