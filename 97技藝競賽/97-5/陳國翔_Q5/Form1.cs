using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace 陳國翔_Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader din = new StreamReader(@textBox1.Text, Encoding.GetEncoding("big5"));
            StreamWriter sw = new StreamWriter(@textBox2.Text);
            string[] all = din.ReadToEnd().Split(new string[] { "\r\n", "日別", "最高價", "最低價", "收盤價" }, StringSplitOptions.RemoveEmptyEntries);
            double[] high = all[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(item => double.Parse(item)).ToArray();
            double[] low = all[2].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(item => double.Parse(item)).ToArray();
            double[] closing = all[3].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(item => double.Parse(item)).ToArray();
            double[] k = new double[12];
            double[] d = new double[12];
            k[7] = double.Parse(textBox3.Text);
            d[7] = double.Parse(textBox4.Text);
            SortedSet<double> s1 = new SortedSet<double>();
            SortedSet<double> s2 = new SortedSet<double>();
            for (int i = 0; i < 12; i++)
            {
                s1.Add(high[i]);
                s2.Add(low[i]);
                if (i >= 8)
                {
                    double rsv = (closing[i] - s2.Min()) / (s1.Max() - s2.Min()) * 100;
                    k[i] = 2 * k[i - 1] / 3 + rsv / 3;
                    d[i] = 2 * d[i - 1] / 3 + k[i] / 3;
                    s1.Remove(high[i - 7]);
                    s2.Remove(low[i - 7]);
                }
            }
            sw.WriteLine(string.Join(" ", k.Select(item => Math.Round(item, 2).ToString("0.00"))));
            sw.WriteLine(string.Join(" ", d.Select(item => Math.Round(item, 2).ToString("0.00"))));
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
