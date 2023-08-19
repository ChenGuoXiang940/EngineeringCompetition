using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _105_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader din = File.OpenText(ofd.FileName);
                string text = " " + din.ReadToEnd().Replace("：：", "：").Replace("?", "") + " ";
                textBox1.Text = text;
                textBox2.Text = "";
                List<int> record = new List<int>();
                for(int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '：')
                    {
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if(text[j] == ' '||(text[j]=='/'&&text[j - 1]!='年'))
                            {
                                if (!record.Contains(j)) record.Add(j);
                                break;
                            }
                        }     
                    }                    
                }
                record.Add(text.Length - 1);
                for(int i = 0;i < record.Count - 1; i++)
                {
                    textBox2.AppendText(text.Substring(record[i] + 1, record[i + 1] - record[i] - 1) + "\r\n");
                }
            }
        }
    }
}
