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
    public partial class Menu4toGrado : Form
    {
        MenuPrincipal mp;
        Parejas4toGrado par;
        Preguntas4toGrado preg;

        public Menu4toGrado()
        {
            InitializeComponent();
        }

        private void backB_Click(object sender, EventArgs e)
        {
            mp = new MenuPrincipal();
            mp.Show();
            this.Hide();
        }

        private void backB_MouseHover(object sender, EventArgs e)
        {
            backB.Size = new Size(75,65);
        }

        private void backB_MouseLeave(object sender, EventArgs e)
        {
            backB.Size = new Size(70,60);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            par = new Parejas4toGrado();
            par.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            preg = new Preguntas4toGrado();
            preg.Show();
            this.Hide();
        }
    }
}
