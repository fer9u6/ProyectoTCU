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
    public partial class IzqDer1erGrado : Form
    {
        Menu1erGrado m1er;

        controlSonidos sonidos = new controlSonidos();

        int numLetra = -1; //La posicion en la palabra de la letra que sigue de completar

        int score = 0;

        int mistakes = 0;

        string word = "";

        static string[] allWords = new string[]
        {
            "hello", "bye",
            "pencil", "paper", "notebook", "scissors", "sharpener",
            "cake", "chicken", "pizza", "carrot", "onion", "lettuce",
            "foot", "hand", "head", "finger", "eyes", "ears", "nose", "hair",
            "happy", "surprised", "embarrassed", "angry", "scared", "sad",
            "red", "blue", "green", "yellow", "purple", "orange",
            "circle", "square", "triangle", 
            "grandfather", "father", "brother", "uncle",
            "grandmother", "mother", "sister", "aunt"
        };

        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        /*
        static char[] alphabet = new char[]
        {
            'abc';
        }
        */

        public IzqDer1erGrado()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
            setValues();
            
        }

        private void setValues()
        {
            //Se elige una palabra al azar de la lista de palabras
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            word = allWords[random.Next(0, allWords.Length)];

            //Se definen las opciones posibles
            numLetra++;
            changeOptions();

            //Se muestra la palabra
            int wordSize = word.Length;
            tableLayoutPanelLetters.Controls.Clear();
            tableLayoutPanelLetters.ColumnStyles.Clear();
            tableLayoutPanelLetters.RowStyles.Clear();
            tableLayoutPanelLetters.ColumnCount = wordSize;
            tableLayoutPanelLetters.RowCount = 1;
            tableLayoutPanelLetters.Width = this.Width;
            tableLayoutPanelLetters.Padding = new System.Windows.Forms.Padding(40, 0, 40, 0); //REVISAR
            tableLayoutPanelLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            //Se divide 100 entre el numero de letras en la palabra para los porcentajes
            int percentage = 100 / wordSize;
            //Se establecen las columnas
            for (int i = 0; i < wordSize; i++)
            {
                tableLayoutPanelLetters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentage)); //33F
            }
            for (int i = 0; i < wordSize; i++)
            {
                //Si es la letra siguiente a completar, color azul
                if (i == numLetra)
                {
                    tableLayoutPanelLetters.Controls.Add(new Label()
                    {
                        Text = System.Convert.ToString(word[i]),
                        Font = new Font("Cooper Black", 40, FontStyle.Bold),
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        ForeColor = System.Drawing.Color.Blue
                    }, i, 0);
                }
                //Si la letra ya fue completada, color verde
                else if (i == numLetra)
                {
                    tableLayoutPanelLetters.Controls.Add(new Label()
                    {
                        Text = System.Convert.ToString(word[i]),
                        Font = new Font("Cooper Black", 40, FontStyle.Bold),
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        ForeColor = System.Drawing.Color.Green
                    }, i, 0);
                }
                //Si la letra falta de completar pero no es la siguiente, negra
                else 
                {
                    tableLayoutPanelLetters.Controls.Add(new Label()
                    {
                        Text = System.Convert.ToString(word[i]),
                        Font = new Font("Cooper Black", 40, FontStyle.Bold),
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        ForeColor = System.Drawing.Color.Black
                    }, i, 0);
                }
            }
        }

        //Recibe la palabra que se busca completar y la letra que sigue de elegir
        private void changeOptions()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, alphabet.Length);
            Boolean different = false;
            //Se asegura que la opcion equivocada no se encuentre 
            //en la totalidad de la palabra para evitar confusiones
            while (!different)
            {
                different = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (alphabet[randomNumber] == word[i]) //OUT OF BOUNDS
                    {
                        randomNumber = random.Next(0, alphabet.Length);
                        i = word.Length;
                        different = false;
                    }
                }

            }
            
            if (randomNumber % 2 == 0) //Si es par, que la respuesta correcta sea la de la izquierda
            {
                buttonIzq.Text = System.Convert.ToString(word[numLetra]);
                buttonDer.Text = System.Convert.ToString(alphabet[randomNumber]);
            }
            else //Sino, que la respuesta correcta sea la de la derecha
            {
                buttonDer.Text = System.Convert.ToString(word[numLetra]);
                buttonIzq.Text = System.Convert.ToString(alphabet[randomNumber]);
            }
        }

        private void buttonIzq_Click(object sender, EventArgs e)
        {
            //Si es la letra que sigue para completar
            if (this.Text == System.Convert.ToString(word[numLetra]))
            {
                numLetra++;
                //Sonido de exito
                //Cambiar color de la letra recien completada y de la que sigue si faltan
                //Si ya se completó la palabra, score++ y se pone una palabra nueva
                //Si se completaron todas las palabras, popup de victoria y de vuelta al menu principal
                //Suena como muchas cosas, podria ser una funcion aparte
            }
            else
            {
                //Sonido de fracaso
                //mistakes++
            }
        }

        private void buttonDer_Click(object sender, EventArgs e)
        {
            //Igual que arriba
        }

        private void buttonRet_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m1er = new Menu1erGrado();
            m1er.Show();
            this.Hide();
        }

        
    }
}
