using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(textBox2.Text);
                int result = n * n;
                textBox3.Text = result.ToString();
            }
            catch(Exception)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("бебебе");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int p = int.Parse(textBox1.Text);
            int Result(int n)
            {
                int sum = 0;
                for (int i = 1; i <= 2*n-1; i+=2)
                {
                    sum += i;
                }
                return sum;
            }

            int result = Result(p);
            textBox3.Text = result.ToString();
        }
    }
}
