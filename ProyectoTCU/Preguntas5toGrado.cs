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
    public partial class Preguntas5toGrado : Form
    {
        Menu5toGrado m5to;

        int score = 0;
        int i = -1; //La cantidad de preguntas hechas hasta el momento
        string verResp = ""; //Aquí se va a guardar la respuesta cuando se quiera verificar 

        string[] questions = new string[]
        {
            "This is a proper way of inviting someone to an event:",
            "The friends you have by only exchanging messages between one another are called:",
            "At listening other people opinions, you should always:",
            "This is a proper way of declining an invitation:",
            "A geothermal plant uses the power of ______________ to produce electricity.",
            "Wind power is used by ______________ to produce electricity",
            "In the event of an electric storm, you should:",
            "A ______________ uses the power of the water to produce electricity.",
            "In the event of an earthquake, you should:",
            "In the event of an indoors fire, you should:"
        };

        int[] numbers = new int[4] { 1, 2, 3, 4 }; //Para que la posicion de las respuestas sea al azar

        Dictionary<string[], int> allAnswers = new Dictionary<string[], int>()
        {
            { new string[]{"Can you like to go to...", "I'd love to go to...", "Would you like to go to...", "Can you bring drinks to..."}, 0},
            { new string[]{"pen-pals", "little friends", "message buddies", "correspondence comrades"}, 1},
            { new string[]{"Smile without listening", "Think they are wrong", "Be respectful", "Don't care"}, 2},
            { new string[]{"I'm sorry but I have other plans", "I don't like you", "Of course I'm gonna go", "Who are you?"}, 3},
            {new string[]{"wind", "water", "smoke", "heat"}, 4},
            { new string[]{"solar panels", "windmills", "hydro power plants", "cars"}, 5},
            {new string[]{"Stay indoors", "Put yourself under a table", "Close your eyes", "Use metallic objects"}, 6},
            { new string[]{"river", "solar panel", "windmill", "hydro power plant"}, 7},
            {new string[]{"Use metallic objects", "Run", "Go out to an open space", "Lean on the ground"}, 8},
            { new string[]{"Lean on the ground", "Hide in the closet", "Take big breaths", "Put yourself under a table"}, 9}
        };

        string[] quizAnswers = new string[] 
        {
            "Would you like to go to...", "pen-pals", "Be respectful",
            "I'm sorry but I have other plans", "heat", "windmills",
            "Stay indoors", "hydro power plant", "Go out to an open space", "Lean on the ground"
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
                m5to = new Menu5toGrado();
                m5to.Show();
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

        public Preguntas5toGrado()
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
            m5to = new Menu5toGrado();
            m5to.Show();
            this.Hide();
        }
    }
}
