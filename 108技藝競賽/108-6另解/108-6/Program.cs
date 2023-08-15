using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _108_6
{
    public class Type
    {
        public static List<Type> list = new List<Type>();
        public string name;
        public int value;
        public List<string> values;
        public static void add(string id, string in1)
        {
            int index = list.FindIndex(s => s.name == in1);
            if (index != -1)
            {
                list[index].values.Add(id);
            }
            else
            {
                list.Add(new Type(id, in1));
            }
        }
        public Type(string id,string in1)
        {
            this.name = in1;
            this.value = 0;
            this.values = new List<string> { id };
        }
        public static string display()
        {
            string str2 = "";
            for(int i = 0; i < list.Count; i++)
            {
                list[i].values = list[i].values.OrderBy(x => x).ToList();
            }
            list = list.OrderBy(x => x.name).ToList();
            foreach (var item in list)
            {
                str2 += $"{item.name}: {string.Join(" ", item.values)} ";
            }
            return str2.TrimEnd(' ');
        }
        public static void display2()
        {
            Console.Write("查看各個小圓盤權杖的情況:");
            foreach(Type item in list)
            {
                Console.Write($"{item.name}:{item.value} ");
            }
            Console.Write("\r\n");
        }
    }
    public class Data
    {
        public static string str = "";      
        public string in1;
        public string in2;
        public string out1;
        public Data(string id, string in1, string in2, string out1)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.out1 = out1;
            str += in2 != null ? $"{id}: {in1} {in2} {out1} " : $"{id}: {in1} {out1} ";
            Type.add(id, in1);
            if(in2 != null) Type.add(id, in2);
            Type.add(id, out1);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("鍵入「輸入小圓盤」的數目及名稱:");
            Console.ReadLine();
            Console.WriteLine("鍵入「內部小圓盤」的數目及名稱:");
            Console.ReadLine();
            Console.WriteLine("鍵入「輸出小圓盤」的數目及名稱:");
            Console.ReadLine();
            var list = new List<Data>();
            Console.WriteLine("鍵入「2-1 轉移棒」的名稱及小圓盤的名稱:");
            do
            {
                string[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                list.Add(new Data(arr[0], arr[1], arr[2], arr[3]));
            } while (check());
            Console.WriteLine("鍵入「1-1 轉移棒」的名稱及小圓盤的名稱:");
            do
            {
                string[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                list.Add(new Data(arr[0], arr[1], null, arr[2]));
            }while (check());
            Console.WriteLine("轉移棒與小圓盤的關係:" + Data.str);
            Console.WriteLine("小圓盤與轉移棒的關係:" + Type.display());
            do
            {
                Console.Write("鍵入將放權杖給小圓盤名字:");
                string st = Console.ReadLine();
                Type.list[Type.list.FindIndex(x => x.name == st)].value = 1;
                Type.display2();
                Console.WriteLine("執行轉移棒.");
                bool fg = true;
                while (fg)
                {
                    fg = false;
                    foreach (Data data in list)
                    {
                        int t1 = Type.list.FindIndex(x => x.name == data.in1);
                        int t2 = data.in2 == null ? -2 : Type.list.FindIndex(x => x.name == data.in2);
                        if ((t1 >= 0 && Type.list[t1].value == 1) && (t2 == -2 || (t2 >= 0 && Type.list[t2].value == 1)))
                        {
                            Type.list[t1].value = 0;
                            if (t2 != -2) Type.list[t2].value = 0;
                            Type.list[Type.list.FindIndex(x => x.name == data.out1)].value = 1;
                            fg = true;
                            break;
                        }
                    }
                }
                Type.display2();
            } while (check());
            Console.ReadKey();
        }
        public static bool check()
        {
            while (true)
            {
                Console.Write("Continue?(1/0):");
                string str = Console.ReadLine();
                if (str == "1") return true;
                else if (str == "0") return false;
            }
        }
    }
}
