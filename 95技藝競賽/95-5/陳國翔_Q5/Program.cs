// See https://aka.ms/new-console-template for more information
namespace 陳國翔_Q5
{
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                double[] arr = Console.ReadLine().Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
                if (arr[0] < 50 && arr[1] < 100)
                {
                    Console.WriteLine((int)(arr.Average() * 0.6 * 5 + 0.5));
                }
                else if ((arr[0] < 50 && arr[1] >= 100 && arr[1] <= 200) || (arr[0] >= 50 && arr[0] <= 100 && arr[1] < 100))
                {
                    Console.WriteLine((int)(arr.Average() * 0.8 * 5 + 0.5));
                }
                else if (arr[0] > 100 && arr[1] > 200)
                {
                    Console.WriteLine((int)(arr.Average() * 1.4 * 5 + 0.5));
                }
                else if ((arr[0] > 100 && arr[1] >= 100 && arr[1] <= 200) || (arr[0] >= 50 && arr[0] <= 100 && arr[1] > 200))
                {
                    Console.WriteLine((int)(arr.Average() * 1.2 * 5 + 0.5));
                }
                else
                {
                    Console.WriteLine((int)(arr.Average() * 5 + 0.5));
                }
            }
        }
    }
}
