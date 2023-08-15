using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _90_1_3
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public static List<Data> tb = new List<Data>();
        public static List<TextBox> tb2 = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();
            Reset();
        }
        public void Reset()
        {
            tb.Clear();
            tb2.Clear();
            for (int i = 0; i < 42; i++)
            {
                tb.Add(new Data(GetText($"{i + 1}", 100 + (i % 21) * 20, 300 + (i / 21) * 20, 20), rnd.Next(0, 4)));
                panel1.Controls.Add(tb[i].text);
            }
            for (int i = 0; i < 6; i++)
            {
                tb2.Add(GetText("", 30 * i, 0, 30));
                panel2.Controls.Add(tb2[i]);
            }
        }
        public static TextBox GetText(string name,int x,int y,int size)
        {
            return new TextBox()
            {
                Text = name,
                ReadOnly = true,
                Font = new Font("Consolas", 10),
                Size = new Size(size,size),
                Location = new Point(x, y)
            };
        }
        public static int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            count = 0;
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (count == 6)
            {
                for (int i = 0; i < tb.Count; i++)
                {
                    tb[i].text.Visible = true;
                }
                for (int i = 0; i < tb2.Count; i++)
                {
                    tb2[i].Text = "";
                }
                count = 0;
            }
            int target;
            while (true)
            {
                target = rnd.Next(0, 42);
                if (tb[target].text.Visible is true)
                {
                    break;
                }
            }
            tb2[count++].Text = tb[target].text.Text;
            tb[target].text.Visible = false;
            if (count == 1)
            {
                timer1.Start();
            }
        }
        public static bool check(int x,int y)
        {
            if (x < 0 || x > 584 || y < 0 || y > 384) return false;
            else return true;
        }
        public static int[,] moved = new int[4, 2] { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < 42; i++)
            {
                Point point = tb[i].text.Location;
                int dire = tb[i].dire;
                point = new Point(point.X + moved[dire, 0] * rnd.Next(1, 5), point.Y + moved[dire, 1] * rnd.Next(1, 5));
                if (check(point.X, point.Y))
                {
                    tb[i].text.Location = new Point(point.X, point.Y);
                }
                else
                {
                    tb[i].dire = rnd.Next(0, 4);
                }
            }
        }
    }
    public class Data
    {
        public TextBox text;
        public int dire;
        public Data(TextBox text,int dire)
        {
            this.text = text;
            this.dire = dire;
        }
    }
}
