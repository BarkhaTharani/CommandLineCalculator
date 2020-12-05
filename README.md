# CommandLineCalculator

This is a simple command line utility calculator. It supports add and multiple functionality for calculations.

Target Framework for this project is  .net core 3.1.

It accepts input arguments from command line in the format -

```
dotnet run <operationType> "\\<delimeter>\\numbers"
```
For example:

```
dotnet run add "\\,\\1,2,3"

dotnet run add "\\;\\1;2;3;4"

dotnet run multiple "\\;\\1;2;3;4"
```

**Note: Please provide arguements after the provided operation type in double quotes to escape the characters from terminal.
Otherwise application may not behave as expected.
(like in above example: ```dotnet run add "\\,\\1,2,3"```)

