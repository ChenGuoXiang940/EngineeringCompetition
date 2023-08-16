// See https://aka.ms/new-console-template for more information
using System.IO;
namespace _103_4
{
    class Program
    {
        public struct type
        {
            public string cs;
            public string csn;
            public string name;
            public string contest;
            public string sex;
        };
        public static List<type> col = new List<type>();
        public static List<string> all = new List<string>() {  "一顆球的距離", "天旋地轉", "滾大球袋鼠跳", "牽手同心", "大隊接力", "100公尺", "400公尺接力", "800公尺", "跳高" };
        public static List<string> all2 = new List<string>() { "大隊接力", "一顆球的距離", "天旋地轉", "滾大球袋鼠跳", "牽手同心", "100公尺", "400公尺接力", "800公尺", "跳高" };
        static void Main()
        {
            bool fg = true;
            while (fg)
            {
                Console.Write("請選擇操作項目:" + "\r\n\t" + "<1>批次輸入" + "\r\n\t" + "<2>選手查詢" + "\r\n\t" + "<3>刪除" + "\r\n\t" + "<4>逐筆輸入" + "\r\n\t" + "<5>顯示所有資料\r\n請選擇:");
                switch (Int16.Parse(Console.ReadLine()))
                {
                    case 1:
                        try
                        {
                            StreamReader din = File.OpenText(@"C:\Users\user002\Desktop\歷屆學長111\103技藝競賽\103-4測資.txt");
                            while (true)
                            {
                                string str = din.ReadLine();
                                if (str == "" || str == null) break;
                                string[] arr = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                                int record = 0;
                                int record2 = 0;
                                for(int i = 0; i < col.Count; i++)
                                {
                                    if (col[i].cs == arr[0] && col[i].csn == arr[1] && col[i].name == arr[2])
                                    {
                                        if (all.IndexOf(col[i].contest) < 4) record++;
                                        else if(all.IndexOf(col[i].contest) > 4) record2++;
                                    }
                                }
                                if (all.IndexOf(arr[4]) < 4) record++;
                                else if (all.IndexOf(arr[4]) > 4)record2++;
                                if (!(record > 2 || record2 > 2 || (record != 0 && record2 != 0))) col.Add(new type() { cs = arr[0], csn = arr[1], name = arr[2], sex = arr[3], contest = arr[4] });
                            }
                            Console.WriteLine("批次輸入完成!");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("檔案位置錯誤!" + ex);
                        }                       
                        break;
                    case 2:
                        Console.Write("選手查詢,\r\n請輸入 班級、學號、姓名:");
                        string[] arr2 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        for(int i = 0; i < col.Count; i++)
                        {
                            if (arr2[0] == col[i].cs && arr2[1] == col[i].csn && arr2[2] == col[i].name)
                            {
                                Console.WriteLine($"{col[i].cs} {col[i].csn} {col[i].name} {col[i].sex} {col[i].contest}");
                            }
                        }
                        break;
                    case 3:
                        Console.Write("刪除,\r\n請輸入 班級、學號、姓名、報名項目:");
                        string[]arr3 = Console.ReadLine().Split(' ').ToArray();
                        for(int i = 0; i < col.Count; i++)
                        {
                            if (arr3[0] == col[i].cs && arr3[1] == col[i].csn && arr3[2] == col[i].name && arr3[3] == col[i].contest)
                            {
                                Console.WriteLine("被刪除的選手資料:" + $"{col[i].cs} {col[i].csn} {col[i].name} {col[i].sex} {col[i].contest}");
                                col.RemoveAt(i);
                                break;
                            }
                        }                        
                        break;
                    case 4:
                        Console.Write("逐筆輸入,\r\n請輸入 班級、學號、姓名、性別:");
                        string[] arr4 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Console.WriteLine("報名項目:\r\na:大隊接力\r\nb:一顆球的距離\r\bc:天旋地轉\r\nd:滾大球袋鼠跳\r\ne:牽手同心\r\n" +
                            "f:100公尺\r\ng:400公尺接力\r\nh:800公尺接力\r\ni:跳高");
                        int check = Convert.ToChar(Console.ReadLine()) - 'a';
                        int record21 = 0;
                        int record22 = 0;
                        for (int i = 0; i < col.Count; i++)
                        {
                            if (col[i].cs == arr4[0] && col[i].csn == arr4[1] && col[i].name == arr4[2])
                            {
                                Console.WriteLine($"{col[i].cs} {col[i].csn} {col[i].name} {col[i].sex} {col[i].contest}");
                                if (all2.IndexOf(col[i].contest) <= 4 && all2.IndexOf(col[i].contest) != 0) record21++;
                                else if (all.IndexOf(col[i].contest) > 4) record22++;
                            }
                        }
                        if (record21 == 2 && check <= 4&&check != 0)
                        {
                            Console.WriteLine("已報團體賽,不能超過兩項!");
                        }
                        else if(record22 == 2 && check > 4)
                        {
                            Console.WriteLine("已報個人賽,不能超兩項!");
                        }
                        if (record21 != 0 && record22 == 0 && check > 4)
                        {
                            Console.WriteLine("已報團體賽,不能再報個人賽!");
                        }
                        else if(record22 != 0 && record21 == 0 && check <= 4 && check != 0)
                        {
                            Console.WriteLine("已報個人賽,不能再報團體賽!");
                        }
                        else col.Add(new type() { cs = arr4[0], csn = arr4[1], name = arr4[2], sex = arr4[3], contest = all2[check] });
                        break;
                    case 5:
                        Console.WriteLine("顯示所有資料:\r\n班級   學號   姓名   性別   報名項目");
                        for(int i = 0; i < col.Count; i++)
                        {
                            Console.WriteLine($"{col[i].cs} {col[i].csn} {col[i].name} {col[i].sex} {col[i].contest}");
                        }
                        break;
                }
                Console.Write("繼續:請按1,結束:請按0:");
                if (Console.ReadLine() == "0") fg = false;
            }
            Console.ReadKey();
        }
    }
}
