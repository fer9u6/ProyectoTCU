using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace ProyectoTCU
{
    public partial class Prepositions : Form
    {
        
        MenuClassroom mc;

        public Prepositions()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //on
            try
            {
                SoundPlayer s = new SoundPlayer(Properties.Resources.on_audio);
                s.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //under
            try
            {
                SoundPlayer s = new SoundPlayer(Properties.Resources.under_audio);
                s.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //between
            try
            {
                SoundPlayer s = new SoundPlayer(Properties.Resources.between_audio);
                s.Play();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //next to 
            try
            {
                SoundPlayer s = new SoundPlayer(Properties.Resources.next_to_audio);
                    s.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //in front of
            try
            {
                SoundPlayer s = new SoundPlayer(Properties.Resources.in_front_of_audio);
                s.Play();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //behind
            try
            {
                SoundPlayer s = new SoundPlayer(Properties.Resources.behind_audio);
                s.Play();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void labelinstruction_Click(object sender, EventArgs e)
        {

        }

        private void backB_Click(object sender, EventArgs e)
        {
            mc = new MenuClassroom();
            this.Hide();
            mc.Show();
        }
        
    }
}
