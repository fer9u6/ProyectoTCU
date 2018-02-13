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
    public partial class Parejas3erGrado : Form
    {
        controlSonidos sonidos = new controlSonidos();

        Menu3erGrado m3grado;

        // firstClicked points to the first Label control 
        // that the player clicks, but it will be null 
        // if the player hasn't clicked a label yet
        Label firstClicked = null;

        // secondClicked points to the second Label control 
        // that the player clicks
        Label secondClicked = null;

        // Use this Random object to choose random icons for the squares
        Random random = new Random();

        // Each of these letters is an interesting icon
        // in the Webdings font,
        // and each icon appears twice in this list

        List<Label> labels = new List<Label>(new Label[16]); //Inicializada

        Dictionary<string, int> pairsHouseSpanish = new Dictionary<string, int>();

        Dictionary<string, int> pairsHouseEnglish = new Dictionary<string, int>();

        static Dictionary<string, int> pairsHouseSpanishReal = new Dictionary<string, int>()
        {
            {"cocina", 0}, {"baño", 1}, {"sala", 2}, {"cuarto", 3},
            {"garaje", 4}, {"patio", 5}, {"sillón", 6}, {"silla", 7},
            {"mesa", 8}, {"cama", 9}, {"horno", 10}, {"ducha", 11},
            {"inodoro", 12}, {"refrigeradora", 13}, {"televisión", 14},
            {"librero", 15 }
        };

        static Dictionary<string, int> pairsHouseEnglishReal = new Dictionary<string, int>()
        {
            {"kitchen", 0}, {"bathroom", 1}, {"living room", 2}, {"bedroom", 3},
            {"garage", 4}, {"yard", 5}, {"armchair", 6}, {"chair", 7},
            {"table", 8}, {"bed", 9}, {"oven", 10}, {"shower", 11},
            {"toilet", 12}, {"refrigerator", 13}, {"television", 14},
            {"bookshelf", 15 }
        };

        /// <summary>
        /// Assign each icon from the list of icons to a random square
        /// </summary>
        private void AssignIconsToSquares() //Agrega las figuras a la tabla en posiciones al azar
        {
            pairsHouseSpanish = new Dictionary<string, int>()
            {
                {"cocina", 0}, {"baño", 1}, {"sala", 2}, {"cuarto", 3},
                {"garaje", 4}, {"patio", 5}, {"sillón", 6}, {"silla", 7},
                {"mesa", 8}, {"cama", 9}, {"horno", 10}, {"ducha", 11},
                {"inodoro", 12}, {"refrigeradora", 13}, {"televisión", 14},
                {"librero", 15 }
            };

            pairsHouseEnglish = new Dictionary<string, int>()
            {
                {"kitchen", 0}, {"bathroom", 1}, {"living room", 2}, {"bedroom", 3},
                {"garage", 4}, {"yard", 5}, {"armchair", 6}, {"chair", 7},
                {"table", 8}, {"bed", 9}, {"oven", 10}, {"shower", 11},
                {"toilet", 12}, {"refrigerator", 13}, {"television", 14},
                {"bookshelf", 15 }
            };

            // The TableLayoutPanel has 16 labels,
            // and the icon list has 16 icons,
            // so an icon is pulled at random from the list
            // and added to each label

            int count = 0;
            foreach (Control control in tableLayoutPanel3erGrado.Controls)
            {
                labels[count] = control as Label;
                count++;
            }

            while (labels.Count != 0)  //string, int
            {
                Random rand1 = new Random();
                Random rand2 = new Random();
                int randomNumber1 = rand1.Next(labels.Count);
                int randomNumber2 = rand2.Next(0, pairsHouseSpanish.Count);
                KeyValuePair<string, int> pair;
                Label iconLabel = labels[randomNumber1];
                if (iconLabel != null)
                {
                    pair = pairsHouseSpanish.ElementAt(randomNumber2);
                    iconLabel.Text = pair.Key; //Pone palabra en español
                    labels.Remove(iconLabel); //Se quita de la lista el espacio que se acaba de usar
                    pairsHouseSpanish.Remove(pair.Key);

                    randomNumber1 = rand1.Next(0, labels.Count);
                    iconLabel = labels[randomNumber1];
                    pair = pairsHouseEnglish.ElementAt(randomNumber2);
                    iconLabel.Text = pair.Key; //Pone palabra equivalente en inglés

                    labels.Remove(iconLabel); //Se quita de la lista el espacio que se acaba de usar
                    pairsHouseEnglish.Remove(pair.Key);
                }
            }
        }

        public Parejas3erGrado()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void label_Click(object sender, EventArgs e) //Esto hace que cuando se les dé click aparezcan las imagenes
        {
            // The timer is only on after two non-matching 
            // icons have been shown to the player, 
            // so ignore any clicks if the timer is running
            if (timer1.Enabled == true)
            {
                return;
            }

            Label clickedLabel = sender as Label; //sender importante

            if (clickedLabel != null)
            {

                /*
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                */

                //Si la imagen es del mismo color del fondo ya se encontró
                //Se ignora el click
                if (clickedLabel.ForeColor == clickedLabel.BackColor)
                    return;

                // If firstClicked is null, this is the first icon 
                // in the pair that the player clicked,
                // so set firstClicked to the label that the player 
                // clicked, change its color to black, and return

                //Si firstClicked es null, es el primero en recibir un click
                //Se le asigna el label que el usuario clickeó, cambia de color y se retorna
                if (firstClicked == null)
                {
                    sonidos.sonidoOpcion();
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Yellow;

                    return;
                }

                //Si se llega hasta acá, firstClick no es null y le toca a secondClicked
                //Se le asigna el label que el usuario clickeó y cambia de color

                sonidos.sonidoOpcion();
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Yellow;

                // If the player clicked two matching icons, keep them 
                // black and reset firstClicked and secondClicked 
                // so the player can click another icon

                //Si se encuentran dos iconos iguales, desaparecen y 
                //firstClicked y secondClicked se ponen en null

                //Si uno esta en español y el otro esté en ingles
                if (pairsHouseSpanishReal.ContainsKey(firstClicked.Text) &&
                   pairsHouseEnglishReal.ContainsKey(secondClicked.Text))
                {
                    if (pairsHouseSpanishReal[firstClicked.Text] == pairsHouseEnglishReal[secondClicked.Text])
                    {
                        sonidos.sonidoGanarSebastian();
                        firstClicked.ForeColor = firstClicked.BackColor;
                        secondClicked.ForeColor = firstClicked.BackColor;
                        //Verificar si ya se ganó el juego
                        CheckForWinner();
                        firstClicked = null;
                        secondClicked = null;
                        return;
                    }
                }
                else if //Si uno esta en ingles y el otro este en español
                (pairsHouseEnglishReal.ContainsKey(firstClicked.Text) &&
                 pairsHouseSpanishReal.ContainsKey(secondClicked.Text))
                {
                    if (pairsHouseEnglishReal[firstClicked.Text] == pairsHouseSpanishReal[secondClicked.Text])
                    {
                        sonidos.sonidoGanarSebastian();
                        firstClicked.ForeColor = firstClicked.BackColor;
                        secondClicked.ForeColor = firstClicked.BackColor;
                        //Verificar si ya se ganó el juego
                        CheckForWinner();
                        firstClicked = null;
                        secondClicked = null;
                        return;
                    }

                }

                // If the player gets this far, the player 
                // clicked two different icons, so start the 
                // timer (which will wait three quarters of 
                // a second, and then hide the icons)
                timer1.Start();
            }
        }

        //Esto ocurre cuando se hizo click a dos que no son iguales
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Se detiene el timer
            timer1.Stop();

            //Se devuelven a su color original (Negro)
            firstClicked.ForeColor = Color.Black;
            secondClicked.ForeColor = Color.Black;

            // Reset firstClicked and secondClicked 
            // so the next time a label is
            // clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner() //Revisa que los colores de las imagenes y el fondo NO sean iguales
        {
            // Go through all of the labels in the TableLayoutPanel, 
            // checking each one to see if its icon is matched
            foreach (Control control in tableLayoutPanel3erGrado.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    //Para que solo se gane cuando el tablero esté vacío
                    if (iconLabel.ForeColor != iconLabel.BackColor)
                        return;
                }
            }

            // If the loop didn’t return, it didn't find
            // any unmatched icons
            // That means the user won. Show a message and close the form
            sonidos.sonidoTerminarBien();
            MyMsgBox.Show("YOU MATCHED ALL THE WORDS!", ":)", "OK");
            InitializeComponent();
            m3grado = new Menu3erGrado();
            m3grado.Show();
            this.Hide();
            //Close();
        }
    }
}
