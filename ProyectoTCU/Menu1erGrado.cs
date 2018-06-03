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
    public partial class Menu1erGrado : Form
    {
        MenuPrincipal mp;
        Classroom c;
        Neighborhood nei;
        Parejas1erGrado par;
        Preguntas1erGrado preg;
        ListenPlaces lp;
        ClassroomVocabulary cv;
        MenuClassroom mc;
        MenuNeighborhood mn;
        IzqDer1erGrado izde;

        public Menu1erGrado()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mn = new MenuNeighborhood();
            this.Hide();
            mn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // c = new Classroom();
            cv = new ClassroomVocabulary();
            mc = new MenuClassroom();
            this.Hide();
            mc.Show();
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
            par = new Parejas1erGrado();
            par.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            preg = new Preguntas1erGrado();
            preg.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            izde = new IzqDer1erGrado();
            izde.Show();
            this.Hide();
        }
    }
}
