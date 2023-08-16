// See https://aka.ms/new-console-template for more information
namespace 陳國翔_Q2
{
    class Program
    {
        static void Main()
        {
            //測資:
            //1100011110
            //0010010111
            /*字串的字元中間多空格*/
            Func<string, string> tostr = (x) => string.Join(" ", x.ToCharArray());
            /*整數轉字串如果長度不足 5 左邊補字元'0'*/
            Func<int, string> to2pad = (x) => Convert.ToString(x, 2).PadLeft(5, '0');
            /*2進制字串轉16進制，要先轉10進制才來轉16進制*/
            Func<string, string> to16 = (x) => "0x" + Convert.ToString(Convert.ToInt32(x, 2), 16);
            Console.Write("請輸入10位元的Key: ");
            string t = Console.ReadLine() + "";
            Console.WriteLine($"輸入   Key :{tostr(t)} = {to16(t)}");
            string t2 = $"{t[2]}{t[4]}{t[1]}{t[6]}{t[3]}{t[9]}{t[0]}{t[8]}{t[7]}{t[5]}";
            Console.WriteLine($"重新排列10 :{tostr(t2)} = {to16(t2)}");
            int a = Convert.ToInt32(t2.Substring(0, 5), 2);
            int b = Convert.ToInt32(t2.Substring(5, 5), 2);
            int c = (a << 1) % 32 + (a << 1) / 32;
            int d = (b << 1) % 32 + (b << 1) / 32;
            string t3 = to2pad(c) + to2pad(d);
            Console.WriteLine($"左旋轉1    :{tostr(t3)} = {to16(t3)}");
            string t4 = $"{t3[5]}{t3[2]}{t3[6]}{t3[3]}{t3[7]}{t3[4]}{t3[9]}{t3[8]}";
            Console.WriteLine($"Key輸出1   :{tostr(t4).PadRight(19)} = {to16(t4)}");
            int e = (c << 2) % 32 + (c << 2) / 32;
            int f = (d << 2) % 32 + (d << 2) / 32;
            string t5 = to2pad(e) + to2pad (f);
            Console.WriteLine($"左旋轉2    :{tostr(t5)} = {to16(t5)}");
            string t6 = $"{t5[5]}{t5[2]}{t5[6]}{t5[3]}{t5[7]}{t5[4]}{t5[9]}{t5[8]}";
            Console.WriteLine($"Key輸出2   :{tostr(t6).PadRight(19)} = {to16(t6)}");
            Console.ReadKey();
        }
    }
}
