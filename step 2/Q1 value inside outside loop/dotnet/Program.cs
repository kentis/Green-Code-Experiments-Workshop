// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


public class Program {
    Stopwatch sw = new Stopwatch();
    public long inside(){
        // Initialize variable inside the loop
        sw.Start();
        var y=0;
        for(var i = 0; i < 10_000_000; i++){
            int z = 1 + 1;
            y = y + z;
        }
        sw.Stop();
        
        return sw.ElapsedMilliseconds;
    }

    public long outside() {
        // Initialize variable outside the loop
        sw.Start();
        var y = 0;
        int z = 1 + 1;
        for(var i = 0; i < 10_000_000; i++){
            y = y + z;
        }
        sw.Stop();
        
        return sw.ElapsedMilliseconds;
    }

    public static void Main(){
        const int numIterations = 50;
        var program =  new Program();
        var insideResults = new List<long>(numIterations);
        var outsideResults = new List<long>(numIterations);
        //warmup
       program.inside();

       for(int i = 0; i < numIterations; i++){
         program.sw.Reset();
         insideResults.Add(program.inside());
       }

       Console.WriteLine($"Mean Time taken inside loop: {insideResults.Sum()/(numIterations+0.0)}ms");

        program.outside();
       for(int i = 0; i < numIterations; i++){
         program.sw.Reset();
         outsideResults.Add(program.outside());
       }

        Console.WriteLine($"Mean Time taken outside loop: {outsideResults.Sum()/(numIterations+0.0)}ms");


    }
}








