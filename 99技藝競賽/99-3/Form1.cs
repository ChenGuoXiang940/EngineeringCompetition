using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _99_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] arr = { "資料筆數", "輸入資料", "算術平均數", "標準差", "幾何平均數", "均方根平均數", "調和平均數" };
            for(int i = 0; i < arr.Length; i++)
            {
                dgv.Columns.Add(arr[i], arr[i]);
            }
            dgv.AutoResizeColumns();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static List<double> col = new List<double>();
        public static string gets()
        {
            double n1 = 0;
            double n2 = 0;
            for(int i = 0; i < col.Count; i++)
            {
                n1 += Math.Pow(col[i], 2);
                n2 += col[i];
            }
            n1 *= col.Count;
            n2 = Math.Pow(n2, 2);
            string s = col.Count != 1 ? string.Format("{0:0.000}", Math.Sqrt((n1 - n2) / (col.Count * (col.Count - 1)))) : "0";
            return s;
        }
        public static string getg()
        {
            double g = 1;
            for(int i = 0; i < col.Count; i++)
            {
                g *= col[i];
            }
            return string.Format("{0:0.000}", Math.Pow(g, (double)1 / col.Count));
        }
        public static string getr()
        {
            double r = 0;
            for(int i = 0; i < col.Count; i++)
            {
                r += Math.Pow(col[i], 2);
            }
            return string.Format("{0:0.000}", Math.Sqrt(r / col.Count));
        }
        public static string geth()
        {
            double h = 0;
            for(int i = 0; i < col.Count; i++)
            {
                h += ((double)1 / col[i]);
            }
            return string.Format("{0:0.000}", col.Count / h);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            col.Add(double.Parse(textBox2.Text));
            label2.Text = col.Count >= Int16.Parse(textBox1.Text) ? label2.Text = "資料已輸入完畢!" : $"請輸入第{col.Count + 1}筆資料";
            if (col.Count <= Int16.Parse(textBox1.Text))
            {
                string[] region = { col.Count.ToString(), textBox2.Text, string.Format("{0:0.00}", col.Average()), gets(), getg(), getr(), geth() };
                dgv.Rows.Add(region);
                textBox2.Text = "";
                if (col.Count == Int16.Parse(textBox1.Text)) textBox2.Enabled = false;
            }
        }
    }
}
