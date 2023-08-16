// See https://aka.ms/new-console-template for more information
namespace 陳國翔_Q6
{
    class Program
    {
        public static void Main()
        {
            char[] ch = Console.ReadLine().ToCharArray();
            var dict = new Dictionary<char, int>();
            foreach(char item in ch)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }
            string ans = "";
            Array.ForEach(dict.OrderBy(x => x.Value).Reverse().ToArray(), item => ans += $"\"{item.Key}\"={item.Value};");
            Console.WriteLine("輸出:" + ans.TrimEnd(';'));
            Console.ReadKey();
        }
    }
}
