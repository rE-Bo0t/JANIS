using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Xml;

namespace JanisMark4
{
    public partial class JanisMainForm : Form
    {
        #region Properties
        string que = "";
        bool bul = true;
        bool bol = true;
        int index = 0;
        #endregion
        #region SystemFuncs


        public JanisMainForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                bol = true;
                button1.Enabled = true;
            }
        }

        public void CloseForm()
        {
            switch (textBox1.Text.ToUpper())
            {
                case "EXIT":
                case "QUIT":
                case "BYE":
                case "GOODBYE":
                    Janis.Talk("Good Bye sir");
                    this.Close();
                    break;
                case "GO AWAY":
                    Janis.Talk("thats rude.. Bye");
                    this.Close();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseForm();
            Janis.Talk(Janis.InputAnalysis(textBox1.Text));
            /*
            if (bol == true)
            {
                Janis.Talk(Janis.InputAnalysis(textBox1.Text));
            }
            else
            {
                Janis.Talk(QueAnalysis.AnswerAnalysis(textBox1.Text, que));
            }*/

            textBox1.Text = "";
            button1.Enabled = false;
            //response.Start();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Janis.Intro();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    button1.PerformClick();
                    break;

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bul)
            {
                this.WindowState = FormWindowState.Maximized;
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
                Janis.Talk("Maximizing. I recommend that you leave me in normal size");
                bul = false;
                return;
            }
            this.WindowState = FormWindowState.Normal;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            Janis.Talk("Thank You.");
            bul = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Janis.Talk("I am still here. Forever");
            this.WindowState = FormWindowState.Minimized;
        }

        private void response_Tick(object sender, EventArgs e)
        {
            index++;
            bol = true;
            if (index == 100)
            {
                index = 0;
                que = QueAnalysis.RandomQuestion();
                Janis.Talk(que);
                bol = false;
                response.Stop();
                response.Enabled = false;
            }
        }
        
        #endregion



       



    }
}
