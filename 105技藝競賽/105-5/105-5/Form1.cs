using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace _105_5
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public static TextBox[] tb1 = new TextBox[4];
        public static TextBox[] tb2 = new TextBox[4];
        public Form1()
        {
            InitializeComponent();
            string[] str = { "i", "n", "h", "u" };
            string[] val = { "20", "550", "950", "80" };
            for(int i = 0; i < 4; i++)
            {
                panel1.Controls.Add(tb1[i] = GetText(i * 60, 0, str[i]));
                panel1.Controls.Add(tb2[i] = GetText(i * 60, 35, val[i]));
            }
        }
        public static TextBox GetText(int x,int y,string text)
        {
            return new TextBox()
            {
                Text = text,
                Font = new Font("Default", 12),
                TextAlign = HorizontalAlignment.Center,
                Size = new Size(60, 30),
                Location = new Point(x, y)
            };
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Array.ForEach(tb1, item => item.Text = $"{Convert.ToChar('a' + rnd.Next(0, 26))}");
            Array.ForEach(tb2, item => item.Text = $"{rnd.Next(1, 1000)}");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int past = 0;
            List<Node> col = new List<Node>();
            for(int i = 0; i < 4; i++)
            {
                past += int.Parse(tb2[i].Text);
                col.Add(new Node(int.Parse(tb2[i].Text)));
            }
            TextBox9.Text = $"{past * 2}";
            while (col.Count > 1)
            {
                col = col.OrderBy(x => x.val).ToList();
                col.Add(new Node(col[0].val + col[1].val, col[0], col[1]));
                col.RemoveRange(0, 2);
            }
            Node root = col[0];
            int total = 0;
            int count = 1;
            while (root.right != null)
            {
                total += root.right.val * count++;
                root = root.left;
            }
            total += root.val * (count - 1);
            TextBox10.Text = $"{total}";
            TextBox11.Text = $"{Math.Round((double.Parse(TextBox9.Text) / (double)total), 4)}";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class Node
    {
        public Node left, right;
        public int val;
        public Node(int val, Node left = null, Node right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
