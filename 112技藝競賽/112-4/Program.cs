using System.Drawing;

namespace _112_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine() + "");
            string rd = "WNES";
            int[] arr = (Console.ReadLine() + "").Split(' ').Select(int.Parse).ToArray();
            while (n-- > 0)
            {
                string[] s = (Console.ReadLine() + "").Split(' ');
                Point point = new Point(int.Parse(s[0]), int.Parse(s[1]));
                string dire = s[2];
                string line = Console.ReadLine() + "";
                string isdestroyed = "";
                foreach (char item in line)
                {
                    if (isdestroyed == "Destroyed") break;
                    int index = rd.IndexOf(dire);
                    switch (item)
                    {
                        case 'L':
                            dire = rd[(index - 1 == -1 ? 3 : index - 1)] + "";
                            break;
                        case 'R':
                            dire = rd[(index + 1) % 4] + "";
                            break;
                        case 'F':
                            switch(index)
                            {
                                case 0://向西
                                    point.X -= 1;
                                    break;
                                case 1://向北
                                    point.Y += 1;
                                    break;
                                case 2://向東
                                    point.X += 1;
                                    break;
                                case 3://向南
                                    point.Y -= 1;
                                    break;
                            }
                            if (point.X >= arr[0] || point.Y >= arr[1])
                            {
                                isdestroyed = "Destroyed";
                            }
                            break;
                    }
                }
                Console.WriteLine($"{point.X} {point.Y} {dire} {isdestroyed}");
            }
        }
    }
}
