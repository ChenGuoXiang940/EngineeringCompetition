using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _98_1
{
    public partial class Form1 : Form
    {
        public static Button[] button;
        public static TextBox[] textBox;
        public Form1()
        {
            InitializeComponent();
            button = new Button[4] { Button1, Button2, Button3, Button4 };
            textBox = new TextBox[4] { TextBox1, TextBox2, TextBox3, TextBox4 };
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            int count = 0;
            int path1 = Array.FindIndex(button, item => item.Text is "Ld");
            int path2 = Array.FindIndex(button, item => item.Text is "Ih");
            Array.ForEach(button, item => count += (item.Text == "Ed") ? 1 : 0);
            if (count is 2 && !path1.Equals(-1) && !path2.Equals(-1))
            {
                int v1 = Convert.ToInt32(textBox[path1].Text,2);
                int v2 = Convert.ToInt32(textBox[path2].Text, 2);
                v1 = v1 ^ v2;//XOR(互斥或)三次=>交換整數
                v2 = v1 ^ v2;
                v1 = v1 ^ v2;
                textBox[path1].Text = $"{Convert.ToString(v1, 2).PadLeft(8, '0')}";
                textBox[path2].Text = $"{Convert.ToString(v2, 2).PadLeft(8, '0')}";
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Clicked(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Ld":
                    ((Button)sender).Text = "Ed";
                    break;
                case "Ed":
                    ((Button)sender).Text = "Ih";
                    break;
                case "Ih":
                    ((Button)sender).Text = "Ld";
                    break;
            }
        }
        public static Random rnd = new Random();
        private void Button_Clicked(object sender, EventArgs e)
        {
            foreach(TextBox obj in Controls.OfType<TextBox>())
            {
                int[] arr = new int[8].Select(x => rnd.Next(0, 2)).ToArray();
                ((TextBox)obj).Text = String.Join("", arr);
            }
        }
    }
}
