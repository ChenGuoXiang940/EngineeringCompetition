using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _104_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> str = new List<string> { "BPFV", "CSKGJQXZ", "DT", "L", "MN", "R" };
            List<string> col = (textBox1.Text.Replace("\r\n", ",").Split(',')).ToList();
            col = col.Where(x => !String.IsNullOrEmpty(x)).ToList();
            string[] arr = new string[col.Count];
            for(int i = 0;i < col.Count; i++)
            {
                string data = col[i];
                int[] record = new int[data.Length];
                record = record.Select(x => x = -1).ToArray();
                for(int j = 0;j < str.Count; j++)
                {
                    if (str[j].Contains(data[0].ToString()))
                    {
                        record[0] = j;
                        break;
                    }
                }
                string line = data[0].ToString();
                int count = 1;
                while (line.Length != 4 && count < data.Length)
                {
                    for(int j = 0; j < str.Count; j++)
                    {
                        if (record[count - 1] != j && str[j].Contains(data[count].ToString()))
                        {
                            record[count] = j;
                            line += (j + 1).ToString();
                            break;
                        }
                    }
                    count++;
                }
                for(int k = line.Length; k < 4; k++)
                {
                    line += "0";
                }
                arr[i] = line;
            }
            textBox2.Text = string.Join("\r\n", arr);
        }
    }
}
