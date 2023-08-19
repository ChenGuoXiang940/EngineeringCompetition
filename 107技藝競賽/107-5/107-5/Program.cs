using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _107_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ReadLine();
                int[] nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                int n = nums.Length;
                int maxSum = nums[0];
                int currentSum = nums[0];
                int start = 0;     //起點索引
                int end = 0;       //終點索引
                int tempStart = 0; //臨時起點索引
                for (int i = 1; i < n; i++)
                {
                    if (nums[i] > currentSum + nums[i])
                    {
                        currentSum = nums[i];
                        tempStart = i;
                    }
                    else
                    {
                        currentSum += nums[i];
                    }
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        start = tempStart;
                        end = i;
                    }
                }
                Console.WriteLine($"{maxSum}\r\n{start} {end}");
            }
        }
    }
}
