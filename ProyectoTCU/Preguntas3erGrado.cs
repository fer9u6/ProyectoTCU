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
    public partial class Preguntas3erGrado : Form
    {
        Menu3erGrado m3er;

        int score = 0;
        int i = -1; //La cantidad de preguntas hechas hasta el momento
        string verResp = ""; //Aquí se va a guardar la respuesta cuando se quiera verificar 

        static string[] questions = new string[]
        {
            "In the morning I take a shower, eat breakfast, ________, and go to school.",
            "When meeting new people, you ________.",
            "________ is a good place to meet new people:",
            "At night I eat dinner, ________, brush my teeth, and go to sleep.",
            "When meeting someone new, ________.",
            "I brush my teeth in the ________.",
            "You can find the armchairs in the ________.",
            "I sleep in the ________.",
            "I eat dinner in the ________.",
            "The refrigerator and the oven can be found in the ________."
        };

        int[] numbers = new int[4] { 1, 2, 3, 4 }; //Para que la posicion de las respuestas sea al azar

        Dictionary<string[], int> allAnswers = new Dictionary<string[], int>()
        {
            { new string[]{"brush my teeth", "go to sleep", "take a shower", "eat dinner"}, 0},
            { new string[]{"introduce yourself.", "put your hands up.", "avoid eye contact.", "laugh."}, 1},
            { new string[]{"A friend's house", "The school", "My house", "My grandma's house"}, 2},
            { new string[]{"go to sleep", "eat breakfast", "put on my pajamas", "go to school"}, 3},
            { new string[]{"make an angry face.", "shake hands.", "be impolite.", "leave."}, 4},
            { new string[]{"living room.", "bedroom.", "kitchen.", "bathroom."}, 5},
            { new string[]{"bedroom.", "living room.", "bathroom.", "courtyard."}, 6},
            { new string[]{"bedroom.", "courtyard.", "kitchen.", "bathroom."}, 7},
            { new string[]{"bathroom.", "living room.", "courtyard.", "bedroom."}, 8},
            { new string[]{"kitchen.", "bathroom.", "living room.", "bedroom."}, 9}
        };

        string[] quizAnswers = new string[] 
        {
            "brush my teeth", "introduce yourself.", "The school", "put on my pajamas",
            "shake hands.", "bathroom.", "living room.", "bedroom.", "living room.", "kitchen."
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
                MyMsgBox.Show("FINISH!\nFinal score: " + +score + " / " + questions.Length.ToString(), "", "OK");
                InitializeComponent();
                m3er = new Menu3erGrado();
                m3er.Show();
                this.Hide();
                return;
            }

            KeyValuePair<string[], int> pair;

            labelQuant.Text = (i+1).ToString() + " / " + questions.Length.ToString() +
                "                  Score: " + score + " / " + questions.Length.ToString();

            labelQuestion.Text = questions[i];

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

        public Preguntas3erGrado()
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
                //MessageBox.Show("Correct!");
                MyMsgBox.Show("CORRECT!", ":)", "OK");
                score++;
                asignarPregYResp();
            }

            else 
            {
                MyMsgBox.Show("Incorrect...\nCorrect answer: " + quizAnswers[i], ":(", "OK");
                asignarPregYResp();

            }
        }

        //Devolverse al menu anterior
        private void labelReturn_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m3er = new Menu3erGrado();
            m3er.Show();
            this.Hide();
        }
    }
}
