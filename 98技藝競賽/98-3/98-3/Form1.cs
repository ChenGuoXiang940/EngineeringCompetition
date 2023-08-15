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

namespace _98_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static byte[] file;
        public static bool riff() => GetLine(0x00, 0x03) == "RIFF";
        public static bool wavefmt() => GetLine(0x08, 0x0E) == "WAVEfmt";
        public static bool pcm() => file[0x14] == 1 && file[0x15] == 0;
        public static bool channel() => file[0x16] == 1 && file[0x17] == 0;
        public static bool bitpersample() => file[0x22] == 8 && file[0x23] == 0;
        public static string GetLine(int start,int stop)
        {
            string tmp = "";
            for (int i = start; i <= stop; i++)
            {
                tmp += $"{Convert.ToChar(file[i])}";
            }
            return tmp;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            string path = "";
            if (open.ShowDialog() == DialogResult.OK)
            {
                path = open.FileName;
                file = File.ReadAllBytes(@path);
                if (!(riff() && wavefmt() && pcm() && channel() && bitpersample()))
                {
                    MessageBox.Show("輸入的檔案名稱不是RIFF WAVEfat、PCM格式、八位元及單聲道", $"輸入的檔案名稱：{path}");

                    TextBox1.Text = "";
                    return;
                }
                TextBox1.Text = path;
                PictureBox1.Size = new Size((int)nos(), 255);
                TextBox2.Text = "0.00000";
                TextBox3.Text = (nos() / sr()).ToString("0.00000");
                PictureBox1.Image = draw();
                HScrollBar1.Maximum = (int)nos() - Size.Width;
                HScrollBar1.Value = 0;
            }
        }
        public static double sr() => Convert.ToInt32(GetLine2(0x18, 0x1B), 16);
        public static double nos() => Convert.ToInt32(GetLine2(0x28, 0x2B), 16);
        public static string GetLine2(int start, int stop)
        {
            string tmp = "";
            for (int i = start; i <= stop; i++)
            {
                tmp = (Convert.ToString(file[i], 16)) + tmp;
            }
            return tmp;
        }
        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int y = PictureBox1.Location.Y;
            PictureBox1.Location = new Point(-HScrollBar1.Value, y);
            TextBox2.Text = (nos() / Math.Pow(sr(), 2) * (HScrollBar1.Value + Size.Width)).ToString("0.00000");
        }
        public Bitmap draw()
        {
            Bitmap bitmap = new Bitmap((int)nos(), 255);
            Graphics g = Graphics.FromImage(bitmap);
            g.TranslateTransform(0, PictureBox1.Height / 2);
            g.DrawLine(Pens.Green, 0, 0, (int)nos(), 0);
            for(int i = 0x2C; i <= 0x2C + nos(); i++)
            {
                float x = i - 0x2C;
                float y = file[i] - 0x80;
                g.DrawLine(Pens.Green, x, y, x, -y);
            }
            return bitmap;
        }
    }
}
