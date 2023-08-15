// See https://aka.ms/new-console-template for more information
namespace _98_2
{
    static class Program
    {
        static void Main()
        {
            String s1 = "1 ";
            String record = "";
            Int16 val = Int16.Parse(Console.ReadLine());
            Console.WriteLine("1");
            for(int i = 0; i < val; i++)
            {
               int t = 1;
               for(int j = 0; j < s1.Length - 1; j++)
               {
                    if (s1[j] != s1[j + 1])
                    {
                        record += t.ToString() + s1[j];
                    }
                    else
                    {
                        t++;
                    }
               }
                Console.WriteLine(record);
                s1 = record + " ";
                record = "";
            }
            Console.ReadKey();
        }
    }
}
