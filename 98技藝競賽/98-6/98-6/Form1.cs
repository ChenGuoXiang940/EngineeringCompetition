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

namespace _98_6
{
    public partial class Form1 : Form
    {
        public static List<Data> col = new List<Data>();
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("192.168.0.1");
            comboBox1.Items.Add("168.95.1.1");
            comboBox1.Items.Add("168.95.128.1");
            for (int i = 1; i <= 32; i++) comboBox2.Items.Add(i.ToString());
            StreamReader din = File.OpenText(@"C:\Users\user\Desktop\in1.txt");
            while (true)
            {
                string line = din.ReadLine();
                if (line == null) break;
                col.Add(new Data(line.Split(',').ToArray()));
            }
        }
        public static string maskstr = "";
        public static string net = "";
        private void button1_Click(object sender, EventArgs e)
        {
            string ip = getip(comboBox1.Text);
            int maskval = int.Parse(comboBox2.Text);
            maskstr = new string('1', maskval);
            maskstr = maskstr.PadRight(32, '0');
            net = and(ip, maskstr);
            textBox1.Text = $"Net : {display(net)}\r\nMask : {display(maskstr)}\r\n-----------------------------------------------" +
                $"\r\n{display2(col)}";
        }
        public static string and(string s1,string s2)
        {
            string str = "";
            for(int i = 0; i < 32; i++)
            {
                if (((s1[i] - '0') & (s2[i] - '0')) == 1) str += "1";
                else str += "0";
            }
            return str;
        }
        public static string display2(List<Data>col)
        {
            string str = "";
            foreach(var item in col)
            {
                str += $"IP : {display(item.ip)},Message : {item.mg}\r\n";
            }
            return str.TrimEnd('\n').TrimEnd('\r');
        }
        public static string display(string s)
        {
            string str = "";
            for (int i = 0; i < 4; i++) 
            {
                str += $"{Convert.ToInt32(s.Substring(i * 8, 8), 2)}.";
            }
            return str.TrimEnd('.');
        }
        public static string getip(string s)
        {
            string str = "";
            int[] arr = s.Split('.').Select<string, int>(x => Int16.Parse(x)).ToArray();
            for(int i = 0; i < 4; i++)
            {
                str += Convert.ToString(arr[i], 2).PadLeft(8, '0');
            }
            return str;
        }
        public static bool check(int mask,int ip1,int ip2)
        {
            return (ip1 & mask) == (ip2 & mask);
        }
    }
    public class Data
    {
        public string ip;
        public string mg;
        public static Dictionary<string, string> dict = new Dictionary<string, string>() { { "A", "0" }, { "B", "10" }, { "C", "110" } };
        public Data(string[]arr)
        {
            string ip = Form1.getip(arr[1]);
            if (dict[arr[0]] != ip.Substring(0, dict[arr[0]].ToString().Length))
            {
                string tmp = dict[arr[0]];
                ip = tmp + ip.Substring(dict[arr[0]].ToString().Length);
            }
            this.ip = ip;
            this.mg = arr[2];
        }
    }
}
