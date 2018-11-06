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
    public partial class Colors : Form
    {
        colorsCards fc;
        PlayColors pc;
        Menu1erGrado m1;
        Instructions instructions;

        public Colors()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            instructions = new Instructions();
            this.Closed += (s, ev) => Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Width = 105;
           // pictureBox1.Height = 85;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
           // pictureBox1.Width = 100;
           // pictureBox1.Height = 80;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fc = new colorsCards();
            fc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pc = new PlayColors();
            this.Hide();
            pc.Show();
            instructions.puffles();
            instructions.Show();
        }

        private void backB_Click(object sender, EventArgs e)
        {
            m1 = new Menu1erGrado();
            this.Hide();
            m1.Show();
        }
    }
}
