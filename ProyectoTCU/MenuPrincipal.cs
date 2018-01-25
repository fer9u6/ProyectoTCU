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
    public partial class MenuPrincipal : Form
    {
        Menu1erGrado m1grado;
        Menu2doGrado m2grado;
        Menu3erGrado m3grado;
        Menu4toGrado m4grado;
        Menu5toGrado m5grado;
        Menu6toGrado m6grado;

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m1grado = new Menu1erGrado();
            m1grado.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m2grado = new Menu2doGrado();
            m2grado.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m3grado = new Menu3erGrado();
            m3grado.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m4grado = new Menu4toGrado();
            m4grado.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m5grado = new Menu5toGrado();
            m5grado.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            m6grado = new Menu6toGrado();
            m6grado.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Size = new Size(129, 40);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new Size(124, 35);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Size = new Size(129, 40);
        }

        private void button3_MouseHover_1(object sender, EventArgs e)
        {
            button3.Size = new Size(129, 40);
        }

        private void button3_MouseLeave_1(object sender, EventArgs e)
        {
            button3.Size = new Size(124, 35);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.Size = new Size(129, 40);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Size = new Size(124, 35);
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.Size = new Size(129,40);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Size = new Size(124,35);
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.Size = new Size(129, 40);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Size = new Size(124, 35);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Size = new Size(124,35);
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.Size = new Size(80,33);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.Size = new Size(75, 28);
        }
    }
}
