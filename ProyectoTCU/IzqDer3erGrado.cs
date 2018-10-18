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
    public partial class IzqDer3erGrado : Form
    {
        Menu3erGrado m3er;

        controlSonidos sonidos = new controlSonidos();

        delegate void StringArgReturningVoidDelegate(string text);

        //Para los sonidos de las letras y palabras
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        int numLetra; //La posicion en la palabra de la letra que sigue de completar
        int score = 0;
        int mistakes = 0;
        string word;
        string wordSpanish = "null";
        int help = 0; //Para medir cuantas veces el usuario ha pedido ayuda
        List<int> showedL = new List<int>(); //Para ver qué posiciones NO se deben completar
        //En esta lista se guardan las palabras que se hayan usado para no repetirlas
        List<string> used = new List<string>();

        //Puede que se pueda usar un booleano para ver si ya se pidio un consejo
        //Si se pide una segunda vez que se muestre la respuesta

        static string[] allWords = new string[]
        {
            "shower", "breakfast", "lunch", "dinner", "school",
            "people", "armchair", "refrigerator", "oven", "eat", //10
            "sleep", "sink", "draw er", "living room", "bedroom",
            "kitchen", "bathroom", "dinning room", "courtyard", "garage", //20
            "pillow", "phone", "chair", "table", "bed",
            "bathtub", "toilet", "book", "television", "bookshelf", "desk" //31
        };

        static string[] allWordsSpanish = new string[]
        {
            "ducha", "desayuno", "almuerzo", "cena", "escuela", 
            "gente", "sillón", "refrigerador", "horno", "comer", //10
            "dormir", "lavatorio", "cajones", "sala", "cuarto", 
            "cocina", "baño", "comedor", "patio", "garaje", //20
            "almohada", "teléfono", "silla", "mesa", "cama",
            "tina", "inodoro", "libro", "televisión", "librero", "escritorio" //31
        };

        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public IzqDer3erGrado()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
            synthesizer.Volume = 100;   // 0...100
            synthesizer.Rate = -5;     //-10...10 
            synthesizer.SelectVoiceByHints(VoiceGender.Female);
            setValues();
            //setValues();
            //Reload components
            labelIn.Text = score + "/5 words completed            Mistakes: " + mistakes;
        }

        private void setValues()
        {
            //Se inicializan los valores globales
            numLetra = 0;
            mistakes = 0;
            word = "";
            help = 0;
            //Modifica la imagen de Narvi
            labelNarvi.Image = Image.FromFile(System.IO.Path.GetFullPath(@"..\..\") + "Resources\\imgSebastian\\Narvi\\narviDerecha.png");
            //Modifica el texto de Narvi
            labelNarvi.Text = "Click for help!";
            //Esconde el mensaje de ayuda
            labelHelp.Visible = false;
            labelHelp.Text = " ";
            //windowWidth = labelInSpanish.Width;
            showedL.Clear();

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
            //Se presenta también la palabra en espanol (ESTA PARTE NO)
            //labelInSpanish.Text = "In spanish: \n " + allWordsSpanish[randomNumber];

            //Se define la palabra en espanol para la mascota (no aplica en 1ero y 2do grado)
            wordSpanish = allWordsSpanish[randomNumber];


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
            //Para 3er y 4to grado solo se van a mostrar algunas letras de la palabra a completar
            //Si la palabra es de 5 letras o menos solo se mestra una letra
            //Si es mayor a 5 letras y menor a 10 solo dos
            //Si es mayor a 15 solo tres
            int showLetters = 0; //La cantidad de letras que se van a mostrar
            if (wordSize <= 5)
            {
                showLetters = 1;
            }
            else if (wordSize > 5 && wordSize <= 10)
            {
                showLetters = 2;
            }
            else
            {
                showLetters = 3;
            }
            Random randomL = new Random();
            int randomNumberL = 0;
            for (int j = 0; j < showLetters; j++)
            {
                randomNumberL = randomL.Next(0, wordSize);
                //Se guardan las posiciones que se van a mostrar en la palabra
                while (showedL.Contains(randomNumberL)) 
                {
                    randomNumberL = randomL.Next(0, wordSize);
                }
                showedL.Add(randomNumberL);
            }
            //OJO: Hacer que numLetra sea la primera que NO este en la lista de mostrarse
            while (showedL.Contains(numLetra))
            {
                numLetra++;
            }
            //Se definen las opciones posibles
            changeOptionsInButtons();
            for (int i = 0; i < wordSize; i++)
            {
                //Solo mostrar la letra si esta en la lista de posiciones a mostrar
                if (showedL.Contains(i))
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
                //Sino que se muestre como un espcio vacio indicando que se debe completar la letra
                else if (word[i] != ' ')
                {
                    //Si es la letra siguiente a completar, color azul
                    if (i == numLetra)
                    {
                        tableLayoutPanelLetters.Controls.Add(new Label()
                        {
                            Text = System.Convert.ToString(" "),
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
                            Text = System.Convert.ToString(" "),
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
                            Text = System.Convert.ToString(" "),
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
                //Y NO esta en la lista de las que no se deben mostrar

                if (letter == System.Convert.ToString(word[numLetra]))
                {
                    //Si alguien logra decrubrir cómo usar:
                    //synthesizer.Speak(letter);
                    //sin que sea tan lento, mejor usar eso con todas las letras, que es más facil
                    //pero por ahora sale suuuper lento y no es viable

                    //Sonido de la letra
                    switch (letter)
                    {
                        case "a":
                            sonidos.AudioA();
                            break;
                        case "b":
                            sonidos.AudioB();
                            break;
                        case "c":
                            sonidos.AudioC();
                            break;
                        case "d":
                            sonidos.AudioD();
                            break;
                        case "e":
                            sonidos.AudioE();
                            break;
                        case "f":
                            sonidos.AudioF();
                            break;
                        case "g":
                            sonidos.AudioG();
                            break;
                        case "h":
                            sonidos.AudioH();
                            break;
                        case "i":
                            sonidos.AudioI();
                            break;
                        case "j":
                            sonidos.AudioJ();
                            break;
                        case "k":
                            sonidos.AudioK();
                            break;
                        case "l":
                            sonidos.AudioL();
                            break;
                        case "m":
                            sonidos.AudioM();
                            break;
                        case "n":
                            sonidos.AudioN();
                            break;
                        case "o":
                            sonidos.AudioO();
                            break;
                        case "p":
                            sonidos.AudioP();
                            break;
                        case "q":
                            sonidos.AudioQ();
                            break;
                        case "r":
                            sonidos.AudioR();
                            break;
                        case "s":
                            sonidos.AudioS();
                            break;
                        case "t":
                            sonidos.AudioT();
                            break;
                        case "u":
                            sonidos.AudioU();
                            break;
                        case "v":
                            sonidos.AudioV();
                            break;
                        case "w":
                            sonidos.AudioW();
                            break;
                        case "x":
                            synthesizer.Speak("x");
                            break;
                        case "y":
                            synthesizer.Speak("y");
                            break;
                        case "z":
                            synthesizer.Speak("z");
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                    


                    //Pasa a la siguiente letra en la lista
                    numLetra++;


                    //Para saltarse los espacios en blanco que puedan haber en una palabra
                    //Y no marcar las letras que ya se estan mostrando
                    if (word.Length > numLetra)
                    {
                        while (word.Length > numLetra && (word[numLetra] == ' ' || showedL.Contains(numLetra)) )
                        {
                            numLetra++;
                        }
                    }

                    int wordSize = word.Length;
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
                                label.Text = System.Convert.ToString(" ");
                                label.BackColor = System.Drawing.Color.Blue;
                                if (showedL.Contains(i))
                                {
                                    label.Text = System.Convert.ToString(word[i]);
                                }

                            }
                            //Si la letra ya fue completada, color verde
                            else if (i < numLetra)
                            {
                                label.Text = System.Convert.ToString(word[i]);
                                label.BackColor = System.Drawing.Color.Green;
                            }
                            //Si la letra falta de completar pero no es la siguiente, negra 
                            //(CREO QUE ESTA NO SE OCUPA)
                            else
                            {
                                label.Text = System.Convert.ToString(" ");
                                label.ForeColor = System.Drawing.Color.Black;
                                if (showedL.Contains(i))
                                {
                                    label.Text = System.Convert.ToString(word[i]);
                                }
                            }
                        }
                    }
                    
                    //Si ya se completó la palabra
                    if (numLetra == wordSize)
                    {
                        score++;
                        System.Threading.Thread.Sleep(900);
                        synthesizer.Speak(word);
                        

                        //Si se completaron todas las palabras, popup de victoria y de vuelta al menu principal
                        if (score == 5)
                        {
                            labelIn.Text = score + "/5 words completed            Mistakes: " + mistakes;
                            sonidos.sonidoTerminarBien();

                            MyMsgBox.Show("CONGRATULATIONS!\nYou completed all the words!", ":)", "OK");
                            InitializeComponent();
                            m3er = new Menu3erGrado();
                            m3er.Show();
                            this.Hide();
                            return;
                        }

                        setValues();
                    }
                    changeOptionsInButtons();

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
            m3er = new Menu3erGrado();
            m3er.Show();
            this.Hide();
        }

        private void IzqDer3erGrado_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelNarvi_Click(object sender, EventArgs e)
        {
            //Es la primera vez que se pide ayuda
            if (help == 0)
            {
                labelNarvi.Image = Image.FromFile(System.IO.Path.GetFullPath(@"..\..\") + "Resources\\imgSebastian\\Narvi\\narviDerechaExito.png");
                labelNarvi.Text = "Click again\nfor answer";
                labelHelp.Visible = true;
                labelHelp.Text = "La palabra en\nespañol es:\n" + "'" + wordSpanish + "'";
                help++;
            }
            //Es la segunda vez que se pide ayuda
            else if (help == 1)
            {
                labelHelp.Text = "La palabra en\ninglés es:\n " + "'" + word + "'";
                labelNarvi.Text = "";
                help++;
            }
        }

        private void buttonRet_Click_1(object sender, EventArgs e)
        {
            InitializeComponent();
            m3er = new Menu3erGrado();
            m3er.Show();
            this.Hide();
        }
    }
}
