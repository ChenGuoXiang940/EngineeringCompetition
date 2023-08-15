using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _90_1_1
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public static TextBox[] tb = new TextBox[8];
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 8; i++)
            {
                tb[i] = new TextBox()
                {
                    Text = "",
                    Font = new Font("Default", 15),
                    Size = new Size(40, 40),
                    Location = new Point(40 + 50 * i, 20)
                };
                panel1.Controls.Add(tb[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            List<int> list = new List<int>();
            int c = 8;
            while (c != 0)
            {
                int target = rnd.Next(1, 43);
                if (!list.Contains(target))
                {
                    list.Add(target);
                    c--;
                }
            }
            list = list.OrderBy(x => x).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                tb[i].Text = list[i].ToString();
            }
        }
        public static int count = 0;
        public static List<int> num = new List<int>();
        public static string[] arr = new string[6];
        public void dfs(int target, bool[]fg)
        {
            if (target == 5)
            {
                richTextBox1.Text += $"({++count}){string.Join(",", arr).TrimEnd(',')}\r\n";
                return;
            }
            for (int i = 5; i > 0; i--)
            {
                if (!fg[i - 1])
                {
                    fg[i - 1] = true;
                    arr[target] = $"{num[i - 1]}";
                    dfs(target + 1, fg);
                    fg[i - 1] = false;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            count = 0;
            num.Clear();
            num = tb.Select(x => int.Parse(x.Text)).ToList();
            int c = 3;
            while (c != 0)
            {
                num.RemoveAt(rnd.Next(0, num.Count));
                c--;
            }
            bool[] fg = new bool[6];
            num.Reverse();
            dfs(0, fg);
        }
    }
}
