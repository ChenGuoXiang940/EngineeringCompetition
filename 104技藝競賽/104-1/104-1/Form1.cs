using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _104_1
{
    public partial class Form1 : Form
    {
        public static Button[] bn = new Button[4];
        public static TextBox[]tx=new TextBox[16];
        public static List<Data> col = new List<Data>();
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 4; i++)
            {
                bn[i] = new Button()
                {
                    Text = (i + 1).ToString(),
                    Font = new Font("Default", 12),
                    Size = new Size(60, 40),
                    Location = new Point(10 + 70 * i, 10)
                };
                bn[i].Click += AnyButton_Click;
                panel2.Controls.Add(bn[i]);
                for (int j = 0; j < 4; j++)
                {
                    tx[i * 4 + j] = new TextBox()
                    {
                        Text = "",
                        Font = new Font("Default", 12),
                        ReadOnly = true,
                        Size = new Size(70, 40),
                        Location = new Point(20 + 80 * j, 20 + 50 * i)
                    };
                    tx[i * 4 + j].Click += Txt_chat_KeyDown;
                    panel1.Controls.Add(tx[i * 4 + j]);
                }
                Bitmap bitmap = new Bitmap(350, 200);
                Graphics g = Graphics.FromImage(bitmap);
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black, 3);
                g.DrawLine(pen, 175, 0, 175, 200);
                g.DrawLine(pen, 0, 100, 350, 100);
                panel1.BackgroundImage = bitmap;
            }
            int sq = 0;
            for (int i = 0; i < 4; i++)
            {
                int sq2 = 0;
                for (int j = 0; j < 4; j++)
                {
                    col.Add(new Data(tx[sq], i * 4 + j, i));
                    if (j == 1) sq2 += 3;
                    else sq2++;
                }
                if (i == 1) sq += 6;
                else sq += 2;
            }
        }
        public static TextBox control;
        private void AnyButton_Click(object sender, EventArgs e)
        {
            try
            {
                control.Text = ((Button)sender).Text;
            }
            catch (Exception) {}
        }
        private void Txt_chat_KeyDown(object sender, EventArgs e)
        {
            control = sender as TextBox;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[,] map = new string[4, 4];
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    map[i, j] = "1,2,3,4";
                }
            }
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    int target = i * 4 + j;
                    if (tx[target].Text != "")
                    {
                        int x = target == 0 ? 0 : target % 4;
                        int y = (int)target / 4;
                        int z = col[col.FindIndex(item => item.path == target)].sign;
                        for(int a = 0; a < 4; a++)
                        {
                            map[a, x] = map[a, x].Replace($",{tx[target].Text}", "").Replace($"{tx[target].Text}", "");
                            map[y, a] = map[y, a].Replace($",{tx[target].Text}", "").Replace($"{tx[target].Text}", "");
                        }
                        for(int a = 0; a < 16; a++)
                        {
                            if (col[i].sign == z)
                            {
                                map[col[i].path / 4, col[i].path % 4] = map[col[i].path / 4, col[i].path % 4].
                                    Replace($",{tx[target].Text}", "").Replace($"{tx[target].Text}", "");
                            }
                        }
                    }
                }
            }
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (tx[i * 4 + j].Text == "") tx[i * 4 + j].Text = map[i, j].TrimStart(',');
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int sq = 0;
                for (int i = 0; i < 4; i++)
                {
                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;
                    int sq2 = sq;
                    for (int j = 0; j < 4; j++)
                    {
                        count1 += int.Parse(tx[i * 4 + j].Text);
                        count2 += int.Parse(tx[j * 4 + i].Text);
                        count3 += int.Parse(tx[sq2].Text);
                        if (j == 1) sq2 += 3;
                        else sq2++;
                    }
                    if (i == 1) sq += 6;
                    else sq += 2;
                    if (count1 != 10 || count2 != 10 || count3 != 10)
                    {
                        label1.Text = "錯誤";
                        return;
                    }
                }
                label1.Text = "正確";
            }
            catch (Exception)
            {
                label1.Text = "錯誤";
            }
        }
    }
    public class Data
    {
        public TextBox name;
        public int path;
        public int sign;
        public Data(TextBox name,int path,int sign)
        {
            this.name = name;
            this.path = path;
            this.sign = sign;
        }
    }
}
