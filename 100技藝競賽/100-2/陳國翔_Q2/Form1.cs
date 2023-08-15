using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //10.168.100.253/30
            //10.168.137.88/26
            //10.1.255.24/8
            string[] arr1 = textBox1.Text.Split('/');
            int mask = int.Parse(arr1[1]);
            string maskstr = "".PadLeft(mask, '1').PadRight(32, '0');
            int[] ip = arr1[0].Split('.').Select(item => int.Parse(item)).ToArray();
            int[] masks = new int[4];
            for(int i = 0; i < 4; i++)
            {
                masks[i] = Convert.ToInt32(maskstr.Substring(i * 8, 8), 2);
            }
            int[] network = new int[4];
            for(int i = 0; i < 4; i++)
            {
                network[i] = ip[i] & masks[i];
            }
            int maskbar = 32 - mask;
            string maskbarstr = "".PadLeft(maskbar, '1').PadLeft(32, '0');
            int[] maskbars = new int[4];
            for(int i = 0; i < 4; i++)
            {
                maskbars[i] = Convert.ToInt32(maskbarstr.Substring(i * 8, 8), 2);
            }
            int[] host = new int[4];
            for(int i = 0; i < 4; i++)
            {
                host[i] = network[i] ^ maskbars[i];
            }
            int available = (int)Math.Pow(2, maskbar) - 2;
            textBox2.Text = String.Join(".", network);
            textBox3.Text = String.Join(".", host);
            textBox4.Text = $"{available}";
        }
    }
}
