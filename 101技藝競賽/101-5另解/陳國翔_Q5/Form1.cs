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

namespace 陳國翔_Q5
{
    public partial class Form1 : Form
    {
        public static TextBox[] Initial = new TextBox[9];
        public static TextBox[] Goal = new TextBox[9];
        public static List<List<int>> moved = new List<List<int>>();
        public static bool check(int item, int col, int row)
        {
            if (item / 3 + col < 0 || item / 3 + col > 2) return false;
            if (item % 3 + row < 0 || item % 3 + row > 2) return false;
            return true;
        }
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    List<int> moved2 = new List<int>();
                    if (check(i * 3 + j, 0, 1)) moved2.Add(i * 3 + j + 1);
                    if (check(i * 3 + j, 0, -1)) moved2.Add(i * 3 + j - 1);
                    if (check(i * 3 + j, 1, 0)) moved2.Add((i + 1) * 3 + j);
                    if (check(i * 3 + j, -1, 0)) moved2.Add((i - 1) * 3 + j);
                    panel1.Controls.Add(Initial[i * 3 + j] = GetText(i, j));
                    panel2.Controls.Add(Goal[i * 3 + j] = GetText(i, j));
                    moved.Add(moved2);
                }
            }
        }
        public static TextBox GetText(int x,int y)
        {
            return new TextBox()
            {
                Font = new Font("Default", 12),
                TextAlign = HorizontalAlignment.Center,
                Size = new Size(30, 30),
                Location = new Point(40 + y * 40, 40 + x * 40)
            };
        }
        public static Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            int index = 0;
            Array.ForEach(Initial, item => item.Text = index++ != 0 ? $"{index - 1}" : " ");
            for (int i = 0; i < 20; i++)
            {
                Point p = new Point(rnd.Next(0, 9), rnd.Next(0, 9));
                string tmp = Initial[p.X].Text;
                Initial[p.X].Text = Initial[p.Y].Text;
                Initial[p.Y].Text = tmp;
            }
            index = 0;
            Array.ForEach(Goal, item => item.Text = index++ != 0 ? $"{index - 1}" : " ");
        }
        public static Stack<char[]>ans=new Stack<char[]>();
        public static void Solove()
        {
            ans.Clear();
            Array.ForEach(Initial, item => item.Text = item.Text == "" ? " " : item.Text);
            Array.ForEach(Goal, item => item.Text = item.Text == "" ? " " : item.Text);
            HashSet<string> hash = new HashSet<string>();
            Node start = new Node(Initial.Select(item => Convert.ToChar(item.Text)).ToArray(), Array.FindIndex(Initial, item => item.Text == " "));
            string end = string.Join("", Goal.Select(item => Convert.ToChar(item.Text)).ToArray());
            List<Node> node = new List<Node>();
            node.Add(start);
            int count = 0;
            while (++count < 50)
            {
                List<Node> node2 = new List<Node>();
                while (node.Count != 0)
                {
                    Node root = node.First();
                    node.RemoveAt(0);
                    List<int> all = moved[root.target];
                    for(int i = 0; i < all.Count; i++)
                    {
                        char tmp = root.ch[root.target];
                        root.ch[root.target] = root.ch[all[i]];
                        root.ch[all[i]] = tmp;
                        string text = string.Join("", root.ch);
                        tmp = root.ch[root.target];
                        root.ch[root.target] = root.ch[all[i]];
                        root.ch[all[i]] = tmp;
                        if (!hash.Contains(text))
                        {
                            node2.Add(new Node(text.ToCharArray(), all[i], root));
                            if (text == end)
                            {
                                Node final = node2[node2.Count - 1];
                                while(final.father != null)
                                {
                                    ans.Push(final.ch);
                                    final = final.father;
                                }
                                return;
                            }
                            hash.Add(text);
                        }
                    }
                }
                node.AddRange(node2);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Solove();
            if (ans.Count != 0)
            {
                label5.Text = $"{ans.Count - 2}";
                while(ans.Count != 0)
                {
                    Thread.Sleep(500);
                    Application.DoEvents();
                    char[] ch = ans.Pop();
                    for(int i = 0; i < 9; i++)
                    {
                        Initial[i].Text = $"{ch[i]}";
                    }
                }
            }
            else
            {
                label5.Text = "無解";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Solove();
            if (ans.Count != 0)
            {
                label5.Text = $"{ans.Count - 2}";
                while (ans.Count != 0)
                {
                    Thread.Sleep(1000);
                    Application.DoEvents();
                    char[] ch = ans.Pop();
                    for (int i = 0; i < 9; i++)
                    {
                        Initial[i].Text = $"{ch[i]}";
                    }
                }
            }
            else
            {
                label5.Text = "無解";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class Node
    {
        public Node father;
        public int target;
        public char[] ch;
        public Node(char[] ch, int target, Node father = null)
        {
            this.ch = ch;
            this.target = target;
            this.father = father;
        }
    }
}
