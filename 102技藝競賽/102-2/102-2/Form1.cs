using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Random rnd = new Random();
        public static string Getfloat(double val)
        {
            string b2 = "";
            while (val != 0 && b2.Length != 10)
            {
                val *= 2;
                if (val >= 1)
                {
                    b2 += "1";
                    val--;
                }
                else
                {
                    b2 += "0";
                }
            }
            return b2;
        }
        private void Clicked(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Random":
                    TextBox1.Text = $"{rnd.Next(0, 10000)}.{rnd.Next(0, 10000000)}";
                    break;
                case "Convert":
                    try
                    {
                        string[] arr = TextBox1.Text.Split('.').ToArray();
                        arr[0] = Convert.ToString(int.Parse(arr[0]), 2);
                        arr[1] = Getfloat(double.Parse($"0.{arr[1]}"));
                        TextBox2.Text = $"{arr[0]}.{arr[1]}";
                        TextBox3.Text = $"{arr[0]}.{arr[1].TrimEnd('0')}";
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    break;
                case "Exit":
                    Application.Exit();
                    break;
            }
        }
    }
}
