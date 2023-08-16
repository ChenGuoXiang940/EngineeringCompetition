using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*遞迴執行效率比迴圈快*/
        public static double pow(double a,int b)/*Fast Power費馬小定理*/
        {
            if (b == 0) return 1;
            if ((b & 1) == 0) return pow(a * a, b / 2);
            return a * pow(a * a, b / 2);
        }
        public static int bs(double val,int left,int right)/*Binay Search二分搜尋法*/
        {
            int mid = (left + right) / 2;
            if (left > right) return left;
            if (pow(2, mid) < val) return bs(val, mid + 1, right);
            else return bs(val, left, mid - 1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //-1 2
            //0.637197
            //1000101110110101000111

            //-3.0 12.1
            //1.0524
            //010001001011010000
            double max = double.Parse(textBox2.Text);
            double min = double.Parse(textBox1.Text);
            int f = int.Parse(textBox3.Text);
            double item = (max - min) * pow(10, f);
            int bits = bs(item, 0, 25);
            if (textBox4.Text.Contains('.'))
            {
                double input = double.Parse(textBox4.Text);
                double ans = (input - min) * (pow(2, bits) - 1) / (max - min);
                label5.Text = $"Ans = {Convert.ToString((int)Math.Round(ans), 2).PadLeft(bits, '0')}";
            }
            else
            {
                double input = Convert.ToInt32(textBox4.Text, 2);
                double ans = min + input * (max - min) / (pow(2, bits) - 1);
                label5.Text = $"Ans = {Math.Round(ans, f)}";
            }
        }
    }
}
