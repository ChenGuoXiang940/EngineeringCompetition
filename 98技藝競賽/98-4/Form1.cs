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

namespace _98_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open1= new OpenFileDialog();
            if (open1.ShowDialog() == DialogResult.OK)
            {
                StreamReader din = new StreamReader(open1.FileName);
                textBox1.Text = open1.FileName;
                double[] arr = din.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
                double[] arr1 = new double[50];
                double[] arr2 = new double[50];
                double[] arr3 = new double[50];
                double[] arr4 = new double[50];
                double len = arr[19] + arr[18] + arr[17] + arr[16] + arr[15];
                double len2 = 0;
                for (int i = 0; i < 20; i++)
                {
                    len2 += arr[i];
                }
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "";
                string str4 = "";
                for (int i = 19; i < arr.Length; i++)
                {
                    str += arr[i].ToString("00.00") + " ";
                    arr1[i - 19] = len / 5;
                    arr2[i - 19] = len2 / 20;
                    arr3[i - 19] = len / 5 - len2 / 20 - 0.005;
                    str1 += arr1[i - 19].ToString("00.00") + " ";
                    str2 += arr2[i - 19].ToString("00.00") + " ";
                    str3 += arr3[i - 19].ToString("00.00") + " ";
                    if (i != arr.Length - 1)
                    {
                        len = len + arr[i + 1] - arr[i - 4];
                        len2 = len2 + arr[i + 1] - arr[i - 19];
                    }
                }
                for (int i = 19; i < arr.Length + 4; i++)
                {
                    arr4[i - 19] = (4 * arr[i - 4] - arr[i - 19]) / 3;
                    str4 += arr4[i - 19].ToString("00.00") + " ";
                }
                textBox3.Text = str + "00.00 00.00 00.00 00.00";
                textBox4.Text = str1 + "00.00 00.00 00.00 00.00";
                textBox5.Text = str2 + "00.00 00.00 00.00 00.00";
                textBox6.Text = str3 + "00.00 00.00 00.00 00.00";
                textBox7.Text = str4.TrimEnd(' ');
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter w = new StreamWriter(open.FileName);
                    textBox2.Text = open.FileName;
                    w.WriteLine("成交值:" + textBox3.Text);
                    w.WriteLine("5日平均值:" + textBox4.Text);
                    w.WriteLine("20日平均值:" + textBox5.Text);
                    w.WriteLine("多空值:" + textBox6.Text);
                    w.WriteLine("預測值:" + textBox7.Text);
                    w.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
