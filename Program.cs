﻿using System;
using System.Linq;

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

            var numbersLessThanThousand = list.Where( i => i <= 1000).ToArray();

            var negativeNumbers = numbersLessThanThousand.Where(i =>  i < 0).ToArray();

            if(negativeNumbers.Length > 0)
            {
                var res = String.Join("," , negativeNumbers);
                throw new NotSupportedException(String.Format("Negative numbers ({0}) not allowed.", res));
            }

            long result = 0;

            switch (operationType)
            {
                case "add":
                    result = Add(numbersLessThanThousand);
                    Console.WriteLine(result);
                    break;

                case "multiply":
                    result = Multiply(numbersLessThanThousand);
                    Console.WriteLine(result);
                    break;

                default:
                    Console.WriteLine(String.Format("Operation type {0} not supported", operationType));
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

        static long Multiply(params int[] list)
        {
            if (list.Length <= 0)
                return 0;

            long result = 1;
            for (int i = 0; i < list.Length; i++)
            {
                result = result * list[i];
            }

            return result;

        }
    }
}
