// RegexSpeedTest.java

import java.io.*;
import java.nio.file.*;
import java.util.regex.*;
import java.time.*;

public class RegexSpeedTest {
    public static void main(String[] args) {
        Instant start = Instant.now();

        String content = null;
        try {
            content = new String(Files.readAllBytes(Paths.get("emails.txt")));
        } catch (IOException e) {
            e.printStackTrace();
        }

        String pattern = "[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}";
        Pattern compiledPattern = Pattern.compile(pattern);
        Matcher matcher = compiledPattern.matcher(content);

        int matches = matcher.groupCount();
        while (matcher.find()) {
            matches++;
        }

        Instant end = Instant.now();
        Duration elapsed = Duration.between(start, end);

        System.out.println("Found " + matches + " email addresses");
        System.out.println("Elapsed time: " + elapsed.toMillis() / 1000.0 + " seconds");
    }
}

