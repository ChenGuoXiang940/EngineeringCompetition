using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace _109_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("輸入檔案名:");
            string path = Console.ReadLine();
            StreamReader din = File.OpenText(@Path.Combine(path, "LabelData.txt"));
            string line;
            Pen pen = new Pen(Color.Red, 3);
            Console.WriteLine("開始繪製圖框!");
            while (!string.IsNullOrEmpty(line = din.ReadLine()))
            {
                string[] arr = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                Bitmap bitmap = new Bitmap(@Path.Combine(path, arr[0]));
                Graphics g = Graphics.FromImage(bitmap);
                int len = int.Parse(arr[1]);
                float[] arr2 = new float[len * 4];
                for(int i = 0; i < arr2.Length; i++)
                {
                    arr2[i] = float.Parse(arr[2 + i]);
                }
                for(int i = 0; i < len; i++)
                {
                    g.DrawRectangle(pen, arr2[i * 4], arr2[i * 4 + 1], arr2[i * 4 + 2] - arr2[i * 4], arr2[i * 4 + 3] - arr2[i * 4 + 1]);
                }
                bitmap.Save(Path.Combine(path + "\\imageOUT\\" + arr[0]), System.Drawing.Imaging.ImageFormat.Png);
                Console.WriteLine($"在 ./{arr[0]} 圖檔中加框，以相同名稱存入 imageOUT 中");
            }
            Console.WriteLine("圖框繪製結束!");
            Console.ReadKey();
        }
    }
}
