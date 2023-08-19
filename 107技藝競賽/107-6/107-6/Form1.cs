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

namespace _107_6
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public static Hashtable hash = new Hashtable() { { "10", "A" }, { "01", "B" }, { "11", "C" }, { "001", "D" }, { "000", "E" } };
        public Form1()
        {
            InitializeComponent();
            int i = 0;
            foreach (DictionaryEntry de in hash)
            {
                panel1.Controls.Add(GetLabel(de.Key.ToString(), i * 50, 0));
                panel1.Controls.Add(GetLabel(de.Value.ToString(), i * 50, 50));
                i++;
            }
        }
        public static Label GetLabel(string text,int x,int y)
        {
            return new Label()
            {
                Text = text,
                Font = new Font("Default", 20),
                TextAlign = ContentAlignment.TopCenter,
                Size = new Size(50, 50),
                Location = new Point(x, y),
                BorderStyle = BorderStyle.FixedSingle
            };
        }
        public static string GetRandom()
        {
            int[] arr = new int[rnd.Next(26, 51)];
            return string.Join("", arr.Select(i => rnd.Next(0, 2)));
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = GetRandom();
            TextBox3.Text = "";
            TextBox5.Text = "";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Text = GetRandom();
            TextBox4.Text = "";
            TextBox6.Text = "";
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                Data data1 = new Data(TextBox1.Text, TextBox3, TextBox5);
                Data data2 = new Data(TextBox2.Text, TextBox4, TextBox6);
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class Data
    {
        public Data(string text,TextBox text1,TextBox text2)
        {
            string ans = "";
            while (text.Length > 1)
            {
                if (text.Length >= 3 && Form1.hash.ContainsKey(text.Substring(0, 3)))
                {
                    ans += Form1.hash[text.Substring(0, 3)];
                    text = text.Substring(3);
                }
                else
                {
                    ans += Form1.hash[text.Substring(0, 2)];
                    text = text.Substring(2);
                }
            }
            if(text.Length == 0)
            {
                text2.Text = ans;
            }
            else
            {
                text1.Text = "不合理";
            }
        }
    }
}
