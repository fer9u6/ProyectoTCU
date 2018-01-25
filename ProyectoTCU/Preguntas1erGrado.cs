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
            "Which one is a proper response to \n'Hello, how are you?'",
            "I feel sad when:",
            "When greeting someone new, you should always ______________",
            "I feel happy when ______________",
            "I feel scared when ______________",
            "I feel angry when ______________",
            "I feel surprised when ______________",
            "My father's sister is my ______________",
            "The mother of my brother is my ______________",
            "The father of my cousin is my ______________",
            "The son of my sister is my ______________",
            "The father of my grandchild is my ______________"
        };

        int[] numbers = new int[4] { 1, 2, 3, 4 }; //Para que la posicion de las respuestas sea al azar

        //new string[]{ }
        Dictionary<string[], int> allAnswers = new Dictionary<string[], int>()
        {
            { new string[]{"I want ice cream", "Fine, thank you", "I'm 7 years old", "I am, thank you"}, 0},
            { new string[]{"I go to sleep", "I get my favorite food", "I get good grades at school", "I don't get what I want"}, 1},
            { new string[]{"make eye contact", "look at the floor", "keep your hands in your pockets", "laugh at them"}, 2},
            { new string[]{"I get my favorite food", "I fall to the ground", "Someone makes fun of me", "I can't sleep at night"}, 3},
            {new string[]{"I am with my friends", "I eat dessert", "I watch TV", "I confront something unknown"}, 4},
            { new string[]{"I sleep", "I'm taking a shower", "Someone makes fun of me", "It rains"}, 5},
            {new string[]{"I lost something", "Something happens that I didn't expected", "I go to school", "I run to the bus"}, 6},
            { new string[]{"Nephew", "Sister", "Aunt", "Grandmother"}, 7},
            {new string[]{"Mother", "Aunt", "Grandfather", "Niece"}, 8},
            { new string[]{"Father", "Brother", "Uncle", "Niece"}, 9},
            {new string[]{"Nephew", "Cousin", "Mother", "Brother"}, 10},
            { new string[]{"Grandfather", "Cousin", "Son", "Uncle"}, 11}
        };

        string[] quizAnswers = new string[] 
        {
            "Fine, thank you", "I don't get what I want", "make eye contact",
            "I get my favorite food", "I confront something unknown", "Someone makes fun of me",
            "Something happens that I didn't expected", "Aunt", "Mother",
            "Uncle", "Nephew", "Son"
        };

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
                m1er = new Menu1erGrado();
                m1er.Show();
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
