using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int[] nation = { 957, 986 };
        public static int[] publishing = { 157, 204, 421, 442, 7198, 7323, 8573 };
        private void button1_Click(object sender, EventArgs e)
        {
            //957442355
            //957857358
            //98673230A
            //---------
            //ISBN-10
            char[] ch = textBox1.Text.ToCharArray().Where(c => c >= '0' && c <= '9').ToArray();
            if (ch.Length != 9)
            {
                MessageBox.Show("輸入號碼不對");
                return;
            }
            int s = 0, a = 10;
            Array.ForEach(ch, item => s += (item - '0') * a--);
            int m = s % 11;
            int n = 11 - m;
            string text = textBox1.Text;
            string record = textBox1.Text;
            if(nation.Contains(int.Parse(text.Substring(0,3))))
            {
                record = record.Insert(3, "-");
                text = text.Substring(3);
            }
            if(publishing.Contains(int.Parse(text.Substring(0, 3))))
            {
                record = record.Insert(7, "-");
                text = text.Substring(3);
            }
            else if(publishing.Contains(int.Parse(text.Substring(0, 4))))
            {
                record = record.Insert(8, "-");
                text = text.Substring(4);
            }
            textBox2.Text = $"{record}-{n}";
            //ISBN-13
            char[] ch2 = ("978" + textBox1.Text).ToCharArray();
            int s2 = 0, check = 1;
            Array.ForEach(ch2, item => s2 += (check++) % 2 == 1 ? 1 * (item - '0') : 3 * (item - '0'));
            int m2 = s2 % 10;
            int n2 = 10 - m2;
            string text2 = string.Join("", ch2);
            string record2 = string.Join("", ch2);
            record2 = record2.Insert(3, "-");
            text2 = text2.Substring(3);
            if(nation.Contains(int.Parse(text2.Substring(0, 3))))
            {
                record2 = record2.Insert(7, "-");
                text2 = text2.Substring(3);
            }
            if (publishing.Contains(int.Parse(text2.Substring(0, 3))))
            {
                record2 = record2.Insert(11, "-");
                text2 = text2.Substring(3);
            }
            else if (publishing.Contains(int.Parse(text2.Substring(0, 4))))
            {
                record2 = record2.Insert(12, "-");
                text2 = text2.Substring(4);
            }
            textBox3.Text = $"{record2}-{n2}";
        }
    }
}
