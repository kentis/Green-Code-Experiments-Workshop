# Running the experiments

Run your experiment and record the results. In the following I have recorded the results of running each of the example experiments below. All experiments here have been run on a 2016 Macbook Pro laptop with 2.7 GHz four-cores Intel Core I7 CPU and 16GB 2133MHz RAM.


## Q1: Value inside outside loop

The table below shows the results of running the provided software ```python3 run_both_using_timer.py``` 5 five times with the inside loop block first (Original 1-5) and 5 times with the inside loop block last (Reverse 1-5). We can see that the results seem reasonably consistent and can thus conclude that the experiment supports the hypothesis that, in Python, it is in deed faster to initiate
values outside loops rather than inside.

|Order / run # |Initiation inside loop     | Initiation outside loop | Diff|
|--------------|---------------------------|---------------------------|--------|
|Original 1    | 1,53                      | 1,27                      |   0,25 |
|Original 2    | 1,47                      | 1,25                      |   0,23 |
|Original 3    | 1,43                      | 1,21                      |   0,22 |
|Original 4    | 1,59                      | 1,28                      |   0,31 |
|Original 5    | 1,64                      | 1,34                      |   0,30 |
|--------------|---------------------------|---------------------------|--------|
|Reverse 1     | 1,59                      | 1,25                      |   0,34 |
|Reverse 2     | 1,48                      | 1,22                      |   0,26 |
|Reverse 3     | 1,55                      | 1,30                      |   0,25 |
|Reverse 4     | 1,44                      | 1,24                      |   0,20 |
|Reverse 5     | 1,54                      | 1,30                      |   0,24 |

Suggested bonus work: redo the experiment using Java.


## Q2: Unnecessary async/await

In this experiment we create two separate experiments to explore the cost of async/await in isolation and in a somewhat
more realistic scenario when reading a file.

The code for the first experiment, using async/await in a trivial case, is found in the ```empty loop```folder. The table below shows the results of running the experiment 5 times with the loop using async/await first (Original 1-5) and 5 times with the non-async loop first (Reverse 1-5). To run the experiment for yourself install the dotnet SDK and run ```dotnet run``` in the codes folder.

|Order / run # |With async (ms)     | Without async (ms) | Diff|
|--------------|---------------------------|---------------------------|--------|
|Original 1|736|63|673|
|Original 2|716|61|655|
|Original 3|762|61|701|
|Original 4|715|61|654|
|Original 5|747|61|686|
|--------------|---------------------------|---------------------------|--------|
|Reverse 1|827|65|762|
|Reverse 2|723|61|662|
|Reverse 3|721|61|660|
|Reverse 4|725|61|664|
|Reverse 5|734|63|671|


The code for the second experiment, using async/await to read a file consisting of the numbers 1-1000000 one one line each, parse numbers and add them together, is found tin e the ```read file```folder.  The table below shows the results of running the experiment 5 times with the loop using async/await first (Original 1-5) and 5 times with the non-async loop first (Reverse 1-5). To run the experiment for yourself install the dotnet SDK and run ```dotnet run``` in the codes folder.


|Order / run # |With async (ms)     | Without async (ms) | Diff|
|--------------|---------------------------|---------------------------|--------|
|Original 1|212|91|121|
|Original 2|180|73|107|
|Original 3|208|91|117|
|Original 4|209|96|113|
|Original 5|208|95|113|
|--------------|---------------------------|---------------------------|--------|
|Reverse 1|204|111|93|
|Reverse 2|203|117|86|
|Reverse 3|194|104|90|
|Reverse 4|193|105|88|
|Reverse 5|193|106|87|

Bonus exercise left for the participant: Try removing the warmup rounds and/or use a shorter file and re-run the experiment with both orders.

## Q3: Parsing dates (Java)

In this experiment we have a Java CLI program that is compiled using the command ```javac DateParsingBenchmark.java``` and run using ```java DateParsingBenchmark```. The table below show the running times of parsing 10 000 dates with each of the date parsers:
* java.time.LocalDate
* java.time.LocalDateTime
* java.text.SimpleDateFormat

|Run #|LocalDate (ms)|LocalDateTime (ms)|SimpleDateFormat (ms)|
|-----|--------------|------------------|---------------------|
|1|61,57|67,95|97,38|
|2|57,23|63,95|92,04|
|3|51,85|65,62|89,60|
|4|54,94|64,24|89,38|
|5|50,81|65,91|95,61|

