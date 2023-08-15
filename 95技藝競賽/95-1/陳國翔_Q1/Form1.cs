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
        public static bool check(int v)
        {
            int m = v % 6;
            if (m != 1 && m != 5) return false;
            int sq = (int)Math.Sqrt(v);
            for (int i = 5; i <= sq; i += 6)
            {
                if (v % i == 0 || v % (i + 2) == 0) return false;
            }
            return true;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Stack<int> stack = new Stack<int>();
                int t = int.Parse(textBox1.Text);
                if (t >= 2) stack.Push(2);
                if (t >= 3) stack.Push(3);
                for (int n = 5; n <= t; n += 6)
                {
                    if (check(n)) stack.Push(n);
                    if (check(n + 2)) stack.Push(n + 2);
                }
                label2.Text = $"質數個數有{stack.Count,10}     個";
                string ans = "";
                int count = 0;
                while (stack.Count != 0 && count++ < 3)
                {
                    ans = stack.Pop() + "   " + ans;
                }
                label3.Text = $"最大的3個質數是{ans.TrimEnd(' ')}";
            }
            catch (Exception)
            {
                //nothing...
            }
        }
    }
}
