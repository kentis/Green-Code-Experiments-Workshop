using System;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Text;

class DateParsingBenchmark
{
    static void Main()
    {
        
        Console.WriteLine("Two strings\n");
        addTwoStrings();

        Console.WriteLine("\n100 Strings\n");
        addManyStrings(100);

        Console.WriteLine("\n50 Strings\n");
        addManyStrings(50);

        Console.WriteLine("\n25 Strings\n");
        addManyStrings(25);
        
        Console.WriteLine("\n12 Strings\n");
        addManyStrings(12);
        
        Console.WriteLine("\n6 Strings\n");
        addManyStrings(6);
        
        Console.WriteLine("\n3 Strings\n");
        addManyStrings(3);

    }

    static void  addTwoStrings(){
        string first = "Hello ";

        //string exactFormat = "dd/MM/yyyy";
        string second = "NDC";

        int iterations = 1_000_000;
        MeasureSpeed("WARMUP", first, second, iterations, (firstString, secondString) => {
            var a = firstString + secondString;
            var b = $"{firstString}{secondString}";
            var c = new StringBuilder().Append(firstString).Append(secondString).ToString();
            string[] array = {firstString,secondString};
            var d = string.Join("",array);
            // add each concatination method here
            return a+b+c+d; 
        });

        MeasureSpeed("Add (+) string concationation", first, second, iterations, (firstString, secondString) => {return firstString + secondString;});
        
        MeasureSpeed("Template strings", first, second, iterations, (firstString, secondString) => $"{firstString}{secondString}");
        
        MeasureSpeed("Stringbuilder", first, second, iterations, (firstString, secondString) => new StringBuilder().Append(firstString).Append(secondString).ToString());

        MeasureSpeed("string.Join", first, second, iterations, (firstString, secondString) => {
            string[] array = {firstString,secondString};
            return string.Join("",array);
        });

       
    }

    static void  addManyStrings(int numappends){
        string first = "Hello ";

        //string exactFormat = "dd/MM/yyyy";
        string second = "NDC";

        int iterations = 1_000_000;
        MeasureSpeed("WARMUP", first, second, iterations, (firstString, secondString) => {
            var a = firstString + secondString;
            var b = $"{firstString}{secondString}";
            var c = new StringBuilder().Append(firstString).Append(secondString).ToString();
            string[] array = {firstString,secondString};
            var d = string.Join("",array);
            // add each concatination method here
            return a+b+c+d; 
        });

        MeasureSpeed("Add (+) string concationation", first+"", second+"", iterations, (firstString, secondString) => {
            for(int i = 0; i<numappends;i++){
                firstString += secondString;
            }
            return firstString;
        });
        
        MeasureSpeed("Template strings", first+"", second+"", iterations, (firstString, secondString) => {
            for(int i = 0; i<numappends;i++){
                firstString = $"{firstString}{secondString}";
            }
            return firstString;
        });
        
        MeasureSpeed("Stringbuilder", first+"", second+"", iterations, (firstString, secondString) => {
            var sb = new StringBuilder(firstString);
            for(int i = 0; i<numappends;i++){
                sb.Append(secondString);
            }
            return sb.ToString();
        });

        MeasureSpeed("string.Join", first+"", second+"", iterations, (firstString, secondString) => {
            string[] array = new string[numappends+1];
            array[0] = firstString;
            for(int i = 1; i<numappends;i++){
                array[i] = secondString;
            }
            return string.Join("",array);
        });

       
    }

    static void MeasureSpeed(string methodName, string first, string second, int iterations, Func<string, string, string> concatStringsFunction)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < iterations; i++)
        {
            concatStringsFunction(first, second);
        }

        stopwatch.Stop();
        Console.WriteLine($"{methodName}: {stopwatch.ElapsedMilliseconds} ms for {iterations} iterations");
    }
}


