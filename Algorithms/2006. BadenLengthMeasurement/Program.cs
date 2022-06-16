using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2006.BadenLengthMeasurement
{
    public class Program
    {
        public static int EnterLength()
        {
            int length = 0;

            do
            {
                Console.Write("Enter a length in cm (1-10000): ");
                int.TryParse(Console.ReadLine(), out length);
            }
            while (length < 1 || length > 10000);

            return length;
        }

        public static int ConvertCmToInches(int length)
        {
            if(length < 1)
            {
                return 0;
            }

            int inch = length / 3;

            if(length % 3 == 2)
            {
                inch++;
            }

            return inch;
        }

        public static int ConvertInchesToFeet(ref int inch)
        {
            if (inch < 1)
            {
                return 0;
            }

            int foot = inch / 12;
            inch = inch % 12;

            return foot;
        }

        public static void Main(string[] args)
        {
            int length = 0;
            int inch = 0;
            int foot = 0;

            Console.WriteLine("Length measurement in Baden (1 foot = 12 inch, 1 inch = 3 cm)");

            length = EnterLength();
            inch = ConvertCmToInches(length);
            foot = ConvertInchesToFeet(ref inch);

            Console.WriteLine("Result (feet, inches): " + foot + " " + inch);
        }
    }
}
