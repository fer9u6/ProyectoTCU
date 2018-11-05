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
    public partial class Numbers : Form
    {
        FlashCardsNumbers fcnumbers;
        Menu2doGrado m2;
        MathOperations mo;


        public Numbers()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fcnumbers = new FlashCardsNumbers();
            this.Hide();
            fcnumbers.Show();

        }

        private void backB_Click(object sender, EventArgs e)
        {
            m2 = new Menu2doGrado();
            this.Hide();
            m2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mo = new MathOperations();
            this.Hide();
            mo.Show();
        }
    }
}
