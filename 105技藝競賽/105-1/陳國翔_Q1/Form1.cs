using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string getx(int i)
        {
            if (i < 10) return $"{i}";
            return $"{Convert.ToChar('A'+i-10)}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int v = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            List<string> col = new List<string>();
            while (v != 0)
            {
                int n = v / b;
                int n2 = v / b + 1;
                int n3 = v / b - 1;
                if (v - n * b >= 0)
                {
                    col.Add(getx(v - n * b));
                    v = n;
                }
                else if (v - n2 * b >= 0)
                {
                    col.Add(getx(v - n2 * b));
                    v = n2;
                }
                else
                {
                    col.Add(getx(v - n3 * b));
                    v = n3;
                }
            }
            col.Reverse();
            textBox3.Text = string.Join(" ", col);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
