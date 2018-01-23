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
    public partial class Parejas6toGrado : Form
    {
        Menu1erGrado m1grado;

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

        Dictionary<string, int> pairsCRSpanish = new Dictionary<string, int>()
        {
            {"padre", 0}, {"madre", 1}, {"hermano", 2}, {"hermana", 3},
            {"abuelo", 4}, {"abuela", 5}, {"tio", 6}, {"tía", 7},
            {"hijo", 8}, {"hija", 9}, {"mascota", 10}, {"sobrino", 11},
            {"sobrina", 12}, {"nieto", 13}, {"nieta", 14}
        };

        Dictionary<string, int> pairsCREnglish = new Dictionary<string, int>()
        {
            {"father", 0}, {"mother", 1}, {"brother", 2}, {"sister", 3},
            {"grandpa", 4}, {"grandma", 5}, {"uncle", 6}, {"aunt", 7},
            {"son", 8}, {"daughter", 9}, {"pet", 10}, {"nephew", 11},
            {"niece", 12}, {"grandson", 13}, {"granddaugther", 14}
        };

        Dictionary<string, int> pairsCRSpanishReal = new Dictionary<string, int>()
        {
            {"padre", 0}, {"madre", 1}, {"hermano", 2}, {"hermana", 3},
            {"abuelo", 4}, {"abuela", 5}, {"tio", 6}, {"tía", 7},
            {"hijo", 8}, {"hija", 9}, {"mascota", 10}, {"sobrino", 11},
            {"sobrina", 12}, {"nieto", 13}, {"nieta", 14}
        };

        Dictionary<string, int> pairsCREnglishReal = new Dictionary<string, int>()
        {
            {"father", 0}, {"mother", 1}, {"brother", 2}, {"sister", 3},
            {"grandpa", 4}, {"grandma", 5}, {"uncle", 6}, {"aunt", 7},
            {"son", 8}, {"daughter", 9}, {"pet", 10}, {"nephew", 11},
            {"niece", 12}, {"grandson", 13}, {"granddaugther", 14}
        };


        /// <summary>
        /// Assign each icon from the list of icons to a random square
        /// </summary>
        private void AssignIconsToSquares() //Agrega las figuras a la tabla en posiciones al azar
        {
            // The TableLayoutPanel has 16 labels,
            // and the icon list has 16 icons,
            // so an icon is pulled at random from the list
            // and added to each label

            int count = 0;
            foreach (Control control in tableLayoutPanel6toGrado.Controls)
            {
                labels[count] = control as Label;
                count++;
            }

            while (labels.Count != 0)  //string, int
            {
                Random rand1 = new Random();
                Random rand2 = new Random();
                int randomNumber1 = rand1.Next(labels.Count);
                int randomNumber2 = rand2.Next(0, pairsCRSpanish.Count);
                KeyValuePair<string, int> pair;
                Label iconLabel = labels[randomNumber1];
                if (iconLabel != null)
                {
                    pair = pairsCRSpanish.ElementAt(randomNumber2);
                    iconLabel.Text = pair.Key; //Pone palabra en español
                    labels.Remove(iconLabel); //Se quita de la lista el espacio que se acaba de usar
                    pairsCRSpanish.Remove(pair.Key);

                    randomNumber1 = rand1.Next(labels.Count);
                    iconLabel = labels[randomNumber1];
                    pair = pairsCREnglish.ElementAt(randomNumber2);
                    iconLabel.Text = pair.Key; //Pone palabra equivalente en inglés

                    labels.Remove(iconLabel); //Se quita de la lista el espacio que se acaba de usar
                    pairsCREnglish.Remove(pair.Key);
                }
            }
        }

        public Parejas6toGrado()
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
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Yellow;

                    return;
                }

                //Si se llega hasta acá, firstClick no es null y le toca a secondClicked
                //Se le asigna el label que el usuario clickeó y cambia de color

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Yellow;

                // If the player clicked two matching icons, keep them 
                // black and reset firstClicked and secondClicked 
                // so the player can click another icon

                //Si se encuentran dos iconos iguales, desaparecen y 
                //firstClicked y secondClicked se ponen en null

                //Si uno esta en español y el otro esté en ingles
                if (pairsCRSpanishReal.ContainsKey(firstClicked.Text) &&
                   pairsCREnglishReal.ContainsKey(secondClicked.Text))
                {
                    if (pairsCRSpanishReal[firstClicked.Text] == pairsCREnglishReal[secondClicked.Text])
                    {
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
                (pairsCREnglishReal.ContainsKey(firstClicked.Text) &&
                 pairsCRSpanishReal.ContainsKey(secondClicked.Text))
                {
                    if (pairsCREnglishReal[firstClicked.Text] == pairsCRSpanishReal[secondClicked.Text])
                    {
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
            foreach (Control control in tableLayoutPanel6toGrado.Controls)
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
            MessageBox.Show("You matched all the icons!", "Congratulations");
            InitializeComponent();
            m1grado = new Menu1erGrado();
            m1grado.Show();
            this.Hide();
            //Close();
        }
    }
}
