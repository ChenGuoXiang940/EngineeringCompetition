// See https://aka.ms/new-console-template for more information
namespace _110_6
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[,] col = new int[100, 2];
            int count = 0;
            while (count < 100)
            {
                string line = Console.ReadLine() + "";
                if (line.Replace(" ","") == "") break;
                int[] str = (line.Split(' ')).Select<string, int>(x => Int16.Parse(x)).ToArray();
                col[count, 0] = str[0];
                col[count, 1] = str[1];
                count++;
            }
            int result = count != 0 ? 1 : 0;
            int end = col[0, 1];
            for(int i = 1; i < count; i++)
            {
                if (end > col[i, 1])
                {
                    result++;
                    end = col[i, 1];
                }
                else if (end <= col[i, 0])
                {
                    result++;
                    end = col[i, 1];
                }
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
