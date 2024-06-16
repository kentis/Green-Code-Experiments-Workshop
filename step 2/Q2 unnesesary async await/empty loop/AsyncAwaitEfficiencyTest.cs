using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwaitEfficiencyTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const int iterationCount = 10_000_000;

            // Warmup
            await UnnecessaryAsyncAwait();
            NoAsyncAwait();
            var stopwatch = Stopwatch.StartNew();

// Test without unnecessary async/await
            var count2 = 0;
            
            for (int i = 0; i < iterationCount; i++)
            {
                count2 += NoAsyncAwait();
            }
            stopwatch.Stop();
            Console.WriteLine($"No async/await: {stopwatch.ElapsedMilliseconds} ms");
	        
            
            // Test unnecessary async/await usage
	        var count1 = 0;
            stopwatch.Restart();
            for (int i = 0; i < iterationCount; i++)
            {
                count1 += await UnnecessaryAsyncAwait();
            }
            stopwatch.Stop();
            Console.WriteLine($"Unnecessary async/await: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"count1: {count1} count2: {count2}");
	        
        }

        static async Task<int> UnnecessaryAsyncAwait()
        {
            return await Task.FromResult(1); // Unnecessary async/await usage
        }

        static int NoAsyncAwait()
        {
            return 1;
        }
    }
}

