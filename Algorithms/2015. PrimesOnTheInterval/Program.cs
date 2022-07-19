using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015.PrimesOnTheInterval
{
    public class Program
    {
        public static async Task Main()
        {
            int number = await ReadCharacters();
            var primeNumbers = PrimesOnTheInterval(number);
            await WriteCharacters(primeNumbers);
        }

        public static async Task<int> ReadCharacters()
        {
            int number = 0;
            string inputFileName = "input.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(path, inputFileName);

            try
            {
                using (StreamReader reader = File.OpenText(inputPath))
                {
                    string result = await reader.ReadToEndAsync();

                    if ((!int.TryParse(result, out number)) || number < 1 || number > 10000)
                    {
                        throw new Exception("Wrong data");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return number;
        }

        public static async Task WriteCharacters(List<int> primeNumbers)
        {
            string outputFileName = "output.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string outputPath = Path.Combine(path, outputFileName);

            try
            {
                using (StreamWriter writer = File.CreateText(outputPath))
                {
                    foreach (var item in primeNumbers)
                    {
                        await writer.WriteLineAsync(item.ToString());
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<int> PrimesOnTheInterval(int number)
        {
            List<int> primeNumbers = new List<int>();

            for (int i = 2; i < number; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }

            return primeNumbers;
        }

        public static bool IsPrime(int number)
        {
            int upper = (int)Math.Sqrt(number);

            for (int i = 2; i <= upper; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
