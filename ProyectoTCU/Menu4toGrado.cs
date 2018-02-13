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
        SocializingTraining st;
        //socializingOrdenar so;
        MemoryMatch mm;
        Diseases d;
        Parejas4toGrado par;
        Preguntas4toGrado preg;
        EscogerSaludos es;
        Mensaje msj;

        public Menu4toGrado()
        {
            InitializeComponent();
            msj = new Mensaje();
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
            st = new SocializingTraining();
            st.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            es = new EscogerSaludos();
            this.Hide();
            es.Show();
            msj.neutralMensaje("Look at the picture and choose\nthe correct option according to\n the situation.");
           
        }

        /*
        private void button5_Click(object sender, EventArgs e)
        {
            socializingOrdenar so = new socializingOrdenar();
            this.Hide();
            so.Show();
        }
        */

        private void button4_Click(object sender, EventArgs e)
        {
            mm = new MemoryMatch();
            this.Hide();
            mm.Show();
            msj.neutralMensaje("Match all the cards.\nClick any two cards and \ntry remember it position.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            d = new Diseases();
            this.Hide();
            d.Show();
            msj.neutralMensaje("Look at the picture and choose\nthe correct option according to\n the situation.");
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

        private void button7_Click(object sender, EventArgs e)
        {
            socializingOrdenar so = new socializingOrdenar();
            this.Hide();
            so.Show();
            msj.neutralMensaje("Drag the words that make\n a correct sentence.");
        }
    }
}
