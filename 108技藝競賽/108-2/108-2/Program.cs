// See https://aka.ms/new-console-template for more information
using System.Text;
namespace _108_2
{
    public static class Program
    {
        public static string hudp(List<string>n,List<double>r,int val)
        {
            List<string> list = new List<string>();
            for(int i = 0; i < val; i++)
            {
                int aim = r.IndexOf(r.Max());
                list.Add(String.Format("{0}({1:0.00})", n[aim], r[aim]));
                n.RemoveAt(aim);
                r.RemoveAt(aim);
            }
            return string.Join(" ", list);
        }
        public static string ludp(List<string> n, List<double> r,int val)
        {
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < val; i++)
            {
                int aim = r.IndexOf(r.Min());
                stack.Push(String.Format("{0}({1:0.00})", n[aim], r[aim]));
                n.RemoveAt(aim);
                r.RemoveAt(aim);
            }
            return string.Join(" ", stack);
        }
        public static string huda(List<string> n, List<double> r)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                int aim = r.IndexOf(r.Max());
                list.Add(String.Format("{0}({1:P})", n[aim], r[aim]));
                n.RemoveAt(aim);
                r.RemoveAt(aim);
            }
            return string.Join(" ", list);
        }
        public static string luda(List<string> n, List<double> r)
        {
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < 3; i++)
            {
                int aim = r.IndexOf(r.Min());
                stack.Push(String.Format("{0}({1:P})", n[aim], r[aim]));
                n.RemoveAt(aim);
                r.RemoveAt(aim);
            }
            return string.Join(" ", stack);
        }
        public static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string path = Console.ReadLine() + "";
            StreamReader din = new StreamReader(path, CodePagesEncodingProvider.Instance.GetEncoding("big5"));
            Console.WriteLine("讀入:" + path + "檔");
            din.ReadLine();
            string line = "";
            List<string> name = new List<string>();
            List<double> record1 = new List<double>();
            List<double> record2 = new List<double>();
            List<string> check = new List<string>();
            while (true)
            {
                line = din.ReadLine() + "";
                if (line == null || line == "") break;
                List<string> col = line.Split('\t').ToList();
                double btc = double.Parse(col[2]);
                double tc = double.Parse(col[6]);
                double udp = tc - btc;
                double uda = Math.Round(udp / btc, 4);
                double udu = 0;
                if (btc < 10)
                {
                    udu = 0.01;
                }
                else if (btc < 50)
                {
                    udu = 0.05;       
                }
                else if (btc < 100)
                {
                    udu = 0.1;
                }
                else if (btc < 500)
                {
                    udu = 0.5;
                }
                else if(btc < 1000)
                {
                    udu = 1;
                }
                else
                {
                    udu = 5;
                }
                double tcd = btc * 0.1;
                int udu2 = (int)(tcd / udu);
                double usp = Math.Round(btc + udu2 * udu, 2);
                double dsp = Math.Round(btc - udu2 * udu, 2);
                name.Add(col[1]);
                record1.Add(udp);
                record2.Add(uda);
                String ex = tc == usp ? "漲停" : tc == dsp ? "跌停" : "";
                check.Add(ex);
            }
            Console.WriteLine("漲跌價最高之3支股票(漲價元):" + hudp(name.ToList(), record1.ToList(), 3));
            Console.WriteLine("漲跌價最低之3支股票(漲價元):" + ludp(name.ToList(), record1.ToList(), 3));
            Console.WriteLine("漲跌幅最高之3支股票(漲幅%):" + huda(name.ToList(), record2.ToList()));
            Console.WriteLine("漲跌幅最低之3支股票(漲幅%):" + luda(name.ToList(), record2.ToList()));
            List<string> n1 = new List<string>();
            List<double> r1 = new List<double>();
            List<string> n2 = new List<string>();
            List<double> r2 = new List<double>();
            for(int i = 0; i < check.Count; i++)
            {
                if (check[i] == "漲停")
                {
                    n1.Add(name[i]);
                    r1.Add(record1[i]);
                }
                else if (check[i] == "跌停")
                {
                    n2.Add(name[i]);
                    r2.Add(record1[i]);
                }
            }
            Console.WriteLine("所有漲跌股票:(漲停價元):" + hudp(n1, r1, n1.Count));
            Console.WriteLine("所有漲跌股票(跌停價元):" + ludp(n2, r2, n2.Count));
            Console.ReadKey();
        }
    }
}
