using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102_1
{
    public partial class Form1 : Form
    {
        public static TextBox[][] tb;
        public static Panel[] panels;
        public Form1()
        {
            InitializeComponent();
            panels = new Panel[] { panel1, panel2 };
            tb = new TextBox[2][];
            tb[0] = new TextBox[36];
            tb[1] = new TextBox[9];
            for(int i = 0; i < 36; i++)
            {
                tb[0][i] = new TextBox()
                {
                    Location = new Point(i % 6 * 40, i / 6 * 40),
                    Size = new Size(35, 25),
                    Multiline = false,
                    Font = new Font("Consolas", 9),
                    TextAlign = HorizontalAlignment.Center
                };
                panel1.Controls.Add(tb[0][i]);
            }         
            this.groupBox1.Controls.Add(panels[0]);
            for(int i = 0; i < 9; i++)
            {
                tb[1][i] = new TextBox()
                {
                    Location = new Point(i % 3 * 40, i / 3 * 40),
                    Size = new Size(35, 25),
                    Multiline = false,
                    Font = new Font("Consolas", 9),
                    TextAlign = HorizontalAlignment.Center
                };
                panel2.Controls.Add(tb[1][i]);
            }
            this.groupBox2.Controls.Add(panels[1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Int16.Parse(textBox1.Text);
            int y = Int16.Parse(textBox2.Text);
            int[,] map = new int[3, 3];
            for(int i = y; i < y + 3; i++)
            {
                for(int j= x ; j < x + 3; j++)
                {
                    map[i, j] = Int16.Parse(tb[0][i * 6 + j].Text);
                }
            }
            int total = 0;
            int cmp = map[y + 1, x + 1];
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (map[i, j] > cmp)
                    {
                        total += Int16.Parse(tb[1][i * 3 + j].Text);
                    }
                }
            }
            textBox3.Text = total.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
