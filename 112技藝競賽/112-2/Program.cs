namespace _112_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("輸入原來的英文單字:");
            string a = Console.ReadLine() + "";
            Console.Write("輸入改變後的英文單字:");
            string b = Console.ReadLine() + "";
            int[,] dp = new int[a.Length + 1, b.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 0; j < b.Length; j++)
            {
                dp[0, j] = j;
            }
            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int count = (a[i - 1] == b[j - 1]) ? 0 : 2;
                    dp[i,j]= Math.Min(dp[i - 1, j - 1] + count, Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1));
                }
            }
            Console.WriteLine("編輯距離為:" + dp[a.Length, b.Length]);
            Console.ReadKey();
        }
    }
}
