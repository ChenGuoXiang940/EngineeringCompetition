using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace _96_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string get(long m,long e,long n)
        {
            /*費馬小定理 */
            /*ex:2 ^ 13 % 5 : 8192 % 5 = 2
             * ans = 1
             * m = 2
             * e = 13(10):1101(2)
             * n = 5
             * start:
             * e = 1101(2)
             * 1. (1 => true)
             * ===>ans = 1 * 2 % 5 = 2
             * m = 2 * 2 % 5 = 4;
             * e = 110 (2)
             * 2. (0 => false)
             * m = 4 * 4 % 5 = 1
             * e = 11 (2)
             * 3. (1 => true)
             * ===>ans = 2 * 1 % 5 = 2
             * m = 1 * 1 % 5 = 1
             * e = 1 (2)
             * 4. (1 => true)
             * ===>ans = 2 * 1 % 5 = 2
             * m = 1 * 1 % 5 = 1
             * e = 0 (2) : break;
             * result : ans = 2
            */
            long ans = 1;
            while (e > 0)
            {
                if (e % 2 == 1)
                {
                    ans = ans * m % n;
                }
                m = m * m % n;
                e >>= 1;
            }
            return ans.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int E = int.Parse(textBox1.Text);
            int N = int.Parse(textBox2.Text);
            string str = textBox3.Text;/*可以輸入中,英文,數字混合的字串*/
            string ans = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (('A' <= str[i] && str[i] <= 'Z') || ('a' <= str[i] && str[i] <= 'z') || ('0' <= str[i] && str[i] <= '9'))
                {
                    ans += get((long)Encoding.ASCII.GetBytes(str[i].ToString())[0], E, N);//英文ascii
                }
                else
                {
                    ans += get((long)Encoding.GetEncoding("big5").GetBytes(str[i].ToString())[0] << 8 | (long)Encoding.GetEncoding("big5").GetBytes(str[i].ToString())[1], E, N);//中文big5
                }
            }
            textBox4.Text = ans;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();            
            Form2 f2 = new Form2();
            f2.Visible = true;
            f1.Visible = false;
        }
    }
}
