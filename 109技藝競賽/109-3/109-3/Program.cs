using System;
using System.Collections.Generic;
using System.Linq;
namespace _109_3
{
    public static class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int val = int.Parse(Console.ReadLine() + "");
                List<string> result = new List<string>();
                int[] ans = new int[val];
                for(int i = 1; i <= val; i++)
                {
                    ans[i - 1] = i;
                }
                while (true)
                {
                    List<int> col = ans.ToList();
                    List<int> list = ((Console.ReadLine() + "").Split(' ')).Select<string, int>(x => int.Parse(x)).ToList();
                    Stack<int> stack = new Stack<int>();
                    int count = 0;
                    if (list[0] == 0 && list.Count == 1) break;
                    while (true)
                    {
                        bool fg = false;
                        if (stack.Count != 0)
                        {
                            if (stack.Peek() == col[col.Count - 1])
                            {
                                stack.Pop();
                                col.RemoveAt(col.Count - 1);
                                fg= true;
                            }                      
                        }
                        if (list.Count != 0 && !fg)
                        {
                            stack.Push(list[0]);
                            list.RemoveAt(0);
                        }
                        else count++;
                        if (list.Count == 0 && stack.Count == 0)
                        {
                            result.Add("YES!");
                            break;
                        }
                        else if (count > val)
                        {
                            result.Add("NO!");
                            break;
                        }
                    }
                }
                Console.WriteLine(string.Join("\r\n", result));
            }
        }
    }
}
