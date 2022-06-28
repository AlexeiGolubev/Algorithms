using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2001.A_B
{
    public class Program
    {
        public static int[] ReadNumbers()
        {
            int a = 0;
            int b = 0;
            int[] numbers = { a, b };
            string inputFileName = "input.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(path, inputFileName);

            try
            {
                using (StreamReader reader = File.OpenText(inputPath))
                {
                    string[] str = reader.ReadLine().Split();
                    
                    if (str.Length != numbers.Length)
                    {
                        throw new Exception("Wrong amount of data");
                    }

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if(!int.TryParse(str[i], out numbers[i]))
                        {
                            throw new Exception("Wrong data");
                        }
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

            return numbers;
        }

        public static void WriteNumber(int sum)
        {
            string outputFileName = "output.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string outputPath = Path.Combine(path, outputFileName);

            try
            {
                using (StreamWriter writer = File.CreateText(outputPath))
                {
                    writer.Write(sum);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int SumOfNumbers(int a, int b)
        {
            return a + b;
        }

        public static void Main(string[] args)
        {
            var numbers = ReadNumbers();
            int sum = SumOfNumbers(numbers[0], numbers[1]);
            WriteNumber(sum);
        }
    }
}
