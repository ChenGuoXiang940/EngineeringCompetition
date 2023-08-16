// See https://aka.ms/new-console-template for more information
namespace ConsoleApp1
{
    class Program
    {
        public static bool check(long v)
        {
            long m = v % 6;
            if (m != 1 && m != 5) return false;
            long sq = (long)Math.Sqrt(v);
            for (long i = 5; i <= sq; i += 6)
            {
                if (v % i == 0 || v % (i + 2) == 0) return false;
            }
            return true;
        }
        public static long GCD(long a, long b)
        {
            if (b == 0) return a;
            return a % b == 0 ? b : GCD(b, a % b);
        }
        static void Main()
        {
            Console.Write("請輸入測資:");
            StreamReader din = File.OpenText(@Console.ReadLine() + "");
            string line = "";
            while (!string.IsNullOrEmpty(line = din.ReadLine() + ""))
            {
                long[] arr = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();
                long com = GCD(arr[0], arr[1]);
                Data data1 = new Data(arr[0]), data2 = new Data(arr[1]);
                Console.WriteLine($"{data1.text},{data2.text},{com},{(com != 1 && (check(com) || com == 2 || com == 3) ? "Y" : "N")}");
            }
            Console.ReadKey();
        }
    }
    class Data : Program
    {
        public string text = "";
        private void deal(ref long val,long count)
        {
            int record = 0;
            while (val % count == 0)
            {
                val /= count;
                record++;
            }
            if (record >= 1) text += record == 1 ? $"{count}*" : $"{count}^{record}*";
        }
        public Data(long val)
        {
            if (check(val))
            {
                text = val.ToString();
                return;
            }
            deal(ref val, 2);
            deal(ref val, 3);
            int count = 5;
            while (val >= count)
            {
                
                if (val % count is 0)
                {
                    deal(ref val, count);
                }
                else if (val % (count + 2) is 0)
                {
                    deal(ref val, count + 2);
                }
                else
                {
                    count += 6;
                }
            }
            this.text = this.text.TrimEnd('*');
        }
    }
}
