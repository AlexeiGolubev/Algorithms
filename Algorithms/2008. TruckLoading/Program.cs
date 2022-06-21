using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2008.TruckLoading
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

        public static (int numberOfLoadedItems, int weight) TruckLoading(int[] items, int loadCapacity)
        {
            int numberOfLoadedItems = 0;
            int weight = 0;            

            for (int i = 0; i < items.Length; i++)
            {
                if((weight + items[i]) <= loadCapacity)
                {
                    weight += items[i];
                    numberOfLoadedItems++;
                }
            }
            return (numberOfLoadedItems, weight);
        }

        public static void Main(string[] args)
        {
            int numberOfItems = 0;
            int loadCapacity = 0;

            Console.WriteLine("Truck loading");
            Console.WriteLine("Enter count items");
            numberOfItems = EnterNumber();
            Console.WriteLine("Enter load capacity");
            loadCapacity = EnterNumber();
            Console.WriteLine();
            int[] items = EnterArray(numberOfItems);
            var truckLoading = TruckLoading(items, loadCapacity);
            
            Console.WriteLine("Result (number of loaded items & weight): " + truckLoading.numberOfLoadedItems + " " + truckLoading.weight);
        }
    }
}
