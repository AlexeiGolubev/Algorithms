using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2001.A_B
{
    public class Program
    {
        public static int EnterNumber()
        {
            int number = 0;

            do
            {
                Console.Write("Enter a number (1-1000): ");
                int.TryParse(Console.ReadLine(), out number);
            }
            while (number < 1 || number > 1000);

            return number;
        }

        public static int SumOfNumbers(int a, int b) => a + b;

        public static void Main(string[] args)
        {
            int a = 0;
            int b = 0;

            Console.WriteLine("A+B");

            a = EnterNumber();
            b = EnterNumber();
            Console.WriteLine("Result: " + SumOfNumbers(a, b));
        }
    }
}
