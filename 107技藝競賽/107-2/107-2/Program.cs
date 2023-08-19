// See https://aka.ms/new-console-template for more information
using System.Text;
namespace _107_2
{
    static class Program
    {
        public static List<List<double>> nums = new List<List<double>>() { new List<double>(), new List<double>(), new List<double>() };
        static void Main()
        {
            string path = Console.ReadLine() + "";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StreamReader din = new StreamReader(path, CodePagesEncodingProvider.Instance.GetEncoding("big5"));            
            for(int i = 0; i < 3; i++)
            {
                din.ReadLine();
                List<string> col = din.ReadLine().Split(' ').ToList();
                col.RemoveAt(0);
                nums[i] = col.Select(x => double.Parse(x)).ToList();
            }
            List<double> pdm = new List<double>();
            List<double> mdm = new List<double>();
            for(int i = 1; i < nums[0].Count; i++)
            {
                pdm.Add(nums[0][i] - nums[0][i - 1]);
                mdm.Add(nums[2][i - 1] - nums[2][i]);
                if (pdm[i - 1] > mdm[i - 1])
                {
                    mdm[i - 1] = 0;
                }
                else if (pdm[i - 1] < mdm[i - 1])
                {
                    pdm[i - 1] = 0;
                }
                else
                {
                    mdm[i - 1] = 0;
                    pdm[i - 1] = 0;
                }
            }
            List<double> tr = new List<double>();
            for(int i = 1; i < nums[0].Count; i++)
            {
                double tr1 = (Math.Abs(nums[0][i] - nums[2][i]));
                double tr2 = (Math.Abs(nums[0][i] - nums[1][i - 1]));
                double tr3 = (Math.Abs(nums[2][i] - nums[1][i - 1]));
                if (tr1 > tr2 && tr1 > tr3)
                {
                    tr.Add(tr1);
                }
                else if (tr2 > tr1 && tr2 > tr3)
                {
                    tr.Add(tr2);
                }
                else
                {
                    tr.Add(tr3);
                }
            }
            double pdms = 0;
            double mdms = 0;
            double trs = 0;
            List<double> pdi = new List<double>();
            List<double> mdi = new List<double>();
            for(int i = 0; i < pdm.Count; i++)
            {
                pdms += pdm[i];
                mdms += mdm[i];
                trs += tr[i];
                if (i >= 9)
                {
                    pdi.Add(pdms / trs);
                    mdi.Add(mdms / trs);
                    pdms -= pdm[i - 9];
                    mdms -= mdm[i - 9];
                    trs -= tr[i - 9];
                }
            }
            List<double> dx = new List<double>();
            for(int i = 0; i < pdi.Count; i++)
            {
                dx.Add(100 * Math.Abs(pdi[i] - mdi[i]) / (pdi[i] + mdi[i]));
            }
            List<string> adx = new List<string>();
            double adxs = 0;
            for(int i = 0; i < dx.Count; i++)
            {
                adxs += dx[i];
                if (i >= 9)
                {
                    adx.Add(string.Format("{0:0.##}", adxs / 10));
                    adxs -= dx[i - 9];
                }
            }
            List<string> ans = new List<string>();
            for(int i = 1; i < adx.Count; i++)
            {
                if (double.Parse(adx[i]) >= double.Parse(adx[i - 1]))
                {
                    ans.Add("1");
                }
                else
                {
                    ans.Add("0");
                }
                for(int j = 1; j < adx[i].Length; j++)
                {
                    ans[i - 1] = " " + ans[i - 1];
                }
            }
            adx.RemoveAt(0);
            Console.WriteLine("ADX: " + string.Join(" ", adx));
            Console.WriteLine("預測:" + string.Join(" ", ans));
            Console.ReadKey();
        }
    }
}
