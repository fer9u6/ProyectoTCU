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

        controlSonidos sonidos = new controlSonidos();

        static string[] questions = new string[]
        {
            "A polite way of inviting someone to an event is:",
            "A polite way of answering an invitation is:",
            "When listening at other people’s opinions,\n                         you should always:",
            "This is a proper way of declining an invitation:",
            "A way to fight deforestation is to ________.",
            "        A way of saving electricity is to ________.",
            "              ________ pollute the environment.",
            "              ________ pollutes the rivers.",
            "       A good way to save water is ________.",
            "       Throwing ________ at plants pollutes them.",
            "       ________ poisons the environment."
        };

        int[] numbers = new int[4] { 1, 2, 3, 4 }; //Para que la posicion de las respuestas sea al azar

        Dictionary<string[], int> allAnswers = new Dictionary<string[], int>()
        {
            { new string[]{"Do you know how to get to...", "I'd love to go to...", "Would you like to go to...", "Can you bring drinks to..."}, 0},
            { new string[]{"How are you?", "See you later.", "Yes, I would like to go.", "Maaaybe..."}, 1},
            { new string[]{"Smile without listening.", "Think they are wrong.", "Be respectful.", "Clap your hands."}, 2},
            { new string[]{"I’m sorry. I need to study tonight.", "I don't like you.", "Of course I'm gonna go.", "Who are you?"}, 3},
            {new string[]{"wash the dishes.", "plant a tree.", "cut down trees.", "listen to loud music."}, 4},
            { new string[]{"watch TV.", "don't smoke.", "turn off the lights.", "burn the forest."}, 5},
            {new string[]{"Factories.", "Puppies.", "Trees.", "Cellphones."}, 6},
            { new string[]{"Eating burgers", "Throwing the thrash into the river", "Running fast", "Throwing rocks into the river"}, 7},
            {new string[]{"going to the swimming pool.", "not letting the sink open.", "watching TV.", "turning off the lights."}, 8},
            { new string[]{"fish.", "water.", "cheese.", "chemicals."}, 9},
            { new string[]{"Making a barbecue", "Fishing", "Swimming", "Burning trash"}, 10},
        };

        string[] quizAnswers = new string[] 
        {
            "Would you like to go to...", "Yes, I would like to go.", "Be respectful.",
            "I’m sorry. I need to study tonight.", "plant a tree.", "turn off the lights.",
            "Factories.", "Throwing the thrash into the river", "not letting the sink open.",
            "chemicals.", "Burning trash"
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
                m5to = new Menu5toGrado();
                m5to.Show();
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
            m5to = new Menu5toGrado();
            m5to.Show();
            this.Hide();
        }
    }
}
