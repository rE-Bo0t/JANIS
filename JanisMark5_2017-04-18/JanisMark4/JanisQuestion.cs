using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanisMark4
{
    public partial class JanisQuestion : Form
    {
        static string Answer;
        public JanisQuestion()
        {
            InitializeComponent();
        }
        public JanisQuestion(string Question)
        {
            InitializeComponent();
            label1.Text = Question;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Answer = textBox1.Text;
            Janis.UserName = Answer;
            this.Close();
            
        }
    }
}
