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
    public partial class Animals : Form
    {
        AnimalsFlashCards afc;
        Menu2doGrado m2;
        AnimalsQuestions aq;

        public Animals()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            afc = new AnimalsFlashCards();
            this.Hide();
            afc.Show();
        }

        private void backB_Click(object sender, EventArgs e)
        {
            m2 = new Menu2doGrado();
            this.Hide();
            m2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aq = new AnimalsQuestions();
            this.Hide();
            aq.Show();
        }
    }
}
