// See https://aka.ms/new-console-template for more information
namespace 陳國翔_Q4
{
    class Program
    {
        public static void Main()
        {
            //100 1/5 0.8
            //100 1/5 0.9
            //80 1/5 0.8
            //80 1/5 0.9

            //100 3/5 0.8
            //100 3/4 0.9
            //80 4/7 0.8
            //80 2/5 0.9
            List<double> ans = new List<double>();
            for(int i = 0; i < 4; i++)
            {
                string[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                double v = double.Parse(arr[0]);
                double circle = double.Parse(arr[1].Split('/')[0]) / double.Parse(arr[1].Split('/')[1]);
                double D = double.Parse(arr[2]);
                ans.Add(v * circle / D);
            }
            Array.ForEach(ans.ToArray(), item => Console.WriteLine(Math.Round(item, 0)));
            Console.ReadKey();
        }
    }
}
