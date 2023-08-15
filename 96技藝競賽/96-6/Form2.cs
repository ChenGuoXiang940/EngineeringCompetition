using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _96_6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //9907 68269
            //2854212172437551217228542
            //18407627003178645118
            long D = Int64.Parse(textBox1.Text);
            long N = Int64.Parse(textBox2.Text);
            int len = N.ToString().Length;
            string line = textBox3.Text;
            string ans = "";
            for (int i = 0; i < line.Length; i += len)
            {
                long val = Int64.Parse(Form1.get(Int64.Parse(line.Substring(i, len)), D, N));
                if (val < 127)/*在byte範圍內*/
                {
                    ans += Convert.ToChar(val);
                }
                else
                {
                    ans += Encoding.GetEncoding("big5").GetString(new byte[] { (byte)(val >> 8), (byte)val });
                }
            }
            textBox4.Text = ans;
        }
    }
}
