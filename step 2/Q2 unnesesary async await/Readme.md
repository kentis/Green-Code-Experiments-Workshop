# Design of Q2 Unnesesary async await experiment

In order to try to determine the effect of using async/await when it is not really nessecary we will create two Dotnet CLI applications using C#. 

The first application will perform a large number of trivial calls in a loop, one with and one without async/await and record the time taken to perform the loop. We execute the program several times and vary the order of with or without async as to mitigate any effects from the order of execution.

The code for the first application is stored in the 'empty loop' folder. To run the experiment eneter the folder and run:

```
dotnet run
```

The second application will read numbers from a file, parse and sum them. This is a slightly more realistic scenario for async/await. This program is otherwise similar to the above and should also be executed several times while varying the order of the two approches (with and without async) of reading the file.

The code for the first application is stored in the 'read file' folder. To run the experiment eneter the folder and run:

```
dotnet run
```
