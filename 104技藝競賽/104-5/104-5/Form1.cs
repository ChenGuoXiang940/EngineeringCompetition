using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _104_5
{
    public partial class Form1 : Form
    {
        public static TextBox[] input = new TextBox[49];
        public static TextBox[] output = new TextBox[49];
        public static TextBox[] k = new TextBox[9];
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 3; i++)
            {
                groupBox2.Controls.AddRange(getlabel(i).ToArray());
                for (int j = 0; j < 3; j++)
                {
                    k[i * 3 + j] = gettextbox(i, j);
                }
            }
            for(int i = 0; i < 7; i++)
            {
                groupBox1.Controls.AddRange(getlabel(i).ToArray());
                groupBox3.Controls.AddRange(getlabel(i).ToArray());
                for (int j = 0; j < 7; j++)
                {
                    input[i * 7 + j] = gettextbox(i, j);
                    output[i * 7 + j] = gettextbox(i, j);
                }
            }
            groupBox1.Controls.AddRange(input);
            groupBox2.Controls.AddRange(k);
            groupBox3.Controls.AddRange(output);
        }
        public static TextBox gettextbox(int i,int j)
        {
            return new TextBox()
            {
                Text = "0",
                TextAlign = HorizontalAlignment.Center,
                Font = new Font("Default", 9),
                Location = new Point(50 + 40 * i, 50 + 40 * j),
                Size = new Size(35, 35)
            };
        }
        public static Control[] getlabel(int i)
        {
            Label[] label = new Label[2];
            label[0] = new Label()
            {
                Text = i.ToString(),
                Font = new Font("Default", 9),
                Location = new Point(50 + 40 * i, 30),
                Size = new Size(15, 15)
            };
            label[1] = new Label()
            {
                Text = i.ToString(),
                Font = new Font("Default", 9),
                Location = new Point(30, 50 + 40 * i),
                Size = new Size(15, 15)
            };
            return label;
        }
        public static int[,] map = new int[7, 7];
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    map[i, j] = 0;
                }
            }
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    if (input[i * 7 + j].Text != "0")
                    {
                        solove(i - 1, j - 1, int.Parse(input[i * 7 + j].Text));
                    }
                }
            }
            double mse = 0;
            double mae = 0;
            for (int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    output[i * 7 + j].Text = map[i, j].ToString();
                    mse += Math.Pow(int.Parse(input[i * 7 + j].Text) - int.Parse(output[i * 7 + j].Text), 2);
                    mae += Math.Abs(int.Parse(input[i * 7 + j].Text) - int.Parse(output[i * 7 + j].Text));
                }
            }
            mse /= 49;
            mae /= 49;
            textBox1.Text = $"{mse}";
            textBox2.Text = $"{mae}";
            textBox3.Text = $"{10 * Math.Log10(255 * 255 / mse)}";
        }
        public static void solove(int i,int j,int target)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    if ((i + a) * 7 + (j + b) >= 0 && (i + a) * 7 + (j + b) < 49)
                    {
                        map[i + a, j + b] += int.Parse(k[a * 3 + b].Text) * target;
                    }
                }
            }
        }
    }
}
