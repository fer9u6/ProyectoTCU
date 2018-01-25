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

        int score = 0;
        int i = -1; //La cantidad de preguntas hechas hasta el momento
        string verResp = ""; //Aquí se va a guardar la respuesta cuando se quiera verificar 

        string[] questions = new string[]
        {
            "What is 9 cubed?", "What is 6+3?",
            "What type of animal is tuna sandwiches made from?",
            "What is 18 backwards?"
        };

        string[] answers = new string[]
        {
        "9", "81", "729", "2",
        "4", "2", "9", "1",
        "zebra", "aardvark", "fish", "gnu",
        "31", "81", "91", "88"
        };

        int[] numbers = new int[4] { 1, 2, 3, 4 }; //Para que la posicion de las respuestas sea al azar

        //new string[]{ }
        Dictionary<string[], int> allAnswers = new Dictionary<string[], int>()
        {
            { new string[]{"9", "81", "729", "2"}, 0}, {new string[]{"4", "2", "9", "1"}, 1},
            { new string[]{"zebra", "aardvark", "fish", "gnu"}, 2}, {new string[]{"31", "81", "91", "88"}, 3}
            /*{"grandpa", 4}, {"grandma", 5}, {"uncle", 6}, {"aunt", 7},
            {"son", 8}, {"daughter", 9}, {"pet", 10}, {"nephew", 11},
            {"niece", 12}, {"grandson", 13}, {"granddaugther", 14}*/
        };

        string[] quizAnswers = new string[] { "729", "9", "aardvark", "81" };

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
                //Lo mismo que el click de Return
                InitializeComponent();
                m1er = new Menu1erGrado();
                m1er.Show();
                this.Hide();
                return;
            }

            KeyValuePair<string[], int> pair;

            labelQuant.Text = (i+1).ToString() + " / " + questions.Length.ToString() +
                "                  Score:" + score + " / " + questions.Length.ToString();

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
            m1er = new Menu1erGrado();
            m1er.Show();
            this.Hide();
        }
    }
}
