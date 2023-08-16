// See https://aka.ms/new-console-template for more information
using System.IO;
namespace 路徑
{
    class Program
    {
        static void Main()
        {
            StreamReader din = File.OpenText(@"C:\Users\user02\Desktop\歷屆學長111\102技藝競賽\102-3測資\data3.txt");
            string line;
            int end = -1;
            int[,] map = new int[1000, 1000];
            while ((line=din.ReadLine())!=null)
            {
                int[] arr = line.Split(' ').Select(x => Int32.Parse(x)).ToArray();
                map[arr[0], arr[1]] = arr[2];
                end = Math.Max(arr[1],end);
            }
            //迴圈解
            int[] path = new int[end + 1];
            for(int i = 2; i <= end; i++)
            {
                path[i] = Int32.MaxValue;//設為最大值好比大小(找最短路徑)
            }
            string[] number = new string[end + 1];
            string[] record = new string[end + 1];
            number[1] = "   1";
            record[1] = "   0";
            for(int i = 1; i <= end; i++)
            {              
                for(int j = 1; j <= end; j++)
                {
                    if (map[i, j] != 0 && path[j] > path[i] + map[i, j])
                    {
                        path[j] = path[i] + map[i, j];//花費總和
                        number[j] = number[i] + $"{j}".PadLeft(4, ' ');//路徑次序
                        record[j] = record[i] + $"{map[i,j]}".PadLeft(4, ' ');//路徑花費                     
                    }
                }
            }
            Console.WriteLine("最低成本值總和:" + path[end]);
            Console.WriteLine("路徑次序:" + number[end]);
            Console.WriteLine("連接數值:" + record[end]);
            Console.ReadKey();
        }
    }
}
