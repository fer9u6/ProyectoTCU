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
    public partial class MathOperations : Form
    {
        Numbers numbers;
        Dictionary<int, Image> images;
        Dictionary<int, SoundPlayer> sounds;
        List<int> nums1;
        List<int> nums2;
        Random r = new Random();
        int currentIndex; // index of both lists of numbers
        int currentAnswer;

        public MathOperations()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
            images = new Dictionary<int, Image>();
            sounds = new Dictionary<int, SoundPlayer>();
            nums1 = new List<int>();
            nums2 = new List<int>();
            currentIndex = 0;
            currentAnswer = 0;
           

            images.Add(1, Properties.Resources.oneapples);
            images.Add(2, Properties.Resources.twoapples);
            images.Add(3, Properties.Resources.threeapples);
            images.Add(4, Properties.Resources.fourapples);
            images.Add(5, Properties.Resources.fiveapples);
            images.Add(6, Properties.Resources.sixapples);
            images.Add(7, Properties.Resources.sevenapples);
            images.Add(8, Properties.Resources.eightapples);
            images.Add(9, Properties.Resources.nineapples);
            images.Add(10, Properties.Resources.tenapples);

            sounds.Add(1, new SoundPlayer(Properties.Resources.one_audio));
            sounds.Add(2, new SoundPlayer(Properties.Resources.two_audio));
            sounds.Add(3, new SoundPlayer(Properties.Resources.three_audio));
            sounds.Add(4, new SoundPlayer(Properties.Resources.four_audio));
            sounds.Add(5, new SoundPlayer(Properties.Resources.five_audio));
            sounds.Add(6, new SoundPlayer(Properties.Resources.six_audio));
            sounds.Add(7, new SoundPlayer(Properties.Resources.seven_audio));
            sounds.Add(8, new SoundPlayer(Properties.Resources.eight_audio));
            sounds.Add(9, new SoundPlayer(Properties.Resources.nine_audio));
            sounds.Add(10, new SoundPlayer(Properties.Resources.ten_audio));

            nums1.Add(4);
            nums2.Add(3);
            nums1.Add(5);
            nums2.Add(2);
            nums1.Add(8);
            nums2.Add(2);
            nums1.Add(3);
            nums2.Add(1);
            nums1.Add(4);
            nums2.Add(2);
            nums1.Add(9);
            nums2.Add(7);
            nums1.Add(6);
            nums2.Add(3);
            nums1.Add(10);
            nums2.Add(5);
            nums1.Add(7);
            nums2.Add(2);
            nums1.Add(5);
            nums2.Add(4);
            nums1.Add(9);
            nums2.Add(1);
            nums1.Add(2);
            nums2.Add(1);

        }

        private void chooseOperation() {
            pictureBoxCheck.Image = null;
            if (currentIndex < 12)
            {
                int op = r.Next(1, 3);
                int n1 = nums1.ElementAt(currentIndex);
                int n2 = nums2.ElementAt(currentIndex);
                String sim = "";
                if (op == 1)//suma
                {
                    currentAnswer = n1 + n2;
                    sim = "+";
                }
                else
                {
                    currentAnswer = n1 - n2;
                    sim = "-";
                }

                if (currentAnswer > 10)
                {
                    currentAnswer = n1 - n2;
                    sim = "-";
                }

                pictureBoxNum1.Image = images[n1];
                pictureBoxNum2.Image = images[n2];
                pictureBoxResp.Image = images[currentAnswer];
                labelNum1.Text = "" + n1;
                labelNum2.Text = "" + n2;
                labelOp.Text = sim;
                // buttons

                int b = r.Next(1,3);
                if (b == 1)
                {
                    button1.Text = "" + currentAnswer;
                    button2.Text = "" + r.Next(1, 11);
                }
                else {
                    button2.Text = "" + currentAnswer;
                    button1.Text = "" + r.Next(1, 11);
                }
                
                currentIndex++;
            }
            else {
                fin();
            }
        }

        private void checkAnswer(int a)
        {
            if (a == currentAnswer)
            {
                //correct
                try
                {
                    sounds[currentAnswer].Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
                labelResp.Text = "" + currentAnswer;
                labelResp.BackColor = Color.Lime;
                pictureBoxCheck.Image = Properties.Resources.check;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();
                labelResp.Text = "?";
                labelResp.BackColor = Color.White;
                chooseOperation();

            }
            else {

                //bad
                pictureBoxCheck.Image = Properties.Resources.equis;
                Task taskA = Task.Factory.StartNew(() => imagenRespuesta());
                taskA.Wait();
                pictureBoxCheck.Image = null;

            }
           

        }

        private void imagenRespuesta()
        {
            System.Threading.Thread.Sleep(2000);
        }

        private void fin()
        {
            currentIndex = 0;
            currentAnswer = 0;
            pictureBoxNum1.Image = null;
            pictureBoxNum2.Image = null;
            pictureBoxResp.Image = null;
            labelNum1.Text = "#";
            labelNum2.Text = "#";
            labelOp.Text = "+";
            button3.Show();//playbutton

        }
        private void backB_Click(object sender, EventArgs e)
        {
            numbers = new Numbers();
            this.Hide();
            numbers.Show();
        }

        private void labelNum2_Click(object sender, EventArgs e)
        {

        }

        private void labelResp_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check
            Button b = sender as Button;
            checkAnswer(Int32.Parse(b.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //play
            chooseOperation();
            button3.Hide();
        }
    }
}
