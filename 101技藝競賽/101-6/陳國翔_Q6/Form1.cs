using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 陳國翔_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<List<int>> map = new List<List<int>>();
        public static int[,] moved = { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 } };
        public static bool check(int x,int y)
        {
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7) return true;
            return false;
        }
        public static string path = "";
        public static bool fg = false;
        public static void dfs(int x,int y)
        {
            for(int i = 0; i < 8; i++)
            {
                if (fg) return;
                if (check(x + moved[i, 0], y + moved[i, 1]) && map[y + moved[i, 1]][x + moved[i, 0]] == 0)
                {
                    map[y + moved[i, 1]][x + moved[i, 0]] = 1;
                    path += $"({y + moved[i, 1]},{x + moved[i, 0]})";
                    if (y + moved[i, 1] == 7 && x + moved[i, 0] == 7)
                    {
                        fg = true;
                        return;
                    }
                    dfs(x + moved[i, 0], y + moved[i, 1]);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader din = File.OpenText(@textBox1.Text);
            string line = "";
            path = "(0,0)";
            fg = false;
            map.Clear();
            while (!string.IsNullOrEmpty(line = din.ReadLine()))
            {
                map.Add(line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList());
            }
            dfs(0, 0);
            textBox2.Text = path;
        }
    }
}
