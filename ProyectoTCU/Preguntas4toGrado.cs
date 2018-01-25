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
    public partial class Preguntas4toGrado : Form
    {
        Menu4toGrado m4to;

        int score = 0;
        int i = -1; //La cantidad de preguntas hechas hasta el momento
        string verResp = ""; //Aquí se va a guardar la respuesta cuando se quiera verificar 

        string[] questions = new string[]
        {
            "A formal way of answer a greeting is:",
            "When someone is being rude at you, you should ______________.",
            "Complete the greeting: 'Hello, ______________?'",
            "An informal way of answer a greeting is:",
            "Complete the farewell: 'I got to go. ______________!'",
            "The organs that keep pumping air through the body are the ______________.",
            "If you are exposed to a cold weather and rain, it is possible you'll get ______________.",
            "Watching a screen for extended periods of time can give you ______________.",
            "The organ that keeps pumping blood through the body is the:",
            "You should drink plenty of water, so your body can ______________.",
            "Being under the sun for long periods of time without protection can give you ______________."
        };

        int[] numbers = new int[4] { 1, 2, 3, 4 }; //Para que la posicion de las respuestas sea al azar

        Dictionary<string[], int> allAnswers = new Dictionary<string[], int>()
        {
            { new string[]{"What up?", "Hi", "Pleased to meet you", "See you later"}, 0},
            { new string[]{"be rude at them", "stop talking to them ever again", "get angry", "be polite anyway"}, 1},
            { new string[]{"how are you doing", "hi", "can you leave", "my name is"}, 2},
            { new string[]{"See ya!", "How are you doing?", "Hello", "How do you do?"}, 3},
            {new string[]{"Hello", "Where's the classroom", "See you later", "How are you"}, 4},
            { new string[]{"pancreas", "lungs", "eyes", "liver"}, 5},
            {new string[]{"good luck", "a migraine", "a cold", "a stomachache"}, 6},
            { new string[]{"eye pain", "a sore throat", "an infection", "sugar loss"}, 7},
            {new string[]{"stomach", "liver", "heart", "brain"}, 8},
            { new string[]{"breath", "keep itself clean", "run faster", "grow nails"}, 9},
            {new string[]{"a rash", "a cold", "skin burns", "a stomachache"}, 10}
        };

        string[] quizAnswers = new string[] 
        {
            "Pleased to meet you", "be polite anyway", "how are you doing",
            "Hello", "See you later", "lungs", "a cold", "eye pain", "heart",
            "keep itself clean", "skin burns"
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
                m4to = new Menu4toGrado();
                m4to.Show();
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

        public Preguntas4toGrado()
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
            m4to = new Menu4toGrado();
            m4to.Show();
            this.Hide();
        }
    }
}
