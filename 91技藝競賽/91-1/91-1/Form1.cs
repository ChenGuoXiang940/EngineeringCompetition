using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _91_1
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public static TextBox[] text = new TextBox[81];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            start = -1;
            stop = -1;
            label2.Text = $"Obstacles(20~50):";
            label3.Text = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    text[i * 9 + j] = new TextBox()
                    {
                        Text = "",
                        ReadOnly = true,
                        Font = new Font("Default", 21),
                        BackColor = Color.White,
                        TextAlign = HorizontalAlignment.Center,
                        Size = new Size(40, 40),
                        Location = new Point(40 * j, 40 * i)
                    };
                    panel1.Controls.Add(text[i * 9 + j]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int val = rnd.Next(20, 51);
            label2.Text = $"Obstacles(20~50):{val}";
            while (val != 0)
            {
                int target = rnd.Next(0, 81);
                if (text[target].BackColor != Color.Black)
                {
                    val--;
                    text[target].BackColor = Color.Black;
                }
            }
        }
        public static int start = -1;
        public static int stop = -1;
        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 81; i++)
            {
                if (text[i].BackColor == Color.Yellow)
                {
                    text[i].BackColor = Color.White;
                }
            }
            if (start != -1 && stop != -1)
            {
                text[start].Text = "";
                text[stop].Text = "";
            }
            int val = 2;
            while (val != 0)
            {
                int target = rnd.Next(0, 81);
                if (text[target].BackColor != Color.Black && target != stop)
                {
                    switch (val)
                    {
                        case 1:
                            text[target].Text = "S";
                            start = target;
                            break;
                        case 2:
                            text[target].Text = "T";
                            stop = target;
                            break;
                    }
                    val--;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static int[,] moved = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        public static bool check(int x,int y,int target)
        {
            int x1 = target % 9;
            int y1 = target / 9;
            if (x1 + x < 0 || x1 + x > 8) return false;
            if (y1 + y < 0 || y1 + y > 8) return false;
            return true;
        }
        public static Data[] map = new Data[81];
        public static void dfs(int target)
        {
            for(int i = 0; i < 4; i++)
            {
                if (!check(moved[i, 0], moved[i, 1], target)) continue;
                int target2 = target + moved[i, 0] + moved[i, 1] * 9;
                if (text[target2].BackColor != Color.Black && (map[target2] == null || map[target].total + 1 <= map[target2].total))
                {
                    map[target2] = new Data(map[target].total + 1, text[target2], map[target]);
                    dfs(target2);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            map[start] = new Data(0, text[start]);
            dfs(start);
            Data final = map[stop];
            if (final != null)
            {
                while (final != null)
                {
                    final.text.BackColor = Color.Yellow;
                    final = final.father;
                }
                label3.Text = "YES";
            }
            else
            {
                label3.Text = "No";
            }
            for(int i = 0; i < 81; i++)
            {
                map[i] = null;
            }
        }
    }
    public class Data
    {
        public int total;
        public TextBox text;
        public Data father;
        public Data(int total,TextBox text ,Data father = null)
        {
            this.total = total;
            this.text = text;
            this.father = father;
        }
    }
}
