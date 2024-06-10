using System;
using System.Diagnostics;
using System.Globalization;

class DateParsingBenchmark
{
    static void Main()
    {
        string[] dateStrings = { "2024-06-03", "03/06/2024", "2024-06-03T14:45:00+02:00" };

        string[] formats = { "yyyy-MM-dd", "dd/MM/yyyy", "yyyy-MM-ddTHH:mm:sszzz" };

        int iterations = 1000000;
        MeasureSpeed("WARMUP", dateStrings, formats, iterations, (dateString, format) => {
            DateTime.Parse(dateString);
            DateTime date;
            DateTime.TryParse(dateString, out date);
            DateTimeOffset.Parse(dateString);

            DateTime.ParseExact(dateString, format, null);
            DateTime dateExact;
            DateTime.TryParseExact(dateString, format, null, DateTimeStyles.None, out dateExact);

            DateTimeOffset dateTimeOffset;
            DateTimeOffset.TryParse(dateString, out dateTimeOffset);
            return null;    
        });

        MeasureSpeed("DateTime.Parse", dateStrings, formats, iterations, (dateString, format) => 
            DateTime.Parse(dateString));
        MeasureSpeed("DateTime.TryParse", dateStrings, formats, iterations, (dateString, format) => {
            DateTime date;
            DateTime.TryParse(dateString, out date);
            return date;
        });
        
        MeasureSpeed("DateTime.ParseExact", dateStrings, formats, iterations, (dateString, format) => 
            DateTime.ParseExact(dateString, format, null));
        MeasureSpeed("DateTime.TryParseExact", dateStrings, formats, iterations, (dateString, format) => {
            DateTime date;
            DateTime.TryParseExact(dateString, format, null, DateTimeStyles.None, out date);
            return date;
        });

        MeasureSpeed("DateTimeOffset.Parse", dateStrings, formats, iterations, (dateString, format) => 
            DateTimeOffset.Parse(dateString));
        MeasureSpeed("DateTimeOffset.TryParse", dateStrings, formats, iterations, (dateString, format) => {
            DateTimeOffset date;
            DateTimeOffset.TryParse(dateString, out date);
            return date;
        });
    }

    static void MeasureSpeed(string methodName, string[] dateStrings, string[] formats, int iterations, Func<string, string, object> parseFunction)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < iterations; i++)
        {
            for(int j = 0; j<dateStrings.Length; j++) //string dateString in dateStrings)
            {
                string dateString = dateStrings[j];
                string format = formats[j];
                try
                {
                    parseFunction(dateString, format);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{methodName} parseError on {dateString}: {ex.Message}");
                }
            }
        }

        stopwatch.Stop();
        Console.WriteLine($"{methodName}: {stopwatch.ElapsedMilliseconds} ms for {iterations} iterations");
    }
}


