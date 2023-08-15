// See https://aka.ms/new-console-template for more information
namespace 陳國翔_Q7
{
    class Program
    {
        static void Main()
        {
            Console.Write("請輸入電阻值R，單位為歐姆=");
            double r = double.Parse(Console.ReadLine());
            Console.Write("請輸入電容值C，單位為法拉=");
            double c = double.Parse(Console.ReadLine());
            Console.Write("請輸入頻率值f，單位赫茲=");
            double f = double.Parse(Console.ReadLine());
            double rcf = r * c * f * 2 * Math.PI;
            double Av = Math.Sqrt(1 + Math.Pow(rcf, 2));
            Console.WriteLine($"濾波器大小Z={(20 * Math.Log10(1 / Av)).ToString("0.000")}dB");
            Console.WriteLine($"濾波器的相角theta={(-Math.Atan(rcf) * 180 / Math.PI).ToString("0.000")}");
            Console.ReadKey();
        }
    }
}
