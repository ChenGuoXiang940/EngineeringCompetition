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

namespace _103_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Visible = false;
            textBox2.Visible = false;
        }
        public static Random rnd = new Random();
        public static List<List<Data>> col = new List<List<Data>>();
        public static List<TextBox> textBoxes = new List<TextBox>();
        public static int[] arr;
        private void button1_Click(object sender, EventArgs e)
        {
            col.Clear();
            textBox1.Text = "";
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                StreamReader din = File.OpenText(open.FileName);
                arr = din.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                for(int i = 0; i < arr[0]; i++)
                {
                    int[] arr2 = din.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                    if (i <= arr[1])
                    {
                        col.Add(new List<Data>() { new Data(i, arr2[0], arr2[1]) });
                    }
                    else
                    {
                        col[rnd.Next(0, arr[1] + 1)].Add(new Data(i, arr2[0], arr2[1]));
                    }
                    textBox1.Text += $"{i}\t{arr2[0]}\t{arr2[1]}\r\n";
                }
            }
            for (int i = 0; i <= arr[1] / 3; i++)
            {
                for (int j = 0; j <= arr[1] % 3; j++)
                {
                    Label label = new Label()
                    {
                        Text = $"第{i * 3 + j}堆",
                        Visible = false,
                        Font = new Font("Default", 12),
                        Location = new Point(70 + 160 * j, 110 * i)
                    };
                    TextBox text = new TextBox()
                    {
                        Text = "",
                        Visible = false,
                        Multiline = true,
                        Size = new Size(150, 200),
                        Font = new Font("Default", 9),
                        Location = new Point(30 + 160 * j, 30 + 110 * i)
                    };
                    panel1.Controls.Add(label);
                    panel1.Controls.Add(text);
                    textBoxes.Add(text);
                }
            }
        }
        public static Type getav(List<Data> col)
        {
            double totalw = 0;
            double totalh = 0;
            foreach(Data data in col)
            {
                totalw += data.type.weight;
                totalh += data.type.height;
            }
            return new Type(totalw / col.Count, totalh / col.Count);
        }
        public static double getdist(Type d1,Type d2)
        {
            return Math.Sqrt(Math.Pow(d1.weight - d2.weight, 2) + Math.Pow(d1.height - d2.height, 2));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            textBox2.Visible = true;
            foreach (Control obj in panel1.Controls.OfType<TextBox>())
            {
                obj.Visible = true;
            }
            foreach(Control obj in panel1.Controls.OfType<Label>())
            {
                obj.Visible = true;
            }
            int count1 = 0;
            int count2 = 0;
            for(int i = 0; i < 100; i++)
            {
                double[] compare = new double[arr[1] + 1];
                for (int j = 0; j <= arr[1]; j++)
                {
                    compare[j] = getdist(getav(col[j]), col[count1][count2].type);
                }
                int target = Array.IndexOf(compare, compare.Min());
                if (target != count1)
                {
                    col[target].Add(col[count1][count2]);
                    col[count1].RemoveAt(count2);
                }
                if (++count2 >= col[count1].Count)
                {
                    if (++count1 >= col.Count)
                    {
                        count1 = 0;
                    }
                    count2 = 0;
                }
            }
            textBox2.Text = "";
            var col2 = new List<Data>();
            for (int i = 0; i <= arr[1]; i++)
            {
                textBoxes[i].Text = "";
                col[i] = col[i].OrderBy(x => x.name).ToList();
                for(int j = 0; j < col[i].Count; j++)
                {
                    textBoxes[i].Text += $"{col[i][j].name}\t{col[i][j].type.weight}\t{col[i][j].type.height}\r\n";
                    col[i][j].group = i;
                }
                col2.AddRange(col[i]);
            }
            col2 = col2.OrderBy(x => x.name).ToList();
            for(int i=0;i< col2.Count; i++)
            {
                textBox2.Text += $"第{col2[i].name}筆屬於{col2[i].group}堆\r\n";
            }
        }
    }
    public class Type
    {
        public double weight;
        public double height;
        public Type(double weight,double height)
        {
            this.weight = weight;
            this.height = height;
        }
    }
    public class Data
    {
        public int name;
        public Type type;
        public int group;
        public Data(int name ,double weight,double height)
        {
            this.name = name;
            this.type = new Type(weight,height);
        }
    }
}
