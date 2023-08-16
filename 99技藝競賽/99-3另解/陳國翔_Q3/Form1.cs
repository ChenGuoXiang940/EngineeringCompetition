using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] str = { "輸入筆數", "輸入資料", "算術平均數", "標準差", "幾何平均數", "均方根平均數", "調和平均數" };
            Array.ForEach(str, item => dgv.Columns.Add(item, item));
            button1.Enabled = false;
        }
        public static int n = 0;
        public static List<double> col;
        public string get(double val)
        {
            return (val - 0.0005).ToString("0.000");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            col.Add(double.Parse(textBox2.Text));
            double avg = col.Average();
            double totalx = col.Sum();
            double xpow = 0;
            col.ForEach(item => xpow += item * item);
            double xmult = 1;
            col.ForEach(item => xmult *= item);
            double xfraction = 0;
            col.ForEach(item => xfraction += 1 / item);
            //---
            string[] arr = {
                $"{col.Count}",
                $"{textBox2.Text}",
                (avg-0.005).ToString("0.00"),
                (col.Count != 1)?get(Math.Sqrt((col.Count * xpow - totalx * totalx)/(col.Count*(col.Count-1)))):"0.000",
                get(Math.Pow(xmult,(double)1/col.Count)),
                get(Math.Sqrt(xpow/col.Count)),
                get(col.Count/xfraction-0.0005)};
            dgv.Rows.Add(arr);
            //---
            label2.Text = $"請輸入第{col.Count + 1}筆資料";
            textBox2.Text = "";
            if (col.Count == n)
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Changed(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text,out n) && n >= 1)
            {
                dgv.Rows.Clear();
                col = new List<double>();
                label2.Text = "請輸入第1筆資料";
                button1.Enabled = true;
                textBox2.Text = "";
            }
        }
    }
}
