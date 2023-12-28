namespace _112_3
{
    internal class Program
    {
        public static char[] arr = new char[9];
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("你為O，你的電腦為X\r\n位置對應數字鍵盤");
            int cnt = 9;
            do
            {
                if (cnt == 9) arr = arr.Select(x => '□').ToArray();
                Console.Write($"{arr[0]}{arr[1]}{arr[2]}\r\n{arr[3]}{arr[4]}{arr[5]}\r\n{arr[6]}{arr[7]}{arr[8]}\r\n請輸入1~9(按0結束):");
                int input = int.Parse(Console.ReadLine() + "");
                if (input == 0) break;
                if (arr[input - 1] != '□')
                {
                    Console.WriteLine("此位置已有棋子");
                    continue;
                }
                arr[input - 1] = 'O';
                cnt--;
                while (cnt >= 1)
                {
                    int rndnum = rnd.Next(0, 9);
                    if (arr[rndnum] == '□')
                    {
                        arr[rndnum] = 'X';
                        cnt--;
                        break;
                    }
                }
                if (check())
                {
                    cnt = 9;
                    continue;
                }
                if (cnt == 0)
                {
                    cnt = 9;
                    Console.WriteLine($"{arr[0]}{arr[1]}{arr[2]}\r\n{arr[3]}{arr[4]}{arr[5]}\r\n{arr[6]}{arr[7]}{arr[8]}");
                    Console.WriteLine("雙方平手 再來一盤");
                    continue;
                }
            } while (true);
        }
        public static bool check()
        {
            string[] str = new string[9];
            for(int i = 0; i < 3; i++)
            {
                str[0] += arr[i*3];
                str[1] += arr[i * 3 + 1];
                str[3] += arr[i * 3 + 2];
                str[4] += arr[i];
                str[5] += arr[i + 3];
                str[6] += arr[i + 6];
            }
            str[7] = $"{arr[0]}{arr[4]}{arr[8]}";
            str[8] = $"{arr[2]}{arr[4]}{arr[6]}";
            foreach(string s in str)
            {
                if (s == "OOO")
                {
                    Console.WriteLine($"{arr[0]}{arr[1]}{arr[2]}\r\n{arr[3]}{arr[4]}{arr[5]}\r\n{arr[6]}{arr[7]}{arr[8]}");
                    Console.WriteLine("你O方獲勝 再來一盤");
                    return true;
                }
                else if (s == "XXX")
                {
                    Console.WriteLine($"{arr[0]}{arr[1]}{arr[2]}\r\n{arr[3]}{arr[4]}{arr[5]}\r\n{arr[6]}{arr[7]}{arr[8]}");
                    Console.WriteLine("電腦X方獲勝 再來一盤");
                    return true;
                }
            }
            return false;
        }
    }
}
