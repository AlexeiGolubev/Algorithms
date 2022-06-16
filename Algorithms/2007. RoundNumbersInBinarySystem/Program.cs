using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2007.RoundNumbersInBinarySystem
{
    public class Program
    {
        public static int EnterNumber()
        {
            int number = 0;
            int rangeTo = (int) Math.Pow(10, 9);

            do
            {
                Console.Write("Enter a number (1-10^9): ");
                int.TryParse(Console.ReadLine(), out number);
            }
            while (number < 1 || number > rangeTo);

            return number;
        }

        public static int RoundnessDetermination(int number)
        {
            int round = 0;

            while(number % 2 == 0)
            {
                round++;
                number /= 2;                
            }

            return round;
        }

        public static void Main(string[] args)
        {
            int number = 0;

            Console.WriteLine("Round numbers in the binary system (the max power of two that the number is divisible by)");

            number = EnterNumber();
            Console.WriteLine();

            Console.WriteLine("Result: " + RoundnessDetermination(number));
        }
    }
}
