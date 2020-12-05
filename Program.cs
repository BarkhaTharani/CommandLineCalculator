using System;

namespace CommandLineCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0) return;

            var operationType = args[0];

            string errorMsg = @"Please provide input in the format \\[delimiter]\\numbers";

            if (args.Length > 2)
            {
                throw new ArgumentException(@"Please enter valid number of arguments.");
            }

           string nums = args.Length == 2 ? args[1] : String.Empty;
           string[] inputString = new string[0];
           string delimeterChar = String.Empty;
           string inputNumbers = String.Empty;

           if(!nums.StartsWith("\\"))
           {
                throw new FormatException(errorMsg);
           }

            inputString = nums.Split("\\");

            if(inputString.Length > 3) 
            {
                throw new FormatException(errorMsg);
            }

            delimeterChar = inputString[1].Trim();
            inputNumbers = inputString[2] ;
           

            string[] strings = !String.IsNullOrEmpty(inputNumbers) ? inputNumbers.Split(delimeterChar, StringSplitOptions.None ) : new string[0];
            
            int[] list = Array.ConvertAll(strings, s => int.Parse(s));
            long result = 0;

            switch (operationType)
            {
                case "add":
                    result = Add(list);
                    Console.WriteLine(result);
                    break;

                default:
                    break;
            }
            
        }

        static long Add(params int[] list)
        {
            if (list.Length <= 0)
                return 0;

            long sum = 0;
            for (int i = 0; i < list.Length; i++)
            {
                sum = sum + list[i];
            }

            return sum;

        }
    }
}
