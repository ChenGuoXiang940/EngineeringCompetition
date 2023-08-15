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

namespace _107_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 選取資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                StreamReader din = File.OpenText(open.FileName);
                string line;
                int count = 0;
                TextBox1.Text = "";
                TextBox2.Text = "";
                while (!string.IsNullOrEmpty(line = din.ReadLine()))
                {
                    TextBox1.Text += $"麵{++count}:{line}\r\n";
                }
            }
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 求F統計值和自由度dfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] all = TextBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<Data> col = new List<Data>();
            foreach(string item in all)
            {
                List<string> vs = item.Split(new string[] { " ", ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                vs.RemoveAt(0);
                col.Add(new Data(vs.Select(x => double.Parse(x)).ToList()));
            }
            double dfb = col.Count - 1;
            double dfw = Data.n - col.Count;
            double UT = Data.total / Data.n;
            double ssw = 0, ssb = 0;
            for(int i = 0; i < col.Count; i++)
            {
                for(int j = 0; j < col[i].num.Count; j++)
                {
                    ssw += Math.Pow(col[i].num[j] - col[i].uti, 2);
                }
                ssb += col[i].num.Count * Math.Pow(col[i].uti - UT, 2);
            }
            double msb = ssb / dfb;
            double msw = ssw / dfw;
            TextBox2.Text = $"F自由值統計:\r\nF={Math.Round(msb / msw, 3)}\r\n自由值{dfb}，{dfw}";
        }
    }
    public class Data
    {
        public List<double> num;
        public double uti;
        public static double total = 0;
        public static int n = 0;
        public Data(List<double> num)
        {
            this.num = num;
            uti = num.Average();
            total += num.Sum();
            n += num.Count;
        }
    }
}
