using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _98_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            label3.Text = "";
            label4.Text = "";
        }
        public static Data[] col;
        private void set(object sender, EventArgs e)
        {
            int val;
            try
            {
                val = int.Parse(textBox1.Text);
                if (val > 8) return;
            }
            catch(Exception)
            {
                return;
            }
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            label3.Text = "";
            label4.Text = "";
            groupBox1.Text = $"請輸入{textBox1.Text}個點座標:x和y值";
            groupBox2.Text = $"請輸入測試點的座標:x和y值";
            List<Data> col2 = new List<Data>();
            groupBox1.Controls.Clear();
            for (int i = 0; i < val; i++)
            {
                col2.Add(new Data(i, 70, 20 + 40 * i, 110, 20 + 40 * i));
                this.groupBox1.Controls.Add(col2[i].label1);
                this.groupBox1.Controls.Add(col2[i].tb1);
                this.groupBox1.Controls.Add(col2[i].tb2);
            }
            col = col2.ToArray();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = double.Parse(textBox5.Text);
                double y1 = double.Parse(textBox6.Text);
                double max = 0;
                int path = -1;
                for (int i = 0; i < col.Length; i++)
                {
                    double v = Math.Sqrt(Math.Pow(double.Parse(col[i].tb1.Text) - x1, 2) + Math.Pow(double.Parse(col[i].tb2.Text) - y1, 2));
                    if (max < v)
                    {
                        max = v;
                        path = i;
                    }
                }
                textBox2.Text = max.ToString();
                label3.Text = $"測試點與x{path + 1}距離最遠";
            }
            catch(Exception)
            {
                MessageBox.Show("輸入錯誤!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = double.Parse(textBox5.Text);
                double y1 = double.Parse(textBox6.Text);
                double min = 1000;
                int path = -1;
                for (int i = 0; i < col.Length; i++)
                {
                    double v = Math.Sqrt(Math.Pow(double.Parse(col[i].tb1.Text) - x1, 2) + Math.Pow(double.Parse(col[i].tb2.Text) - y1, 2));
                    if (min > v)
                    {
                        min = v;
                        path = i;
                    }
                }
                textBox3.Text = min.ToString();
                label4.Text = $"測試點與x{path + 1}距離最近";
            }
            catch (Exception)
            {
                MessageBox.Show("輸入錯誤!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = double.Parse(textBox5.Text);
                double y1 = double.Parse(textBox6.Text);
                double total = 0;
                Array.ForEach(col, item => total += Math.Sqrt(Math.Pow(double.Parse(item.tb1.Text) - x1, 2) + Math.Pow(double.Parse(item.tb2.Text) - y1, 2)));
                textBox4.Text = (total / col.Length).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("輸入錯誤!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
                Pen penB = new Pen(Color.Blue, 2);
                Pen penG = new Pen(Color.Green, 2);
                Pen penR = new Pen(Color.Red, 2);
                for(int i = 0; i < 13; i++)
                {
                    g.DrawLine(penB, 10, 10 + i * 20, 250, 10 + i * 20);
                    g.DrawLine(penB, 10 + i * 20, 10, 10 + i * 20, 250);
                }
                for(int i = 0; i <= 6; i++)
                {
                    g.DrawString(i.ToString(), Font, Brushes.Blue, 3, 248 - 40 * i);
                    g.DrawString(i.ToString(), Font, Brushes.Blue, 3 + 40 * i, 248);
                }
                g.DrawString("x", Font, Brushes.Blue, 0, 0);
                g.DrawString("y", Font, Brushes.Blue, 253, 250);
                for(int i = 0; i < col.Length; i++)
                {
                    g.DrawString($"x{i + 1}", Font, Brushes.Blue, 15 + float.Parse(col[i].tb1.Text) * 40, 245 - float.Parse(col[i].tb2.Text) * 40);
                    g.DrawEllipse(penR, 9 + float.Parse(col[i].tb1.Text) * 40, 249 - float.Parse(col[i].tb2.Text) * 40, 3, 3);
                }
                g.DrawString($"x", Font, Brushes.Blue, 15 + float.Parse(textBox5.Text) * 40, 245 - float.Parse(textBox6.Text) * 40);
                g.DrawEllipse(penG, 9 + float.Parse(textBox5.Text) * 40, 249 - float.Parse(textBox6.Text) * 40, 3, 3);

            }
            catch (Exception)
            {
                if (textBox1.Text == "") MessageBox.Show("C中點數輸入錯誤，先預設8個點，來畫出點的分佈。請再輸入一次!");
                else MessageBox.Show("輸入順序錯誤!");
            }
        }
    }
    public class Data
    {
        public Label label1;
        public TextBox tb1, tb2;
        public Data(int name,int x1,int y1,int x2,int y2)
        {
            this.label1= new Label()
            {
                Text = $"第x{name + 1}點座標",
                Location = new Point(10, 20 + 40 * name),
                Size = new Size(60, 40),
                Font = new Font("新細明體", 9),
                ForeColor = Color.Black
            };
            this.tb1 = GetText(x1, y1);
            this.tb2 = GetText(x2, y2);
        }
        public static TextBox GetText(int x, int y)
        {
            return new TextBox()
            {
                Location = new Point(x, y),
                Size = new Size(30, 40),
                Font = new Font("新細明體", 9),
                ForeColor = Color.Black
            };
        }
    }
}
