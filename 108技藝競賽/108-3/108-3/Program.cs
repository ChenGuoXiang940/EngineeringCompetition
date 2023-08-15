namespace _108_3
{
    static class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine() + "";
            if(line.Contains(' '))
            {
                //068afa4e 01871c0c 005af200 00160ecc 000553e6 
                //068b0621 01871ecd 005af2a6 00160ef5 000553ef
                //068b0bfc 01872028 005af2f4 00160f07 000553f5
                char[] ch = new char[5];
                int[] ans = line.Split(' ').Select(x => Convert.ToInt32(x, 16)).ToArray();
                int[] data = { 0xabcd, 0xcdef, 0x2266, 0xceed, 0xaccd };
                int a = ans[0] - data[0], b = ans[1] - data[1], c = ans[2] - data[2], d = ans[3] - data[3], e = ans[4] - data[4];
                int w, t;
                for(int i = 0; i < 5; i++)
                {
                    t = a;a = b;b = c;c = d;d = e;e = data[i];
                    int k = 0x5a82;
                    int f = b + c;
                    w = t - (4 * a + f + e + k);
                    ch[4 - i] = (char)(w + ' ');
                }
                Console.WriteLine(String.Join("", ch));
            }
            else
            {
                //apple
                //juice
                //point
                int h0 = 0xabcd, h1 = 0xcdef, h2 = 0x2266, h3 = 0xceed, h4 = 0xaccd;
                int a = h0, b = h1, c = h2, d = h3, e = h4, w, t;
                for (int i = 0; i < 5; i++)
                {
                    w = line[i] - ' ';
                    t = 4 * a + b + c + e + 0x5a82 + w;
                    e = d; d = c; c = b; b = a; a = t;
                }
                h0 += a; h1 += b; h2 += c; h3 += d; h4 += e;
                Console.WriteLine($"{h0.ToString("x8")} {h1.ToString("x8")} {h2.ToString("x8")} {h3.ToString("x8")} {h4.ToString("x8")}");
            }
            Console.ReadKey();
        }
    }
}
