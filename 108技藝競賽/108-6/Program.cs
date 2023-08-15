// See https://aka.ms/new-console-template for more information
namespace _108_6
{
    class Program
    {
        public struct type1
        {
            public string name;
            public string in1;
            public string in2;
            public string out1;
        }
        public struct type2
        {
            public string name;
            public string in1;
            public string out1;
        }
        static void Main()
        {
            List<string> list = new List<string>();
            Console.WriteLine("鍵入「輸入小圓盤」的數目及其名稱:");
            string[] str1 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            list.AddRange(str1);
            list.RemoveAt(list.Count - str1.Length);
            Console.WriteLine("鍵入「內部小圓盤」的數目及其名稱:");
            string[] str2 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            list.AddRange(str2);
            list.RemoveAt(list.Count - str2.Length);
            Console.WriteLine("鍵入「輸出小圓盤」的數目及其名稱:");
            string[] str3 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            list.AddRange(str3);
            list.RemoveAt(list.Count - str3.Length);
            string[] list2 = new string[list.Count];
            int[] list3 = new int[list.Count];
            bool fg = true;
            bool fg2 = true;
            bool fg3 = true;
            List<type1> col = new List<type1>();
            List<type2> col2 = new List<type2>();
            Console.WriteLine("鍵入「2-1 轉移棒」的名稱及小圓盤的名稱:");
            while (fg)
            {               
                string[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                col.Add(new type1() { name = arr[0], in1 = arr[1], in2 = arr[2], out1 = arr[3] });
                list2[list.IndexOf(arr[1])] += arr[0] + " ";
                list2[list.IndexOf(arr[2])] += arr[0] + " ";
                list2[list.IndexOf(arr[3])] += arr[0] + " ";
                Console.Write("Continue?(1/0):");
                string str = Console.ReadLine();
                if (str == "0") fg = false;
            }
            Console.WriteLine("鍵入「1-1 轉移棒」的名稱及小圓盤的名稱:");
            while (fg2)
            {               
                string[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                col2.Add(new type2() { name = arr[0], in1 = arr[1], out1 = arr[2] });
                list2[list.IndexOf(arr[1])] += arr[0] + " ";
                list2[list.IndexOf(arr[2])] += arr[0] + " ";
                Console.Write("Continue?(1/0):");
                string str = Console.ReadLine();
                if (str == "0") fg2 = false;
            }
            string st = "";
            for(int i = 0; i < col.Count; i++)
            {
                st += $"{col[i].name}: {col[i].in1} {col[i].in2} {col[i].out1} ";
            }
            for(int i = 0; i < col2.Count; i++)
            {
                st += $"{col2[i].name}: {col2[i].in1} {col2[i].out1} ";
            }
            Console.WriteLine("轉移棒與小圓盤的關係" + st.TrimEnd(' '));
            string st2 = "";
            for(int i = 0; i < list.Count; i++)
            {
                st2 += $"{list[i]}: {list2[i]}";
            }
            Console.WriteLine("小圓盤與轉移盤的關係:" + st2);
            while (fg3)
            {
                Console.Write("鍵入將放權仗的小圓盤名稱:");
                string name = Console.ReadLine();
                list3[list.IndexOf(name)]++;                
                string st3 = "";
                for(int i = 0; i < list.Count; i++)
                {
                    st3 += $"{list[i]}: {list3[i]} ";
                }
                Console.WriteLine("查看各個小圓盤權仗名稱:" + st3);               
                while (true)
                {
                    bool fg4 = false;
                    for (int i = 0; i < col.Count; i++)
                    {
                        if (col[i].in1 == name || col[i].in2 == name)
                        {
                            if (list3[list.IndexOf(col[i].in1)] == 1 && list3[list.IndexOf(col[i].in2)] == 1)
                            {
                                list3[list.IndexOf(col[i].out1)] = 1;
                                list3[list.IndexOf(col[i].in1)] = 0;
                                list3[list.IndexOf(col[i].in2)] = 0;
                                name = col[i].out1;
                                fg4 = true;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < col2.Count; i++)
                    {
                        if (col2[i].in1 == name)
                        {
                            list3[list.IndexOf(col2[i].out1)] = 1;
                            list3[list.IndexOf(col2[i].in1)] = 0;
                            name = col2[i].out1;
                            fg4 = true;
                            break;
                        }
                    }
                    if (!fg4) break;
                }              
                string st4 = "";
                for (int i = 0; i < list.Count; i++)
                {
                    st4 += $"{list[i]}: {list3[i]} ";
                }
                Console.WriteLine("執行轉移棒\r\n查看各個小圓盤權仗的名稱:" + st4);
                Console.Write("Continue?(1/0):");
                string str = Console.ReadLine();
                if (str == "0") fg3 = false;
            }
            Console.ReadKey();
        }
    }
}
