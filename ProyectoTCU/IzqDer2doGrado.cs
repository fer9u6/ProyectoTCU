using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;

namespace ProyectoTCU
{
    public partial class IzqDer2doGrado : Form
    {
        Menu2doGrado m2do;

        controlSonidos sonidos = new controlSonidos();

        delegate void StringArgReturningVoidDelegate(string text);

        //Para los sonidos de las letras y palabras
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        int numLetra; //La posicion en la palabra de la letra que sigue de completar
        int score = 0;
        int mistakes = 0;
        string word;
        string wordSpanish = "null";
        //En esta lista se guardan las palabras que se hayan usado para no repetirlas
        List<string> used = new List<string>();

        static string[] allWords = new string[]
        {
            "water", "day", "night", "fruits", "vegetables",
            "sleep", "sick", "exercise", "junk food", "sweets", //10
            "carrot", "potato", "fish", "green beans","apple",
            "lettuce", "chicken", "broccoli", "bread", "watermelon", //20
            "eat", "bath", "drink", "pizza", "chocolate",
            "rice", "tomato", "cookie", "afternoon", "night", //30
            "noon", "morning", "celery", "cucumber", "strawberry", 
            "grape", "pear", "cabbage", "hamburger", "fries", //40
            "spinach", "onion", "ice cream", "pop corn" //44
        };

        static string[] allWordsSpanish = new string[]
        {
            "agua", "día", "noche", "frutas", "vegetales",
            "dormir", "enfermo", "ejercicio", "comida chatarra", "dulces", //10
            "zanahoria", "papa", "pescado", "vainicas", "manzana",
            "lechuga", "pollo", "brócoli", "pan", "sandía", //20
            "comer", "baño", "tomar", "pizza", "chocolate",
            "arroz", "tomate", "galleta", "tarde", "noche", //30
            "medio día", "mañana", "apio", "pepino", "fresa",
            "uva", "pera", "repollo", "hamburgesa", "papas fritas", //40
            "espinaca", "cebolla", "helado", "palomitas" //44
        };

        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public IzqDer2doGrado()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
            synthesizer.Volume = 100;   // 0...100
            synthesizer.Rate = -5;     //-10...10 
            setValues();
            setValues();
            //Reload components
            labelIn.Text = score + "/5 words completed            Mistakes: " + mistakes;
        }

        private void setValues()
        {
            //Se inicializan los valores globales
            numLetra = 0;
            mistakes = 0;
            word = "";
            //windowWidth = labelInSpanish.Width;

            Random random;
            int randomNumber = 0;
            //Se elige una palabra al azar de la lista de palabras
            //siempre y cuando no se haya usado antes
            while (word == "" || used.Contains(word))
            {
                random = new Random();
                randomNumber = random.Next(0, allWords.Length);
                word = allWords[randomNumber];
            }

            //Se guarda la palabra seleccionada en la lista de palabras usadas
            used.Add(word);

            //Se agrega la imagen adecuada
            Image im = imageList1.Images[randomNumber];
            labelImage.Image = im;
            //Se presenta también la palabra en espanol
            labelInSpanish.Text = "In spanish: \n " + allWordsSpanish[randomNumber];

            //Se define la palabra en espanol para la mascota (no aplica en 1ero y 2do grado)
            wordSpanish = allWordsSpanish[randomNumber];

            //Se definen las opciones posibles
            changeOptionsInButtons();

            int wordSize = word.Length;
            //Se muestra la palabra alterando el tableLayoutPanel
            tableLayoutPanelLetters.Controls.Clear();
            tableLayoutPanelLetters.ColumnStyles.Clear();
            tableLayoutPanelLetters.RowStyles.Clear();
            tableLayoutPanelLetters.ColumnCount = wordSize;
            tableLayoutPanelLetters.RowCount = 1;
            tableLayoutPanelLetters.Width = this.Width; // + this.Width/3
            tableLayoutPanelLetters.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0); //REVISAR
            tableLayoutPanelLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            //Se divide 100 entre el numero de letras en la palabra para los porcentajes
            int percentage = 100 / wordSize;
            //Se establecen las columnas
            for (int i = 0; i < wordSize; i++)
            {
                tableLayoutPanelLetters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentage)); //33F
            }
            for (int i = 0; i < wordSize; i++)
            {
                //Si la "letra" NO es un espacio
                if(word[i] != ' ')
                {
                    //Si es la letra siguiente a completar, color azul
                    if (i == numLetra)
                    {
                        tableLayoutPanelLetters.Controls.Add(new Label()
                        {
                            Text = System.Convert.ToString(word[i]),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Cooper Black", 40, FontStyle.Bold),
                            Dock = System.Windows.Forms.DockStyle.Fill,
                            BackColor = System.Drawing.Color.Blue
                            //ForeColor = System.Drawing.Color.Blue
                        }, i, 0);
                    }
                    //Si la letra ya fue completada, color verde
                    else if (i < numLetra)
                    {
                        tableLayoutPanelLetters.Controls.Add(new Label()
                        {
                            Text = System.Convert.ToString(word[i]),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Cooper Black", 40, FontStyle.Bold),
                            Dock = System.Windows.Forms.DockStyle.Fill,
                            BackColor = System.Drawing.Color.Green,
                            //ForeColor = System.Drawing.Color.Green
                        }, i, 0);
                    }
                    //Si la letra falta de completar pero no es la siguiente, negra
                    else
                    {
                        tableLayoutPanelLetters.Controls.Add(new Label()
                        {
                            Text = System.Convert.ToString(word[i]),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Cooper Black", 40, FontStyle.Bold),
                            Dock = System.Windows.Forms.DockStyle.Fill,
                            ForeColor = System.Drawing.Color.Black
                        }, i, 0);
                    }
                }
                
            }
        }

        //Usa la palabra que se busca completar y la letra que sigue de elegir
        private void changeOptionsInButtons()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, alphabet.Length);
            Boolean different = false;
            //Se asegura que la opcion equivocada no se encuentre 
            //en la totalidad de la palabra para evitar confusiones
            //y que las dos opciones no sean iguales
            while (!different)
            {
                if (word.Contains(alphabet[randomNumber]) || word[numLetra] == alphabet[randomNumber])
                {
                    randomNumber = random.Next(0, alphabet.Length);
                }
                else
                {
                    different = true;
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

        //Se actualiza el numero de palabras completadas, el numero de errores, 
        //los colores de las letras y se verifica si se completó la palabra
        private void updateInfo(Object letterObject)
        {

            if (this.buttonIzq.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(updateInfo);
                this.Invoke(d, new object[] { letterObject });
            }
            else
            {
                String letter = letterObject.ToString();

                //Si es la letra que sigue para completar (opcion correcta)

                if (letter == System.Convert.ToString(word[numLetra]))
                {
                    //Sonido de exito (quitarlo?)
                    //sonidos.sonidoGanarSebastian();
                    //Sonido de la letra
                    synthesizer.Speak(letter);
                    //Pasa a la siguiente letra en la lista
                    numLetra++;

                    int wordSize = word.Length;
                    //Si ya se completó la palabra
                    if (numLetra == wordSize)
                    {
                        score++;

                        synthesizer.Speak(word);
                        //System.Threading.Thread.Sleep(500);

                        //Si se completaron todas las palabras, popup de victoria y de vuelta al menu principal
                        if (score == 5)
                        {
                            labelIn.Text = score + "/5 words completed            Mistakes: " + mistakes;
                            sonidos.sonidoTerminarBien();

                            MyMsgBox.Show("CONGRATULATIONS!\nYou completed all the words!", ":)", "OK");
                            InitializeComponent();
                            m2do = new Menu2doGrado();
                            m2do.Show();
                            this.Hide();
                            return;
                        }

                        setValues();
                    }
                    else
                    {
                        Control label;
                        //Cambiar color de la letra recien completada y de la que sigue si faltan
                        for (int i = 0; i < wordSize; i++)
                        {
                            label = tableLayoutPanelLetters.GetControlFromPosition(i, 0);
                            if (label is Label)
                            {
                                //Si es la letra siguiente a completar, color azul
                                if (i == numLetra)
                                {
                                    label.Text = System.Convert.ToString(word[i]);
                                    label.BackColor = System.Drawing.Color.Blue;
                                    //label.ForeColor = System.Drawing.Color.Blue;

                                }
                                //Si la letra ya fue completada, color verde
                                else if (i < numLetra)
                                {
                                    label.Text = System.Convert.ToString(word[i]);
                                    label.BackColor = System.Drawing.Color.Green;
                                    //label.ForeColor = System.Drawing.Color.Green;
                                }
                                //Si la letra falta de completar pero no es la siguiente, negra 
                                //(CREO QUE ESTA NO SE OCUPA)
                                else
                                {
                                    label.Text = System.Convert.ToString(word[i]);
                                    label.ForeColor = System.Drawing.Color.Black;
                                }
                            }
                        }
                        changeOptionsInButtons();
                    }
                }
                else
                {
                    //Sonido de fracaso
                    sonidos.sonidoPerderSebastian();
                    mistakes++;
                }

                //El juego se gana completando 5 palabras
                labelIn.Text = score + "/5 words completed            Mistakes: " + mistakes;
            }
        }

        private void buttonIzq_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart start = new ParameterizedThreadStart(updateInfo);
            Thread t = new Thread(start);
            t.Start(buttonIzq.Text);
            //updateInfo(buttonIzq.Text);
        }

        private void buttonDer_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart start = new ParameterizedThreadStart(updateInfo);
            Thread t = new Thread(start);
            t.Start(buttonDer.Text);
            //updateInfo(buttonDer.Text);
        }

        private void buttonRet_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m2do = new Menu2doGrado();
            m2do.Show();
            this.Hide();
        }

        private void IzqDer2doGrado_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelNarvi_Click(object sender, EventArgs e)
        {
            labelHelp.Text = "La palabra en español es: " + "'" + wordSpanish + "'";
        }

        private void buttonRet_Click_1(object sender, EventArgs e)
        {
            InitializeComponent();
            m2do = new Menu2doGrado();
            m2do.Show();
            this.Hide();
        }
    }
}
