using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int pow(long a,long b,long c)
        {
            long s = 1;/*用int會有整數溢位*/
            while (b != 0)
            {
                if ((b & 1) == 1)
                {
                    s = a * s % c;
                }
                a = a * a % c;
                b >>= 1;
            }
            return (int)s;
        }
        public static Byte[]GetByte(char item)//中文解碼有兩個Byte
        {
            return Encoding.GetEncoding("big5").GetBytes($"{item}");
        }
        private void button1_Click(object sender, EventArgs e1)
        {
            //8315 68269
            //RSA
            //電腦軟體設計
            int e = int.Parse(textBox1.Text);
            int n = int.Parse(textBox2.Text);
            char[] ch = textBox3.Text.ToCharArray();
            string ans = "";//判斷是不是中文 ASCII:0~127  中文:>127
            Array.ForEach(ch, item => ans += (int)item <= 127 ? $"{pow(item - '\0', e, n)}" : $"{pow(GetByte(item)[0] << 8 | GetByte(item)[1], e, n)}");
            textBox4.Text = ans;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //9907 68269
            //2854212172437551217228542
            //18407627003178645118
            int d = int.Parse(textBox5.Text);
            int n = int.Parse(textBox6.Text);
            int len = textBox6.Text.Length;
            string text = textBox7.Text;
            string ans = "";
            int len2 = text.Length / len;
            for(int i = 0; i < len2; i++)
            {
                long val = pow(int.Parse(text.Substring(len * i, len)), d, n);//每N的字串長度就分割處理
                ans += val <= 127 ? $"{Convert.ToChar(val)}" : Encoding.GetEncoding("big5").GetString(new byte[] { (byte)(val >> 8), (byte)val });
            }
            textBox8.Text = ans;
        }
    }
}
