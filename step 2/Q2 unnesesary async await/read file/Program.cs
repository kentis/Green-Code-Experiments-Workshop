using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        /// <summary>
        /// In this example, try to turn off the warmup rounds and to
        /// vary the order of the syncrounous and asyncrhouns blocks.
        /// Without warmup the order of the blocks is quite significant
        /// and with smaller file size (1..1000 instead of 1..1_000_000)
        /// it can even flip the results.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            // Assuming the file "numbers.txt" already exists
            string filePath = "numbers.txt";

            //warmup
            await ReadAndSumNumbersAsync(filePath);
            ReadAndSumNumbersSync(filePath);
            
            
            

            // Asynchronous approach (unnecessary async/await)
            var asyncStopwatch = new Stopwatch();
            asyncStopwatch.Start();
            int asyncSum = await ReadAndSumNumbersAsync(filePath);
            asyncStopwatch.Stop();
            Console.WriteLine($"Asynchronous sum: {asyncSum}");
            Console.WriteLine($"Asynchronous time: {asyncStopwatch.ElapsedMilliseconds} ms");

            // Synchronous approach
            var syncStopwatch = new Stopwatch();
            syncStopwatch.Start();
            int syncSum = ReadAndSumNumbersSync(filePath);
            syncStopwatch.Stop();
            Console.WriteLine($"Synchronous sum: {syncSum}");
            Console.WriteLine($"Synchronous time: {syncStopwatch.ElapsedMilliseconds} ms");

        }

        static int ReadAndSumNumbersSync(string filePath)
        {
            int sum = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sum += int.Parse(line);
                }
            }
            return sum;
        }

        static async Task<int> ReadAndSumNumbersAsync(string filePath)
        {
            int sum = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    sum += int.Parse(line);
                }
            }
            return sum;
        }
    }
}

