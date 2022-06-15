using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2005.FirstMinIndex
{
    public class Program
    {
        public static int EnterNumber(int rangeFrom, int rangeTo)
        {
            int number = 0;
            bool tryParse = false;

            do
            {
                Console.Write("Enter a number (" + rangeFrom + "-" + rangeTo + "): ");
                tryParse = int.TryParse(Console.ReadLine(), out number);
            }
            while (!(tryParse && !(number < rangeFrom || number > rangeTo)));

            return number;
        }
        public static int[] EnterArray(int count)
        {
            const int numberRangeFrom = -10000;
            const int numberRangeTo = 10000;
            int[] array = new int[count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = EnterNumber(numberRangeFrom, numberRangeTo);
            }

            return array;
        }

        public static int FirstMinIndex(int[] array)
        {
            int indexOfMin = 0;

            if(array.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < array[indexOfMin])
                {
                    indexOfMin = i;
                }
            }

            return indexOfMin + 1;
        }

        public static void Main(string[] args)
        {
            int count = 0;
            const int countRangeFrom = 1;
            const int countRangeTo = 10000;

            Console.WriteLine("The first minimum index");
            Console.WriteLine("Enter count");

            count = EnterNumber(countRangeFrom, countRangeTo);
            Console.WriteLine();

            Console.WriteLine("Result: " + FirstMinIndex(EnterArray(count)));

        }
    }
}
