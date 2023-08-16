// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
namespace 陳國翔_Q4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("南港高工生產排程系統");
            bool fg = true;
            LinkedList<Data> list = new LinkedList<Data>();
            while (fg)
            {
                Console.Write("請選擇:\r\n\t1.生產線左邊加入物件\r\n\t2.生產線左邊刪除物件\r\n\t3.生產線右邊加入物件\r\n\t4.生產線右邊刪除物件\r\n\t5.生產排程結束\r\n? ");
                string text = Console.ReadLine() + "";
                switch (text)
                {
                    case "1":
                    case "3":
                        Console.Write("請輸入物件編號: ");
                        int val = int.Parse(Console.ReadLine() + "");
                        if (list.Count == 5)
                        {
                            Console.WriteLine("生產線滿了!\r\n生產線線上有 5 物件");
                            continue;
                        }
                        if (list.Count == 0) list.AddFirst(new Data(val, 0));
                        else if (text == "1")
                        {
                            list.AddFirst(new Data(val, list.First().sign + 1));
                        }
                        else
                        {
                            list.AddLast(new Data(val, list.Last().sign - 1));
                        }
                        Console.WriteLine($"從{(text switch { "1" => "左", "3" => "右" })}邊加入:");
                        Console.WriteLine($"左邊作業員編號 : {list.First().sign}");
                        Console.WriteLine($"右邊作業員編號 : {list.Last().sign}");
                        Console.WriteLine($"加入物件 : {val}");
                        Console.WriteLine($"生產線線上有 {list.Count} 物件");
                        break;
                    case "2":
                    case "4":
                        if (list.Count == 0)
                        {
                            Console.WriteLine("生產線是空的!\r\n生產線線上有 0 物件");
                            continue;
                        }
                        int val2;
                        if (text == "2")
                        {
                            val2 = list.First().val;
                            list.RemoveFirst();
                        }
                        else
                        {
                            val2 = list.Last().val;
                            list.RemoveLast();
                        }
                        Console.WriteLine($"從{(text switch { "2" => "左", "4" => "右" })}邊刪除:");
                        Console.WriteLine($"左邊作業員編號 : {(list.Count == 0 ? "0" : list.First().sign)}");
                        Console.WriteLine($"右邊作業員編號 : {(list.Count == 0 ? "0" : list.Last().sign)}");
                        Console.WriteLine($"\r\n刪除物件 : {val2}");
                        Console.WriteLine($"生產線線上有 {list.Count} 物件");
                        break;
                    case "5":
                        fg = false;
                        break;
                    default:
                        Console.WriteLine("輸入錯誤! 請重新輸入!");
                        break;
                }
            }
            Console.WriteLine("生產排程系統結束!");
            Console.ReadKey();
        }
    }
    public class Data
    {
        public int val;
        public int sign;
        public Data(int val, int sign)
        {
            this.val = val;
            this.sign = sign == -1 ? 4 : sign == 5 ? 0 : sign;
        }
    }
}
