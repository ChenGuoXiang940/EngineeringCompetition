// See https://aka.ms/new-console-template for more information
namespace _107_3
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入密碼:");
            string line = Console.ReadLine() + "";
            bool fg = line.Length >= 8 && line.Length <= 128 ? true : false;
            Console.WriteLine("密碼長度:" + line.Length);
            int letter1 = 0;
            int letter2 = 0;
            int number1 = 0;
            int number2 = 0;
            string str="!@#$%^&*()_+-";
            for(int i = 0; i < line.Length; i++)
            {
                if (line[i] - 'a' >= 0 && line[i] - 'z' <= 0)
                {
                    letter1++;
                }
                else if (line[i] - 'A' >= 0 && line[i] - 'Z' <= 0)
                {
                    letter2++;
                }
                else if (line[i] - '0' >= 0 && line[i] - '9' <= 0)
                {
                    number1++;
                }
                else if (str.Contains(line[i]))
                {
                    number2++;
                }
            }
            int count = 0;
            if (letter1 > 0)
            {
                count++;
            }
            if(letter2 > 0)
            {
                count++;
            }
            if (letter1 > 0)
            {
                count++;
            }
            if (letter2 > 0)
            {
                count++;
            }
            Console.WriteLine("小寫文字字母長度:" + letter1);
            Console.WriteLine("大寫文字字母長度:" + letter2);
            Console.WriteLine("數字長度:" + number1);
            Console.WriteLine("符號長度" + number2);
            if (count >= 3 && fg)
            {
                Console.WriteLine("符合密碼規則");
            }
            else
            {
                Console.WriteLine("不符合密碼規則");
            }
            Console.ReadKey();
        }
    }
}
