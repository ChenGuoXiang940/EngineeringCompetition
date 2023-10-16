// See https://aka.ms/new-console-template for more information
using ld = System.Collections.Generic.List<double>;
namespace _104_4
{
    class Program
    {
        static void Main()
        {
            ld up = new ld();
            ld mid = new ld();
            ld down = new ld();
            ld count = new ld();
            do
            {
                Console.Write("請選擇操作項目:\r\n\t<1>輸入模型資料\r\n\t<2>計算平均相似度\r\n\t<3>顯示各資料相似度\r\n慶選擇:");
                switch (Console.ReadLine())
                {
                    case "1":
                        count.Clear();
                        Console.Write("\r\n輸入模型資料,總筆數為:");
                        int times = Int16.Parse(Console.ReadLine() + "");
                        Console.Write("\r\n    序列< X軸>:");
                        Console.ReadLine();
                        Console.Write("數值串列<上限>:");
                        up = (Console.ReadLine() + "").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList();
                        Console.Write("數值串列<中限>:");
                        mid = (Console.ReadLine() + "").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList();
                        Console.Write("數值串列<下限>:");
                        down = (Console.ReadLine() + "").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList();
                        break;
                    case "2":
                        Console.Write("請輸入[資料串列]檔名:");
                        string path = Console.ReadLine() + "";
                        try
                        {
                            StreamReader din = File.OpenText(@path);
                            Console.WriteLine("已開啟[資料串列]檔名:" + path);
                            ld value = (din.ReadLine() + "").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList();
                            for (int i = 0; i < up.Count; i++)
                            {
                                if (value[i] > up[i] || value[i] < down[i])
                                {
                                    count.Add(0);
                                }
                                else if (value[i] <= mid[i])
                                {
                                    count.Add((value[i] - down[i]) / (mid[i] - down[i]));
                                }
                                else
                                {
                                    count.Add((value[i] - up[i]) / (mid[i] - up[i]));
                                }
                            }
                            Console.WriteLine("平均相似度為:" + Math.Round(count.Average(), 6));
                        }
                        catch
                        {
                            Console.WriteLine("未開啟[資料串列]檔名:" + path);
                        }
                        break;
                    case "3":
                        string str2 = "";
                        foreach (double item in count)
                        {
                            str2 += Math.Round(item, 3) + " ";
                        }
                        Console.WriteLine("各資料相似度為:" + str2.TrimEnd(' '));
                        break;
                }
            } while (check());
            Console.ReadKey();
        }
        public static bool check()
        {
            Console.Write("\r\n繼續:請按1,結束:請按0:");
            string str = Console.ReadLine() + "";
            return (str != "0");
        }
    }
}
