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
            List<char> ch = textBox1.Text.ToCharArray().ToList();
            bool fg = false;
            Array.ForEach(ch.ToArray(), item => fg = (item == '0' || item == '1') ? fg : true);
            if (fg)
            {
                MessageBox.Show("欲傳達的訊息應是0或1");
                return;
            }
            if (ch.Count > 11)
            {
                MessageBox.Show("欲傳達的訊息不超過11位");
                return;
            }
            int[] check = { 1, 2, 4, 8 };
            int length = 0;
            for(int i = 0; i < check.Length; i++)
            {
                if (ch.Count >= check[i]) length = i;
            }
            int v = -1;
            for(int i = ch.Count - 1, n = 1; i >= 0; i--, n++)
            {
                if (!check.Contains(n))
                {
                    if (v == -1 && ch[i] == '1')
                    {
                        v = n;
                    }
                    else if (ch[i] == '1')
                    {
                        v ^= n;
                    }
                }
                else
                {
                    i++;
                }
            }
            string ans = Convert.ToString(v, 2).PadLeft(length + 1, '0');
            for(int i = 0; i <= length; i++)
            {
                ch.Insert(ch.Count - check[i] +1, ans[ans.Length - 1 - i]);
            }
            textBox2.Text = String.Join("", ch);
        }
    }
}
