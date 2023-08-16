// See https://aka.ms/new-console-template for more information
namespace 陳國翔_Q4
{
    class Program
    {
        public static List<List<int>> map = new List<List<int>>();
        public static int t1, t2;
        public static void dfs(string str,int a,int b)
        {
            if (a == t1 && b == t2)
            {
                Console.WriteLine($"\t[{str.TrimEnd(' ').TrimEnd(',')}]");
                return;
            }
            if (a < t1)
            {
                dfs(str + $"{map[a + 1][b]}, ", a + 1, b);
            }
            if (b < t2)
            {
                dfs(str + $"{map[a][b + 1]}, ", a, b + 1);
            }
        }
        static void Main()//[[7,8,9],[1,2,3],[4,5,6]]
        {
            Console.Write("請輸入一個二維陣列:");
            string[] arr = Console.ReadLine().Split(new string[] { "],[", "[[", "]]" }, StringSplitOptions.RemoveEmptyEntries);
            Array.ForEach(arr, item => map.Add(item.Split(',').Select(x => int.Parse(x)).ToList()));
            t1 = map.Count - 1;
            t2 = map[0].Count - 1;
            Console.WriteLine("數字地圖:");
            map.ForEach(item => Console.WriteLine($"\t[{string.Join(", ", item)}]"));
            if (map.Count + map[0].Count < 8)
            {
                Console.WriteLine("所有路徑:");
                dfs($"{map[0][0]}, ", 0, 0);
            }
            string[,] record = new string[map.Count, map[0].Count];
            int[,] count = new int[map.Count, map[0].Count];
            record[0, 0] = $"{map[0][0]}, ";
            count[0, 0] = map[0][0];
            for(int i = 0; i < map.Count; i++)
            {
                for(int j = 0; j < map[0].Count; j++)
                {
                    if (i != 0 && (count[i, j] == 0 || count[i - 1, j] + map[i][j] < count[i, j]))
                    {
                        count[i, j] = count[i - 1, j] + map[i][j];
                        record[i, j] = record[i - 1, j] + $"{map[i][j]}, ";
                    }
                    if (j != 0 && (count[i, j] == 0 || count[i, j - 1] + map[i][j] < count[i, j]))
                    {
                        count[i, j] = count[i, j - 1] + map[i][j];
                        record[i, j] = record[i, j - 1] + $"{map[i][j]}, ";
                    }
                }
            }
            Console.WriteLine($"最小路徑:[{record[map.Count - 1, map[0].Count - 1].TrimEnd(' ').TrimEnd(',')}]");
            Console.WriteLine($"最小路徑和:{count[map.Count - 1, map[0].Count - 1]}");
            Console.ReadKey();
        }
    }
}
