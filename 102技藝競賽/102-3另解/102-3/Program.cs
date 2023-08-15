using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _102_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入檔名:");//C:\Users\user\Desktop\102-3測資\data1.txt
            StreamReader din = File.OpenText(@Console.ReadLine());
            string str = "";
            int end = -1;
            int[,] map = new int[1000, 1000];
            while (!string.IsNullOrEmpty(str = din.ReadLine()))
            {
                int[] arr = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                map[arr[0], arr[1]] = arr[2];
                end = Math.Max(arr[1], end);
            }
            Node[] node = new Node[end + 1];
            node[0] = new Node(0, 0);
            node[1] = new Node(0, 1, node[0]);
            for (int i = 2; i <= end; i++)
            {
                node[i] = new Node(Int16.MaxValue, i);
            }
            for(int i = 1; i <= end; i++)
            {
                for (int j = 1; j <= end; j++)
                {
                    if (map[i, j] != 0 && node[j].cost > node[i].cost + map[i, j])
                    {
                        node[j] = new Node(node[i].cost + map[i, j], node[j].name, node[i]);
                    }
                }
            }
            Node root = node[end];
            int total = root.cost;
            string times = "";
            string costs = "";
            while (true)
            {
                times = root.name.ToString().PadLeft(3, ' ') + times;
                costs = (root.cost - root.father.cost).ToString().PadLeft(3, ' ') + costs;
                if (root.name == 1) break;
                root = root.father;
            }
            Console.WriteLine($"最低成本值總和:{total}\r\n路徑次序:{times}\r\n連接數值:{costs}");
            Console.ReadKey();
        }
    }
    public class Node
    {
        public Node root, father;
        public int cost;
        public int name;
        public Node(int cost,int name, Node father = null)
        {
            this.cost = cost;
            this.name = name;
            this.father = father;
        }
    }
}
