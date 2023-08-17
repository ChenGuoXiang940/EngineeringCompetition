// See https://aka.ms/new-console-template for more information
using System.IO;
namespace 陳國翔_Q5
{
    class Program
    {
        static void Main()
        {
            Func<List<double>, string> tostr = (x) => String.Join(" ", x.Select(item => item.ToString("0.00")).ToArray());
            Console.Write("Enter filename:");
            StreamReader din = new StreamReader(@Console.ReadLine() + "");
            List<List<double>> map = new List<List<double>>();
            string line = "";
            Console.WriteLine("所輸入的對稱矩陣:");
            while (!string.IsNullOrEmpty(line = din.ReadLine() + ""))
            {
                map.Add(line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(item => double.Parse(item)).ToList());
                Console.WriteLine(tostr(map.Last()));
            }
            Console.WriteLine("\r\n經過幾次遞移律(Transitive Closure)運算後的對稱矩陣:");
            int len = map.Count;
            while (true)
            {
                List<List<double>> map2 = new List<List<double>>();
                for (int i = 0; i < len; i++)
                {
                    List<double> col2 = new List<double>();
                    for (int j = 0; j < len; j++)
                    {
                        List<double> col = new List<double>();
                        for (int k = 0; k < len; k++)
                        {
                            col.Add(Math.Min(map[k][j], map[i][k]));
                        }
                        col2.Add(col.Max());
                    }
                    map2.Add(col2);
                }
                bool fg = false;
                for(int i = 0; i < len; i++)
                {
                    for(int j = 0; j < len; j++)
                    {
                        if (map2[i][j] != map[i][j]) fg = true;
                        map[i][j] = map2[i][j];
                    }
                }
                if (!fg) break;
            }
            map.ForEach(item => Console.WriteLine(tostr(item)));
            List<double> ans = new List<double>();
            for (int i = 0; i < len - 1; i++)
            {
                double max = 0;
                for (int j = i + 1; j < len; j++)
                {
                    max = Math.Max(max, map[i][j]);
                }
                ans.Add(max);
            }
            Console.WriteLine($"\r\n對稱矩陣的右上半每列最大值:\r\n{tostr(ans)}\r\n");
            ans.Sort();
            Console.WriteLine($"對稱矩陣的右上半每列最大值(各值只出現一次):\r\n{tostr(ans.Distinct().ToList())}");
            Console.ReadKey();
        }
    }
}
