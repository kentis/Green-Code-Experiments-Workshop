import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

public class DateParsingBenchmark {
    private static final String DATE_PATTERN = "yyyy-MM-dd";
    private static final DateTimeFormatter FORMATTER = DateTimeFormatter.ofPattern(DATE_PATTERN);
    private static final SimpleDateFormat SIMPLE_DATE_FORMAT = new SimpleDateFormat(DATE_PATTERN);

    private static LocalDate parseWithLocalDate(String dateString) {
        return LocalDate.parse(dateString, FORMATTER);
    }

    private static LocalDateTime parseWithLocalDateTime(String dateString) {
        return LocalDateTime.parse(dateString + "T00:00:00", DateTimeFormatter.ISO_LOCAL_DATE_TIME);
    }

    private static java.util.Date parseWithSimpleDateFormat(String dateString) throws ParseException {
        return SIMPLE_DATE_FORMAT.parse(dateString);
    }

    public static void main(String[] args) throws Exception {
        List<String> dateStrings = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            dateStrings.add(String.format("%04d-%02d-%02d", 2000 + i % 50, 1 + i % 12, 1 + i % 28));
        }

        long startTime, elapsedTime;

        // Benchmark parseWithLocalDate
        startTime = System.nanoTime();
        for (String dateString : dateStrings) {
            parseWithLocalDate(dateString);
        }
        elapsedTime = System.nanoTime() - startTime;
        System.out.println("Time taken by parseWithLocalDate: " + elapsedTime / 1_000_000.0 + " ms");

        // Benchmark parseWithLocalDateTime
        startTime = System.nanoTime();
        for (String dateString : dateStrings) {
            parseWithLocalDateTime(dateString);
        }
        elapsedTime = System.nanoTime() - startTime;
        System.out.println("Time taken by parseWithLocalDateTime: " + elapsedTime / 1_000_000.0 + " ms");

        // Benchmark parseWithSimpleDateFormat
        startTime = System.nanoTime();
        for (String dateString : dateStrings) {
                parseWithSimpleDateFormat(dateString);
        }
        elapsedTime = System.nanoTime() - startTime;
        System.out.println("Time taken by parseWithSimpleDateFormat: " + elapsedTime / 1_000_000.0 + " ms");
    }
}
