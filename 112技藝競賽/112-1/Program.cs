namespace _112_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("輸入 x1=");
            string x = Console.ReadLine() + "";
            string rd = "";
            int cnt = 1;
            while (true)
            {
                string x1 = string.Join("", x.ToCharArray().OrderBy(x => x).Reverse());
                string x2 = string.Join("", x.ToCharArray().OrderBy(x => x));
                x = (int.Parse(x1) - int.Parse(x2)).ToString();
                if (x == rd)
                {
                    Console.Write($"，黑洞數={x}");
                    break;
                }
                Console.Write($"\r\nx{cnt++}:{x1}-{x2}={x}");
                rd = x;
            }
            Console.ReadKey();
        }
    }
}
