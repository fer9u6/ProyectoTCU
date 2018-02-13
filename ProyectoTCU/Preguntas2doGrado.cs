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
    public partial class Preguntas2doGrado : Form
    {
        Menu2doGrado m2do;

        int score = 0;
        int i = -1; //La cantidad de preguntas hechas hasta el momento
        string verResp = ""; //Aquí se va a guardar la respuesta cuando se quiera verificar 

        controlSonidos sonidos = new controlSonidos();

        static string[] questions = new string[]
        {
            "Drink ___ glasses of water a day.",
            "Don't eat ________ at night.",
            "Eat vegetables, like ________ and ________.",
            "Sleep ___ hours a day.",
            "________ to stay healthy.",
            "Exercise at least ____ times a week.",
            "________ and ________ are junk food.",
            "Eat fruit ________.",
            "________ food is bad for you.",
            "________ and ________ are healthy food."
        };

        int[] numbers = new int[4] { 1, 2, 3, 4 }; //Para que la posicion de las respuestas sea al azar

        
        Dictionary<string[], int> allAnswers = new Dictionary<string[], int>()
        {
            { new string[]{"20", "2", "8", "4"}, 0},
            { new string[]{"sweets", "carrots", "potatoes", "fish"}, 1},
            { new string[]{"green beans / apples.", "lettuce / chicken.", "carrots / broccoli.", "bread / watermelon."}, 2},
            { new string[]{"4", "24", "8", "6"}, 3},
            {new string[]{"Look at the sun", "Eat junk food", "Wash your hands", "Drink cola"}, 4},
            { new string[]{"7", "3", "2", "10"}, 5},
            {new string[]{"Pizza / fried chicken", "Chocolates / carrots", "Bread / rice", "Tomatoes / cookies"}, 6},
            { new string[]{"in the afternoon.", "at night.", "at noon.", "in the morning."}, 7},
            {new string[]{"Green", "Hot", "Cooked on grill", "Fried"}, 8},
            { new string[]{"Fried fish / lettuce", "Celery / tomato", "Chicken / mayonnaise", "Cucumber / caramel"}, 9}
        };

        string[] quizAnswers = new string[] 
        {
            "8", "sweets", "carrots / broccoli.", "8", "Wash your hands",
            "3", "Pizza / fried chicken", "in the morning.", "Fried", "Celery / tomato"
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
                m2do = new Menu2doGrado();
                m2do.Show();
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

        public Preguntas2doGrado()
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
            m2do = new Menu2doGrado();
            m2do.Show();
            this.Hide();
        }
    }
}
