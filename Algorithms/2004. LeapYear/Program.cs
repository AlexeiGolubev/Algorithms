using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2004.LeapYear
{
    public class Program
    {
        public static int EnterYear()
        {
            int number = 0;

            do
            {
                Console.Write("Enter a wear (1000-2100): ");
                int.TryParse(Console.ReadLine(), out number);
            }
            while (number < 1000 || number > 2100);

            return number;
        }

        public static bool LeapYear(int year)
        {
            if((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Main(string[] args)
        {
            int year = 0;

            Console.WriteLine("Leap year");

            year = EnterYear();

            Console.WriteLine("Result: " + LeapYear(year));
        }
    }
}
