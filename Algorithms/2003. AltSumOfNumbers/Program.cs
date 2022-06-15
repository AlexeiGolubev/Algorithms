using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2003.AltSumOfNumbers
{
    public class Program
    {
        public static int EnterNumber()
        {
            int number = 0;

            do
            {
                Console.Write("Enter a number (1-10000): ");
                int.TryParse(Console.ReadLine(), out number);
            }
            while (number < 1 || number > 10000);

            return number;
        }

        public static int SumOfNumbers(int count)
        {
            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0)
                {
                    sum += EnterNumber();
                }
                else
                {
                    sum -= EnterNumber();
                }
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            int count = 0;

            Console.WriteLine("Alt sum of numbers");
            Console.WriteLine("Enter count");

            count = EnterNumber();
            Console.WriteLine();

            Console.WriteLine("Result: " + SumOfNumbers(count));
        }
    }
}
