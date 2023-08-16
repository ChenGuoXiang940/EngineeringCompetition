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
            for(int i = 0; i < 6; i++)
            {
                textBoxes.Add(new TextBox() { Text = "", Font = new Font("Consolas", 12), Size = new Size(40, 30), Location = new Point(i * 40, 0) });
            }
            panel1.Controls.AddRange(textBoxes.ToArray());
        }
        public static List<TextBox> textBoxes = new List<TextBox>();
        public static Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            int index = textBoxes.FindIndex(item => item.Text == "");
            int value = rnd.Next(1, 1000);
            if (index == -1)
            {
                int n = textBoxes.Count;
                while (n-- >= 0)
                {
                    textBoxes.Add(new TextBox() { Text = "", Font = new Font("Consolas", 12), Size = new Size(40, 30), Location = new Point(textBoxes.Count * 40, 0) });
                    panel1.Controls.Add(textBoxes.Last());
                }
                Size = new Size(textBoxes.Count * 40, 234);
                panel1.Size = new Size(textBoxes.Count * 40, 30);
                textBoxes[textBoxes.Count / 2].Text = $"{value}";
            }
            else
            {
                textBoxes[index].Text = $"{value}";
            }
            textBox1.Text = $"Add {value}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = textBoxes.FindIndex(item => item.Text != "");
            if (index != -1)
            {
                textBox1.Text = $"Remove {textBoxes[index].Text}";
                textBoxes[index].Text = "";
            }
            else
            {
                textBox1.Text = "Queue is empty";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
