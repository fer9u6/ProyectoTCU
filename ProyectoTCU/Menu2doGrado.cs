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
    public partial class Menu2doGrado : Form
    {
        MenuPrincipal mp;
        Parejas2doGrado par;
        Preguntas2doGrado preg;
        IzqDer2doGrado izde;

        public Menu2doGrado()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void backB_MouseHover(object sender, EventArgs e)
        {
            backB.Size = new Size(75,65);
        }

        private void backB_MouseLeave(object sender, EventArgs e)
        {
            backB.Size = new Size(70,60);
        }

        private void backB_Click(object sender, EventArgs e)
        {
            mp = new MenuPrincipal();
            mp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            par = new Parejas2doGrado();
            par.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            preg = new Preguntas2doGrado();
            preg.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InitializeComponent();
            izde = new IzqDer2doGrado();
            izde.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            InitializeComponent();
            par = new Parejas2doGrado();
            par.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Animals animals = new Animals();
            animals.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Numbers n = new Numbers();
            n.Show();
            this.Hide();
        }

        private void Menu2doGrado_Load(object sender, EventArgs e)
        {

        }
    }
}
