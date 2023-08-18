// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ssi = System.Collections.Generic.SortedDictionary<string, int>;
using ssss = System.Collections.Generic.SortedDictionary<string, System.Collections.Generic.SortedSet<string>>;
namespace _108_6
{
    class Program
    {
        /*
         * 想法: 鍵入任意小圓盤名稱（把它當作父節點），找出它的子節點。
         * 因為父節點對應的子節點不是唯一的（例如 f 有 h、g），它所有的子節點都需要找到。
         * 找到的子節點再從子節點回溯到其父節點，判斷兩個數值（d、f 和 f、e）是否為 1。
         * 如果為 1，則將父節點的兩個數值設為 0，子節點數值設為 1。
         */
        public static ssss p = new ssss();//父節點對應子節點
        public static ssi q = new ssi();  //節點對應數值
        public static ssss t = new ssss();//節點對應轉移棒
        public static Dictionary<string, (string, string)> net = new Dictionary<string, (string, string)>();            //節點對應兩個父節點
        public static string record = "";
        static void Main()
        {
            q["0"] = 1;
            Console.WriteLine("鍵入「輸入小圓盤」的數目及名稱:");
            Console.ReadLine();
            Console.WriteLine("鍵入「內部小圓盤」的數目及名稱:");
            Console.ReadLine();
            Console.WriteLine("鍵入「輸出小圓盤」的數目及名稱:");
            Console.ReadLine();
            Console.WriteLine("鍵入「2-1 轉移棒」的名稱及小圓盤的名稱:");
            do readtext();
            while (check());
            Console.WriteLine("鍵入「1-1 轉移棒」的名稱及小圓盤的名稱:");
            do readtext();
            while (check());
            Console.WriteLine("轉移棒與小圓盤的關係:" + record);
            Console.WriteLine("小圓盤與轉移棒的關係:\r\n" + display(t));
            do
            {
                Queue<string> queue = new Queue<string>();
                Console.Write("鍵入將放權杖的小圓盤名字:");
                queue.Enqueue(Console.ReadLine() + "");
                q[queue.Peek()] = 1;
                Console.WriteLine("查看各個小圓盤權杖的情況:" + display(q));
                Console.WriteLine("執行轉移棒.");
                while (queue.Count > 0)
                {
                    string key = queue.Dequeue();
                    if (!p.ContainsKey(key)) continue;
                    foreach(string child in p[key])
                    {
                        if (q[net[child].Item1] == 1 && q[net[child].Item2] == 1)
                        {
                            q[net[child].Item1] = q[net[child].Item2] = 0;
                            q[child] = 1;
                            queue.Enqueue(child);
                            q["0"] = 1;
                        }
                    }
                }
                Console.WriteLine("查看各個小圓盤權杖的情況:" + display(q));

            } while (check());
            Console.ReadKey();
        }
        public static void readtext()
        {
            string[] arr = (Console.ReadLine() + "").Split(' ').ToArray();           
            if(arr.Length == 4)
            {
                record += $"{arr[0]}: {arr[1]} {arr[2]} {arr[3]} ";
                net[arr[3]] = (arr[1], arr[2]);
                additem(p, arr[1], arr[3]);
                additem(p, arr[2], arr[3]);
            }
            else
            {
                record += $"{arr[0]}: {arr[1]} {arr[2]} ";
                net[arr[2]] = (arr[1], "0");
                additem(p, arr[1], arr[2]);
            }
            for(int i = 1; i < arr.Length; i++)
            {
                additem(t, arr[i], arr[0]);
                q[arr[i]] = 0;
            }
        }
        public static void additem(ssss sorted,string key,string value)
        {
            if (!sorted.ContainsKey(key)) sorted[key] = new SortedSet<string>();
            sorted[key].Add(value);
        }
        public static string display<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> sorted)
        {
            string result = "";
            Array.ForEach(sorted.ToArray(), item => result += $"{item.Key}:{(typeof(TValue) == typeof(int) ? item.Value : string.Join(" ", (IEnumerable<string>)item.Value))} ");
            if (result[0] == '0') return result.Substring(3);
            return result;
        }
        public static bool check()
        {
            while (true)
            {
                Console.Write("Continue?(1/0):");
                string str = Console.ReadLine() + "";
                if (str == "1") return true;
                else if (str == "0") return false;
            }
        }
    }
}
