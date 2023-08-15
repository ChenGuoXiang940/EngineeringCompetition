using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _106_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //零1111110 0x7e
        //壹0110000 0x30;0000110 0x6
        //貳1101101 0x6d
        //參1111001 0x79
        //肆0110011 0x33
        //伍1011011 0x5b
        //陸1011111 0x5f;0011111 0x1f
        //柒1110000 0x70
        //捌1111111 0x7f
        //玖1111011 0x7b;1110011 0x73
        public static Random rnd = new Random();
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Array.ForEach(Controls.OfType<PictureBox>().ToArray(), item => item.BackColor = rnd.Next(0, 2) == 0 ? Color.Black : Color.White);
        }
        public static Dictionary<int, string> dict = new Dictionary<int, string>() {
            { 0x7e,"0"},{0x30,"1" },{ 0x6,"1"},{0x6d,"2" },{0x79,"3"},{0x33,"4"},{0x5b,"5"},
            {0x5f,"6" },{0x1f,"6" },{0x70,"7" },{0x7f,"8" } ,{ 0x7b,"9"},{0x73,"9" } };
        private void button2_Click(object sender, EventArgs e)
        {
            int m = 64;
            int total = 0;
            foreach(Control obj in Controls.OfType<PictureBox>().Reverse())
            {
                if (((PictureBox)obj).BackColor == Color.Black) total += m;
                m >>= 1;
            }
            if (dict.ContainsKey(total)) textBox1.Text = dict[total];
            else textBox1.Text = "非數值";
        }

        private void Click(object sender, EventArgs e)
        {
            if(sender is PictureBox)
            {
                ((PictureBox)sender).BackColor = ((PictureBox)sender).BackColor == Color.Black ? Color.White : Color.Black;
            }
        }
    }
}
