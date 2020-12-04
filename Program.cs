﻿using System;

namespace CommandLineCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0) return;

            var operationType = args[0];

            if (args.Length > 2)
            {
                Console.WriteLine("Please enter valid number of arguments separated by ','");
                return;
            }

           string nums = args.Length == 2 ? args[1] : String.Empty;

            string[] splitChar = {"," , "\\n"};

            string[] strings = !String.IsNullOrEmpty(nums) ? nums.Split(splitChar, StringSplitOptions.None ) : new string[0];
            
            int[] list = Array.ConvertAll(strings, s => int.Parse(s));
            long result = 0;

            switch (operationType)
            {
                case "sum":
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
