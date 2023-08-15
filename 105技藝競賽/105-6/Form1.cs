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
using System.Drawing.Drawing2D;

namespace _105_6
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap2, bitmap1;
        public static Graphics g2;
        public static bool fg;
        public Form1()
        {
            bitmap2 = new Bitmap(450, 400);
            g2 = Graphics.FromImage(bitmap2);
            Font font = new Font("Default", 20);
            Pen pen = new Pen(Color.White, 5);
            pen.DashStyle = DashStyle.Dot;
            g2.DrawRectangle(pen, 5, 5, 440, 390);
            g2.DrawString("Drag or Double Click to\r\n     Select an Image", font, Brushes.White, 90, 100);
            InitializeComponent();
            pictureBox1.Image = bitmap2;
        }
        private void DoubleCheck(object sender, MouseEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                /*勿使用AutoSize=>會改變RGB值*/
                bitmap1 = new Bitmap(Image.FromFile(open.FileName));
                pictureBox2.BackgroundImage = bitmap1;
                pictureBox2.Visible = true;
                button1.Text = "Reveal The Image Behind";
                fg = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            string filename = (e.Data.GetData((DataFormats.FileDrop)) as string[])[0];//取得檔案位置
            bitmap1 = new Bitmap(Image.FromFile(filename));
            pictureBox2.BackgroundImage = bitmap1;
            pictureBox2.Visible = true;
            button1.Text = "Reveal The Image Behind";
            fg = true;
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;/*拖曳效果*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (PictureBox items in Controls.OfType<PictureBox>())
            {
                if (((PictureBox)items).Name.Contains("pictureBox"))
                {
                    items.AllowDrop = true;//允許拖曳
                    items.DragDrop += DragDrop;
                    items.DragEnter += DragEnter;
                }
            }       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fg)/*有放照片時方可做處理*/
            {
                Form2 f2 = new Form2();
                f2.Visible = true;
                fg = false;
            }
        }
    }
}
