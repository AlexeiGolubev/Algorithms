using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2009.SumOnPowersOfTwos
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

        public static int[] EnterArray(int count)
        {
            int[] array = new int[count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = EnterNumber();
            }

            return array;
        }

        public static int SumOnPowersOfTwos(int[] numbers)
        {
            int sum = 0;

            for (int i = 0, pow = 0; i < numbers.Length; i++)
            {
                if((i + 1) == Math.Pow(2, pow))
                {
                    sum += numbers[i];
                    pow++;
                }
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            int number = 0;

            Console.WriteLine("Sum on powers of twos");

            number = EnterNumber();
            Console.WriteLine();
            int[] numbers = EnterArray(number);

            Console.WriteLine("Result: " + SumOnPowersOfTwos(numbers));
        }
    }
}
