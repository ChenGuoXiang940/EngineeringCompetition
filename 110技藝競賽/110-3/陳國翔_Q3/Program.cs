// See https://aka.ms/new-console-template for more information
namespace 陳國翔_Q3
{
    class Program
    {
        static void Main()
        {
            ulong[] f = new ulong[93];
            f[1] = 1;
            f[2] = 1;
            Console.WriteLine("1 1");
            Console.WriteLine("2 1");
            for (int i = 3; i < 93; i++)
            {
                f[i] = f[i - 2]+ f[i - 1];
                Console.WriteLine($"{i} {f[i]}");
            }
            Console.Write("請從這些費式(Fibonacci Sequence)數列中選擇第1個數:");
            int a = int.Parse(Console.ReadLine() + "");
            Console.WriteLine($"你選擇第 {a} 費式(Fibonacci Sequence)數列:{f[a]}");
            Console.Write("請從這些費式(Fibonacci Sequence)數列中選擇第2個數:");
            int b = int.Parse(Console.ReadLine() + "");
            Console.WriteLine($"你選擇第 {b} 費式(Fibonacci Sequence)數列:{f[b]}");
            Console.WriteLine($"兩個費式(Fibonacci Sequence)數列相加結果為:{f[a] + f[b]}");
            Console.ReadKey();
        }
    }
}
