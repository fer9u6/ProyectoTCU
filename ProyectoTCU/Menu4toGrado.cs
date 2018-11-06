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
        Mensaje msj;
        IzqDer4toGrado izde;

        public Menu4toGrado()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            msj = new Mensaje();
            this.Closed += (s, ev) => Application.Exit();
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
            
            EscogerSaludos es = new EscogerSaludos();
            es.Show();
            this.Hide();
            msj.neutralMensaje("Look at the picture and choose\nthe correct option according to\n the situation.");
           
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            socializingOrdenar so = new socializingOrdenar();
            this.Hide();
            so.Show();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
           
            mm = new MemoryMatch();
            this.Hide();
            mm.Show();
            //msj.neutralMensaje("Match all the cards.\nClick any two cards and \ntry remember it position.");
            Instructions instructions = new Instructions();
            instructions.memory();
            instructions.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            d = new Diseases();
            this.Hide();
            d.Show();
            msj.neutralMensaje("Look at the picture and choose\nthe correct option according to\n the situation.");
           
        }

        /*
        private void button5_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            par = new Parejas4toGrado();
            par.Show();
            this.Hide();
        }
        */

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

        private void button8_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            izde = new IzqDer4toGrado();
            izde.Show();
            this.Hide();
        }
    }
}
