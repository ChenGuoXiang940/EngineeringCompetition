using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q7
{
    public partial class Form1 : Form
    {
        public static List<NumericUpDown> numerics = new List<NumericUpDown>();
        public static List<TextBox> textures = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();
            Array.ForEach(Controls.OfType<GroupBox>().ToArray(), item1 => Array.ForEach(item1.Controls.OfType<TextBox>().ToArray(), item => textures.Add(item)));
            Array.ForEach(Controls.OfType<GroupBox>().ToArray(), item1 => Array.ForEach(item1.Controls.OfType<NumericUpDown>().ToArray(), item => numerics.Add(item)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Array.ForEach(Controls.OfType<GroupBox>().ToArray(), item1 => Array.ForEach(item1.Controls.OfType<NumericUpDown>().ToArray(), item => ((NumericUpDown)item).Value = 0));
            label1.Text = "等待客人點餐中...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int total = 0;
            for(int i = 0; i < numerics.Count; i++)
            {
                total += int.Parse(numerics[i].Value.ToString()) * int.Parse(textures[i].Text);
            }
            label1.Text = $"{(int)(total * 1.05)}";
        }
    }
}
