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
    public partial class MyMsgBox : Form
    {
        public MyMsgBox()
        {
            InitializeComponent();
        }

        static MyMsgBox MsgBox; static DialogResult result = DialogResult.No;
       
        public static DialogResult Show(string Text, string Caption, string btnOK)
        {
            MsgBox = new MyMsgBox();
            MsgBox.label1.Text = Text;
            MsgBox.button1.Text = btnOK;
            MsgBox.Text = Caption;
            result = DialogResult.No;
            MsgBox.ShowDialog();
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes; MsgBox.Close();
        }
    }
}
