// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Text;
namespace _106_5
{
    class Program
    {
        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string path = Console.ReadLine() + "";
            StreamReader din = new StreamReader(@path, CodePagesEncodingProvider.Instance.GetEncoding("big5"));
            din.ReadLine();
            din.ReadLine();
            din.ReadLine();
            List<double> col = (din.ReadLine()+"").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select<string, double>(x => double.Parse(x)).ToList();
            double[] b = new double[col.Count];
            double[] yn1 = new double[col.Count];
            double len1 = 0;
            double len2 = 0;
            for(int i = 0; i < col.Count; i++)
            {
                len1 += i + 1;
                len2 += col[i];
                if (i >= 9)
                {
                    double avx = len1 / 10;
                    double avy = len2 / 10;
                    double bup = 0;
                    double bdown = 0;
                    for(int j = i - 9; j <= i; j++)
                    {
                        bup += (j + 1 - avx) * (col[j] - avy);
                        bdown += Math.Pow(j + 1 - avx, 2);
                    }
                    b[i] = bup / bdown;
                    if (i != col.Count - 1)
                    {                       
                        double a = avy - b[i] * avx;
                        yn1[i + 1] = a + b[i] * (i + 2);
                    }
                    len1 -= i - 8;
                    len2 -= col[i - 9];
                }
            }
            Console.WriteLine("直線斜率:");
            string str1 = "";
            foreach(double item in b)
            {
                str1 = item == 0 ? str1 + "0.0 " : str1 + Math.Round(item, 1).ToString() + " ";
            }
            Console.WriteLine(str1.TrimEnd(' '));
            Console.WriteLine("價格預測:");
            string str2 = "";
            foreach(double item in yn1)
            {
                str2 = item == 0 ? str2 + "0.0 " : str2 + Math.Round(item, 1).ToString() + " ";
            }
            Console.WriteLine(str2.TrimEnd(' '));
            Console.ReadKey();
        }
    }
}
