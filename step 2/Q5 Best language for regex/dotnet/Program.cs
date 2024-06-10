using System.Diagnostics;
using System.Text.RegularExpressions;

public class RegexSpeedTest {
    public static void Main(String[] args) {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        String content = null;
        try {
            content = File.ReadAllText("../emails.txt");
        } catch (IOException e) {
            Console.WriteLine($"{e.Message}\n{e.StackTrace}");
        }

        String pattern = "[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}";
        MatchCollection matches = Regex.Matches(content, pattern);

        
        int numMatches = matches.Count();
        sw.Stop();
        

        Console.WriteLine("Found " + numMatches + " email addresses");
        Console.WriteLine("Elapsed time: " + sw.ElapsedMilliseconds / 1000.0 + " seconds");
    }
}
