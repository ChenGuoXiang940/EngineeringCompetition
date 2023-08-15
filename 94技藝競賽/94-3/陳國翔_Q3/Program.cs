// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

namespace 陳國翔_Q3
{
    class Program
    {
        public static int[,] moved2 = { { 1, 0 }, { 0, -1 }, { -1, 0 }, { 0, 1 } };
        public static int[,] moved = { { 2, 1 }, { 2, -1 }, { 1, -2 }, { -1, -2 }, { -2, -1 }, { -2, 1 }, { -1, 2 }, { 1, 2 } };
        public static bool check(int x,int y)
        {
            if (x < 0 || y < 0 || x > 7 || y > 7) return false;
            return true;
        }
        public static void Main()
        {
            Console.Write("馬目前位置與一些障礙物:");//4 5 4 4 2 6 5 7
            int[] arr = Console.ReadLine().Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x) - 1).ToArray();
            int[,] map = new int[8, 8];
            for(int i = 2; i < arr.Length; i += 2)
            {
                map[arr[i + 1], arr[i]] = 1;
            }
            int x = arr[1];
            int y = arr[0];
            int key;
            while (true)
            {
                Console.Write("輸入移動數字鍵:");
                if(int.TryParse(Console.ReadLine(),out key) && key >= 0 && key <= 7)
                {
                    if (check(x + moved[key, 0] , y + moved[key, 1]))
                    {
                        int get = key / 2;
                        int x1 = x + moved2[get, 0];
                        int y1 = y + moved2[get, 1];
                        if (map[x1, y1] != 1)
                        {
                            map[x + moved[key, 0], y + moved[key, 1]] = 0;
                            x += moved[key, 0];
                            y += moved[key, 1];
                            Console.WriteLine($"馬移動至新位置{y + 1} {x + 1}");
                        }
                        else
                        {
                            Console.WriteLine($"馬移動至新位置{y + 1} {x + 1} (馬因綑綁而保持原座標)");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"馬移動至新位置{y + 1} {x + 1} (因超出棋盤外而保持原座標)");
                    }
                    continue;
                }
                Console.SetCursorPosition(20, Console.CursorTop - 1);
                Console.WriteLine("結束此程式!");
                break;
            }
            Console.ReadKey();
        }
    }
}
