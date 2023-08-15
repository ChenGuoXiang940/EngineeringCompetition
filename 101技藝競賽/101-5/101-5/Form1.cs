using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace _101_5
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public static TextBox[] Initial = new TextBox[9];
        public static TextBox[] Goal = new TextBox[9];
        public static List<List<int>> moved = new List<List<int>>();
        public static bool check(int col,int row,int index)
        {
            if (index / 3 + col < 0 || index / 3 + col > 2) return false;
            if (index % 3 + row < 0 || index % 3 + row > 2) return false;
            return true;
        }
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                List<int> moved2 = new List<int>();
                if (check(1, 0, i)) moved2.Add(3 + i);
                if (check(-1, 0, i)) moved2.Add(-3 + i);
                if (check(0, 1, i)) moved2.Add(1 + i);
                if (check(0, -1, i)) moved2.Add(-1 + i);
                moved.Add(moved2);
                Initial[i] = GetText(i / 3, i % 3, "");
                Goal[i] = GetText(i / 3, i % 3, i.ToString());
                panel1.Controls.Add(Initial[i]);
                panel2.Controls.Add(Goal[i]);
            }
        }
        public static TextBox GetText(int y, int x, string text)
        {
            return new TextBox()
            {
                Text = $"{text}",
                Font = new Font("Consolas", 15),
                TextAlign = HorizontalAlignment.Center,
                Size = new Size(30, 30),
                Location = new Point(10 + 60 * x, 10 + 60 * y)
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "Step:";
            label6.Text = "";
            int x = 0;
            Array.ForEach(Initial, i => i.Text = (x++).ToString());
            for (int i = 0; i < 25; i++)
            {
                int target1 = rnd.Next(0, 9);
                int target2 = rnd.Next(0, 9);
                if(target1 != target2)
                {
                    string tmp = Initial[target1].Text;
                    Initial[target1].Text = Initial[target2].Text;
                    Initial[target2].Text = tmp;
                }
            }
        }
        public static Stack<Data> stack = new Stack<Data>();
        public static void Reset(Data data)
        {
            int x = 0;
            Array.ForEach(Initial, i => i.Text = $"{data.status[x++]}" == "0" ? "" : $"{data.status[x - 1]}");
        }
        public bool Work()
        {
            stack.Clear();
            HashSet<string> hash = new HashSet<string>();
            Data start = new Data(Tobytes(Initial), Array.FindIndex(Initial, x => x.Text == "0"));
            string endstatus = ToSequence(Tobytes(Goal));
            if (endstatus == ToSequence(start.status))
            {
                stack.Push(start);
                return false;
            }
            List<Data> list = new List<Data>();
            List<Data> list2 = new List<Data>();
            list.Add(start);
            int count = 0;
            while (++count < 50)
            {
                while(list.Count != 0)
                {
                    Data item = list.First();
                    list.RemoveAt(0);
                    for (int i = 0; i < moved[item.target].Count; i++)
                    {
                        byte tmp = item.status[moved[item.target][i]];
                        item.status[moved[item.target][i]] = item.status[item.target];
                        item.status[item.target] = tmp;
                        string value = ToSequence(item.status);
                        if (!hash.Contains(value))
                        {
                            list2.Add(new Data(item.status.ToArray(), moved[item.target][i], item));
                            if (endstatus == value)
                            {
                                Data data2 = item;
                                while (data2 != null)
                                {
                                    stack.Push(data2);
                                    data2 = data2.father;
                                }
                                return true;
                            }
                            hash.Add(value);
                        }
                        tmp = item.status[moved[item.target][i]];
                        item.status[moved[item.target][i]] = item.status[item.target];
                        item.status[item.target] = tmp;
                    }
                }
                list.AddRange(list2);
                list2.Clear();
            }
            return true;
        }
        public string ToSequence(Byte[]status)
        {
            return String.Join("", status);
        }
        public static byte[] Tobytes(TextBox[] text)
        {
            byte[] arr = new byte[9];
            int x = 0;
            Array.ForEach(text, i => arr[x++] = byte.Parse(i.Text));
            return arr;
        }
        public void Start(int time)
        {
            bool fg = Work();
            int times = stack.Count;
            if (times == 0 || !fg)
            {
                label4.Text = "無解";
                label6.Text = $"步驟:{0}/{0}";
            }
            else
            {
                label4.Text = $"Step:{times}";
                label6.Text = $"步驟:{times}/{times}";
                Thread.Sleep(time);
                Application.DoEvents();
                while (stack.Count != 0)
                {
                    Reset(stack.Pop());
                    label6.Text = $"步驟:{stack.Count}/{times}";
                    Thread.Sleep(time);
                    Application.DoEvents();
                }
                Initial[Array.FindIndex(Initial, x => x.Text == "")].Text = "0";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Start(500);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start(1000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class Data
    {
        public byte[] status;
        public int target;
        public Data father;
        public Data(byte[] status, int target, Data father = null)
        {
            this.status = status;
            this.target = target;
            this.father = father;
        }
    }
}
