using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace 陳國翔_Q1
{
    public partial class Form1 : Form
    {
        Data[] arr = {new Data("09 12 33 47 53 67 78 92"),
            new Data("48 81"),
            new Data("13 41 62"),
            new Data("01 03 45 47"),
            new Data("14 16 24 44 46 55 57 64 74 82 87 98"),
            new Data("10 31"),
            new Data("06 25"),
            new Data("23 39 50 56 65 68"),
            new Data("32 70 73 83 88 93"),
            new Data("15")};
        Bitmap bitmap = new Bitmap(100, 100);
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            AdjustableArrowCap lineCap = new AdjustableArrowCap(6, 6, true);
            Pen pen = new Pen(Color.Black, 4);
            pen.CustomEndCap = lineCap;
            g.DrawLine(pen, 50, 10, 50, 90);
            pictureBox1.Image = pictureBox2.Image = bitmap;
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            char[] ch = textBox1.Text.ToUpper().ToCharArray();
            string ans = "";
            Array.ForEach(ch, item => ans += (item >= 'A' && item <= 'J') ? arr[item - 'A'].get() + " " : "");
            textBox2.Text = ans.TrimEnd(' ');
        }
    }
    class Data
    {
        public string[] num;
        public int sq;
        public Data(string text)
        {
            this.num = text.Split(' ');
            this.sq = 0;
        }
        public string get()
        {
            if (sq == num.Length) sq = 0;
            return num[sq++];
        }
    }
}
