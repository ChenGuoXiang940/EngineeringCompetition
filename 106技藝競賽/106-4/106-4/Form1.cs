using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _106_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            double max = double.Parse(TextBox2.Text);
            double study = double.Parse(TextBox3.Text);
            string[] all = TextBox1.Text.Split(new string[] { "\r\n",}, StringSplitOptions.RemoveEmptyEntries);
            double[] w = TextBox4.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            List<Data> col = new List<Data>();
            foreach (string item in all)
            {
                col.Add(new Data(item));
            }
            int k = 0;
            double E = 0;
            while (true)
            {
                double f = 0;
                for (int i = 0; i < 3; i++)
                {
                    f += w[i] * col[k].num[i];
                }
                if (Math.Sign(f) != col[k].num[3])
                {
                    for (int i = 0; i < 3; i++)
                    {
                        w[i] = w[i] + study * (col[k].num[3] - Math.Sign(f)) * col[k].num[i];
                    }
                }
                E = E + 0.5 * Math.Pow(Math.Abs(col[k].num[3] - Math.Sign(f)), 2);
                if (++k == col.Count)
                {
                    if (E == 0) break;
                    E = 0;
                    k = 0;
                }
            }
            string[] ans = w.Select(x => x.ToString("0.00")).ToArray();
            TextBox5.Text = String.Join(";", ans);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double[] new1 = TextBox9.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            double[] w = TextBox4.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            double f = 0;
            for(int i = 0; i < 3; i++)
            {
                f += new1[i] * w[i];
            }
            Label9.Text = $"機器人向：" + (Math.Sign(f) == 1 ? "左" : "右");
        }
    }
    public class Data
    {
        public double[] num = new double[4];
        public Data (string s)
        {
            this.num = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
        }
    }
}
