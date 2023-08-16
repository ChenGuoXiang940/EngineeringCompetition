using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            count = (!string.IsNullOrEmpty(textBox1.Text) ? int.Parse(textBox1.Text) : 0) * 60 +
                (!string.IsNullOrEmpty(textBox2.Text) ? int.Parse(textBox2.Text) : 0);
            textBox1.ForeColor = textBox2.ForeColor = Color.Black;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = $"{count / 60}";
            textBox2.Text = $"{count % 60}";
            count--;
            if (count < 0)
            {
                timer1.Stop();
                textBox1.ForeColor = textBox2.ForeColor = Color.Red;
                MessageBox.Show("時間到", "錯誤資訊", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
