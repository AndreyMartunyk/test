using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace test
{
    class Tester: IDisposable
    {
        Stopwatch sw;
        public delegate void Callback();
        
        public Tester()
        {
            sw = new Stopwatch();
        }

        public long[] MakeSpeedTest(int countTests = 1, params Callback[] callback)
        {
            long[] res = new long[callback.Length * countTests];

            for (int y = 0; y < countTests; y++)
            {
                if (countTests < 1)
                {
                    return null;
                }
                for (int i = 0; i < callback.Length; i++)
                {
                    sw.Start();
                    callback[i]();
                    sw.Stop();
                    res[i + y] = sw.ElapsedTicks;
                    sw.Reset();
                }
            }
            
            return  res;
        }

        public async Task<long[]> MakeSpeedTestAsync(int countTests = 1, params Callback[] callback)
        {
            var result = await Task.Run(() => MakeSpeedTest(countTests, callback));
            return result;
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed Tester");
        }
    }
}
