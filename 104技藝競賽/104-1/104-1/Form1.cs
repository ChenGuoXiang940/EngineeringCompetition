using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hi = System.Collections.Generic.HashSet<int>;

namespace _104_1
{
    public partial class Form1 : Form
    {
        public static TextBox[] tx = new TextBox[16];
        public static TextBox mouse;
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 16; i++)
            {
                tx[i] = new TextBox()
                {
                    Size = new Size(80, 50),
                    Location = new Point(40 + (i / 4) * 90, 40 + (i % 4) * 60),
                    Font = new Font("Consolas", 12)
                };
                tx[i].Click += Txt_chat_KeyDown;
                panel1.Controls.Add(tx[i]);
            }
            button3.Click += click;
            button4.Click += click;
            button5.Click += click;
            button6.Click += click;
        }
        private void Txt_chat_KeyDown(object sender, EventArgs e)
        {
            mouse = sender as TextBox;
        }
        private void click(object sender, EventArgs e)
        {
            mouse.Text = ((Button)sender).Text;
        }
        public List<hi> col = new List<hi>();
        public List<hi> row = new List<hi>();
        public List<hi> dgv = new List<hi>();
        public void solve()
        {
            col.Clear();
            row.Clear();
            dgv.Clear();
            for (int i = 0; i < 4; i++)
            {
                col.Add(new hi());
                row.Add(new hi());
                dgv.Add(new hi());
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tx[i * 4 + j].Text.Length != 1) continue;
                    int val = int.Parse(tx[i * 4 + j].Text);
                    col[i].Add(val);
                    row[j].Add(val);
                    dgv[(i / 2) * 2 + (j / 2)].Add(val);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                solve();
                for(int i = 0; i < 4; i++)
                {
                    for(int j = 0; j < 4; j++)
                    {
                        if (tx[i * 4 + j].Text == "")
                        {
                            string res = "";
                            for(int k = 1; k <= 4; k++)
                            {
                                if (!(col[i].Contains(k) || row[j].Contains(k) || dgv[(i / 2) * 2 + (j / 2)].Contains(k)))
                                {
                                    res += $"{k},";
                                }
                            }
                            tx[i * 4 + j].Text = res.TrimEnd(',');
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("格式錯誤!", "Hint");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                solve();
                bool fg = false;
                for (int i = 0; i < 4; i++)
                {
                    if (col[i].Count != 4 || row[i].Count != 4 || dgv.Count != 4)
                    {
                        fg = true; break;
                    }
                }
                label1.Text = fg ? "錯誤" : "正確";
            }
            catch (Exception)
            {
                MessageBox.Show("格式錯誤!", "Hint");
            }
        }
    }
}
