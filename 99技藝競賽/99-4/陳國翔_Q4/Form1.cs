using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int a = 0, b = 0, n;
        public string[] Solove()
        {
            string[] text = new string[(n - 1) / 2 + 1];
            for (int i = 1, j = 0; i <= n; i += 2, j++)
            {
                text[j] = "".PadLeft(2 * ((n - i) / 2), ' ') + "".PadRight(i, '*');
            }
            return text;
        }
        private void Clicked(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "執行":
                    if (int.TryParse(textBox1.Text, out n) && (n & 1) != 0 && a != 0)
                    {
                        label2.Text += $"數值:{n,15}\r\n顯示方向:{((a == 1) ? "正向" : "反向")}\r\n{(b == 1 ? "設為中空" : "")}\r\n";
                        string[] result = Solove();
                        if (a == 2) result = result.Reverse().ToArray();
                        if (b == 1)
                        {
                            for (int i = 1; i < result.Length - 1; i++)
                            {
                                int start = result[i].IndexOf('*');
                                int end = result[i].LastIndexOf('*');
                                result[i] = "".PadLeft(start, ' ') + "*" + "".PadLeft(2 * (end - start) - 1, ' ') + "*";
                            }
                        }
                        label2.Text += string.Join("\r\n", result) + "\r\n";
                        a = 0;
                        b = 0;
                    }
                    else
                    {
                        MessageBox.Show("輸入一個奇數值,且須選按「正向」或「垂直反轉」。");
                    }
                    break;
                case "正向":
                    a = 1;
                    break;
                case "重直反向":
                    a = 2;
                    break;
                case "設為中空":
                    b = 1;
                    break;
                case "清除畫面":
                    label2.Text = "";
                    a = 0;
                    b = 0;
                    break;
                case "離開":
                    Application.Exit();
                    break;
            }
        }
    }
}
