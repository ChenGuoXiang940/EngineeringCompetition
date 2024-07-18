using System.Drawing;
using System.IO;
namespace _112_6
{
    internal class Program
    {
        private struct Elevator
        {
            public int dire;
            public int pos;
            public int wait;
        }
        private static string[] read(ref StreamReader sr)
        {
            string[] buf = (sr.ReadLine() + "").Split(' ');
            Console.WriteLine(string.Join("   ", buf));
            return buf;
        }
        static void Main(string[] args)
        {
            string[] title = { " AI", " BI", " OU", " OD", "TAD", "TAU", "TBD", "TBU" };
            Console.Write("Enter 1st filename:");
            StreamReader sr = File.OpenText(Console.ReadLine() + "");
            Elevator[] elevators = new Elevator[2];        
            string[] buf;
            for(int i = 0; i < 2; i++)
            {
                buf = read(ref sr);
                elevators[i].dire = buf[1] == "U" ? 1 : -1;
                elevators[i].pos = buf[2] == "B2" ? 0 : buf[2] == "B1" ? 1 : int.Parse(buf[2]) + 1;
                elevators[i].wait = 0;
            }
            buf= read(ref sr);
            int final = buf[1] == "B2" ? 0 : buf[1] == "B1" ? 1 : int.Parse(buf[1]) + 1;
            sr.Close();
            Console.Write("Enter 2st filename:");
            sr = File.OpenText(Console.ReadLine() + "");
            int[,] map = new int[8, 18];
            for(int i = 0; i < 8; i++)
            {
                Console.Write(title[i] + "   ");
                buf = read(ref sr);
                if (i >= 4) continue;
                for(int j = 0; j < 18; j++)
                {
                    map[i, j] = int.Parse(buf[j]);
                }
            }
            sr.Close();
            Console.WriteLine("\r\n列印結果.");
            while (true)
            {
                int i = elevators[0].wait < elevators[1].wait ? 0 : 1;
                map[(i == 0 ? 4 : 6) + (elevators[i].dire == -1 ? 0 : 1), elevators[i].pos] = elevators[i].wait;
                if (final == elevators[i].pos)
                {
                    int j = Math.Abs(i - 1);
                    if (elevators[i].pos == elevators[j].pos && elevators[i].wait == elevators[j].wait)
                    {
                        map[(j == 0 ? 4 : 6) + (elevators[j].dire == -1 ? 0 : 1), elevators[j].pos] = elevators[j].wait;
                    }
                    break;
                }
                int cur = elevators[i].pos + elevators[i].dire;
                bool check = false;// 檢查同方向是否有人要上電梯
                while (cur >= 0 && cur < 18)
                {
                    if (map[i, cur] == 1 || map[2, cur] == 1 || map[3, cur] == 1)
                    {
                        check = true;
                        break;
                    }
                    cur += elevators[i].dire;
                }
                if (!check)
                {
                    map[i, elevators[i].pos] = map[(elevators[i].dire == 1 ? 3 : 2), elevators[i].pos] = 0;
                    elevators[i].wait += 6;
                    elevators[i].dire = -elevators[i].dire;
                }
                else
                {
                    elevators[i].wait += map[i, elevators[i].pos] == 1 || (map[(elevators[i].dire == 1 ? 2 : 3), elevators[i].pos] == 1) ? 9 : 3;
                    map[i, elevators[i].pos] = map[(elevators[i].dire == 1 ? 2 : 3), elevators[i].pos] = 0;
                    elevators[i].pos += elevators[i].dire;
                }
            }
            Console.WriteLine("樓層 B2  B1   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16");
            for(int i = 0; i < 8; i++)
            {
                Console.Write(title[i]);
                for (int j = 0; j < 18; j++)
                {
                    Console.Write(map[i, j].ToString().PadLeft(4,' '));
                }
                Console.WriteLine();
            }
            sr.Close();
        }
    }
}
