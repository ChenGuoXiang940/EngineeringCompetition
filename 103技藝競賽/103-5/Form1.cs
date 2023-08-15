using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _103_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int n = 3;
            List<string> check = new List<string>() { "0", "7", "4", "1", "8", "5", "2", "9", "6", "3" };
            try
            {
                int n1 = Int32.Parse(textBox1.Text);
                int n2 = Int32.Parse(textBox2.Text);
                for(int i = n1; i <= n2; i++)
                {
                    int v = i;
                    int r = 0;
                    int c = 8;
                    while (v != 0)
                    {
                        r += c-- * (v % 10);
                        v /= 10;
                    }
                    richTextBox1.Text += i.ToString() + check[r % 10] + "@antu.edu.tw;";
                    n++;
                    if (n % 3 == 0 && n != 3) richTextBox1.Text += "\r\n";
                }
                List<int> person = textBox3.Text.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).Select<string, int>(x => Int32.Parse(x)).ToList();
                for(int i = 0; i < person.Count; i++)
                {
                    int v = person[i];
                    int r = 0;
                    int c = 8;
                    while (v != 0)
                    {
                        r += c-- * (v % 10);
                        v /= 10;
                    }
                    richTextBox1.Text += person[i].ToString() + check[r % 10] + "@antu.edu.tw;";
                    n++;
                    if (n % 3 == 0 && n != 3) richTextBox1.Text += "\r\n";
                }
                richTextBox1.Text= richTextBox1.Text.TrimEnd(';');
            }
            catch(Exception ex)
            {
                //nothing...
            }
        }
    }
}
