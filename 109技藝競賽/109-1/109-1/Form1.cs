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
            MessageBox.Show("test2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            List<string> str = new List<string>() { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
            List<string> str2 = new List<string>() { "", "拾", "佰", "仟" };
            List<string> str3 = new List<string>() { "萬", "億", "兆" };
            List<char> ch = new List<char>() { '拾', '十', '佰', '仟' };
            if (s1.Length <= 14 && s1[0] != '-')
            {
                string s2 = "";
                string s3 = "";
                int count = 0;
                int count2 = 0;
                int number = 0;
                for (int i = s1.Length - 1; i >= 0; i--)
                {
                    s2 = s1[i] + s2;
                    s3 = str[Int16.Parse(s1[i].ToString())] + str2[count2++] + s3;
                    count++;
                    if (count == 3)
                    {
                        s2 = "," + s2;
                        count = 0;
                    }
                    if (count2 == 4)
                    {
                        s3 = str3[number++] + s3;
                        count2 = 0;
                    }
                }
                label4.Text = s2.TrimStart(',');
                List<char> display = s3.TrimStart('萬').TrimStart('億').TrimStart('兆').ToList();
                Stack<(char, char, char)> check = new Stack<(char, char, char)>();
                char c1=' ', c2=' ';
                int len = 0;
                for (int i = display.Count - 1; i >= 0; i--)
                {
                    if (display[i] == '萬'||display[i]=='億'||display[i]=='兆')
                    {
                        c1 = display[i];
                        c2 = ' ';
                    }
                    else if (ch.Contains(display[i]))
                    {
                        c2 = display[i];
                    }
                    else
                    {
                        if (display[i] != '零')
                        {
                            check.Push((display[i], c2, c1));
                            len = 0;
                        }
                        else if (display[i] == '零'&& len == 0)
                        {
                            check.Push(('零', c2, c1));
                            len++;
                        }
                    }
                }
                string final = "";
                char c3 = '*';
                for(int i=check.Count - 1; i >= 0; i--)
                {
                    if (check.ElementAt(i).Item1 == '零' && i == check.Count - 1)
                    {
                        continue;
                    }
                    if (i - 1 >= 0 && check.ElementAt(i).Item1 == '零' && check.ElementAt(i - 1).Item3 == '萬' && check.ElementAt(i + 1).Item2 == '仟')
                    {
                        continue;
                    }
                    else if(i - 1 >=0 && check.ElementAt(i).Item1 == '零'&&check.ElementAt(i - 1).Item2 == '億' && check.ElementAt(i + 1).Item3 == '萬')
                    {
                        continue;
                    }
                    else
                    {
                        if (check.ElementAt(i).Item1 == '零')
                        {
                            final = "零" + final;
                        }
                        else
                        {
                            if (c3 != check.ElementAt(i).Item3)
                            {
                                c3 = check.ElementAt(i).Item3;
                                final = c3 + final;
                            }
                            final = check.ElementAt(i).Item1.ToString() + check.ElementAt(i).Item2.ToString() + final; 
                        }
                    }
                }
                final = final.Replace(" ", "");
                label5.Text = final;
            }
            else
            {
                MessageBox.Show("超過範圍 請重新輸入");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
