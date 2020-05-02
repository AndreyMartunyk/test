using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using (Tester tester = new Tester())
            {

                long[] res = tester.MakeSpeedTest(15, DoEasyWork);
                long sum = 0;
                for (int i = 0; i < res.Length; i++)
                {
                    sum += res[i];
                    Console.WriteLine("test number {0}: {1}", i + 1, res[i]);
                }
                Console.WriteLine("average work: " + sum / res.Length);
                Console.WriteLine();
            }

            using (Tester tester = new Tester())
            {
                long[] res = tester.MakeSpeedTestAsync(15, DoEasyWork).Result;
                long sum = 0;
                for (int i = 0; i < res.Length; i++)
                {
                    sum += res[i];
                    Console.WriteLine("async test number {0}: {1}", i + 1, res[i]);
                }
                Console.WriteLine("average work async: " + sum / res.Length);
                Console.WriteLine();
            }

            using (Tester tester = new Tester())
            {
                long[] res = tester.MakeSpeedTest(5, DoHardWork);
                long sum = 0;
                for (int i = 0; i < res.Length; i++)
                {
                    sum += res[i];
                    Console.WriteLine("test number {0}: {1}", i + 1, res[i]);
                }
                Console.WriteLine("average hard work: " + sum / res.Length);
                Console.WriteLine();
            }

            using (Tester tester = new Tester())
            {
                long[] res = tester.MakeSpeedTestAsync(5, DoHardWork).Result;
                long sum = 0;
                for (int i = 0; i < res.Length; i++)
                {
                    sum += res[i];
                    Console.WriteLine("async test number {0}: {1}", i + 1, res[i]);
                }
                Console.WriteLine("average hard work async: " + sum / res.Length);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
        static void DoEasyWork()
        {
            for (int i = 0; i < 100000000; i++)
            {
            }
        }

        static void DoHardWork()
        {
            long res = 0;
            for (int i = 0; i < 100000000; i++)
            {
                res *= i;
            }
        }

        #region just tests
        static async Task<string> ReadLineAsync()
        {
            var res = await Task.Run(() => ReadLine());
            return res;
        }

        static string ReadLine()
        {
            return Console.ReadLine();
        }

        //static async Task<bool> SaveFileAsync(string path)
        //{
        //    var result = await Task.Run(() => SaveFile(path));
        //    return result;
        //}

        //static bool SaveFile(string path = "d:\\test.txt")
        //{
        //    lock (locker) 
        //    {
        //        var rnd = new Random();
        //        var text = "";
        //        for (int i = 0; i < 40000; i++)
        //        {
        //            text += rnd.Next();
        //        }
        //    } 

        //    using(var sw = new StreamWriter(path, false, Encoding.UTF8))
        //    {
        //        sw.WriteLine();
        //    }

        //    return true;
        //}

        static async Task DoWorkAsync()
        {
            await Task.Run(() => DoEasyWork());
            Console.WriteLine("DoWorkAsynk");
        }

        static async Task DoWorkAsync(int max)
        {
            await Task.Run(() => DoWork(max));
            Console.WriteLine("End DoWorkAsynk");
        }

        static void DoWork(object max)
        {
            for (int i = 0; i < (int)max; i++)
            {
                Console.WriteLine("DoWork");
            }
        }
        #endregion

        

        
    }
}
