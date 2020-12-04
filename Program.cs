using System;

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

            string[] strings = !String.IsNullOrEmpty(nums) ? nums.Split(',') : new string[0];
            int[] list = Array.ConvertAll(strings, s => int.Parse(s));
            long result = 0;

            switch (operationType)
            {
                case "sum":
                    result = AddTwoNumbers(list);
                    Console.WriteLine(result);
                    break;

                default:
                    break;
            }
            
        }

        static long AddTwoNumbers(params int[] list)
        {
            if (list.Length <= 0)
                return 0;

            if (list.Length > 2)
                throw new NotSupportedException("Addition upto two numbers is supported");

            long sum = 0;
            for (int i = 0; i < list.Length; i++)
            {
                sum = sum + list[i];
            }

            return sum;

        }
    }
}
