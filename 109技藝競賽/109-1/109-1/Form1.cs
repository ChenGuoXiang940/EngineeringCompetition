using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace _109_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label4.Text = "";
            label5.Text = "";
        }
        public static string[] chineseDigits = { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
        public static string[] placeValues = { "","拾", "佰", "仟" };
        public static string[] largePlaceValues = {"", "萬", "億", "兆" };
        public static string solve(long val)
        {
            string result = "";
            int cur = 0;
            int index = 0;
            bool hasNonZeroDigit = false;
            double check = (double)val % 1E8 / 1E5;
            bool check2 = val >= 1E8;
            while (val> 0)
            {
                int digit = (int)(val % 10);
                if (cur % 4 == 0)
                {
                    result = largePlaceValues[index] + result;
                    hasNonZeroDigit = false;
                    index++;
                }
                if (hasNonZeroDigit && digit == 0)
                {
                    result = chineseDigits[0] + result;
                }
                if (digit > 0)
                {
                    result = chineseDigits[digit] + placeValues[cur % 4] + result;
                    hasNonZeroDigit = true;
                }
                val /= 10;
                cur++;
            }
            result = result.Replace("兆億萬", "兆").Replace("億萬", "億").Replace("零零零", "零").Replace("零零", "零");
            if (check < 1 && check2) return result.Insert(result.IndexOf('億') + 1, "零");
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            long val;
            if (textBox1.Text.Length > 14 || !long.TryParse(textBox1.Text, out val) || val < 0)
            {
                MessageBox.Show("超過範圍，請重新輸入", "提示");
                return;
            }
            label4.Text = $"{val:n0}";
            label5.Text = solve(val);
        }
    }
}
