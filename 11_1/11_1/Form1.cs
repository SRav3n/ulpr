using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = trackBar1.Value;

            int Formule1 (int n)
            {
                int sum = 0;
                for (int i = 1; i <= n; i++)
                {
                    int sign = (i % 2 == 0) ? 1 : -1;
                    sum += sign * (int)Math.Pow(i, 4);
                }
                return sum;
            }

            int formule1 = Formule1(N);
            double formule2 = Math.Pow(-1, (double)N) * ((Math.Pow(N, 4) + 2 * Math.Pow(N, 3) - N)/2);
            textBox2.Text = formule1.ToString() + " = " + formule2.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar1.Value.ToString();
        }
    }
}
