using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2010.Euclid_sАlgorithm
{
    public class Program
    {
        public static (int firstNumber, int secondNumber) ReadNumbers()
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
                    var line = reader.ReadToEnd().Split(' ');

                    if (line.Length != numbers.Length)
                    {
                        throw new Exception("Wrong amount of data");
                    }

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (!int.TryParse(line[i], out numbers[i]))
                        {
                            throw new Exception("Wrong data");
                        }

                        if (numbers[i] < 0 || numbers[i] > Math.Pow(10, 7))
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

            return (numbers[0], numbers[1]);
        }

        public static void WriteNumber(int amountNumbers, int lcm)
        {
            string outputFileName = "output.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string outputPath = Path.Combine(path, outputFileName);

            try
            {
                using (StreamWriter writer = File.CreateText(outputPath))
                {
                    writer.Write(amountNumbers + " " + lcm);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static (int amountNumbers, int lcm) LeastCommonMultiple(int firstNumber, int secondNumber)
        {
            int amountNumbers = 0;
            int lcm = 0;
            int temp = 0;

            if (firstNumber == 0 || secondNumber == 0)
            {
                return (amountNumbers, lcm);
            }

            if (firstNumber == 1 || secondNumber == 1)
            {
                if (firstNumber > secondNumber)
                {
                    amountNumbers = firstNumber;
                    lcm = secondNumber;
                }
                else
                {
                    amountNumbers = secondNumber;
                    lcm = firstNumber;
                }

                return (amountNumbers, lcm);
            }

            while(secondNumber != 0)
            {
                if (firstNumber < secondNumber)
                {
                    temp = secondNumber;
                    secondNumber = firstNumber;
                    firstNumber = temp;
                }

                lcm = secondNumber;
                temp = secondNumber;
                secondNumber = firstNumber - secondNumber;
                firstNumber = temp;
                amountNumbers++;                
            }

            return (amountNumbers, lcm);
        }

        public static void Main(string[] args)
        {
            var numbers = ReadNumbers();
            var result = LeastCommonMultiple(numbers.firstNumber, numbers.secondNumber);
            WriteNumber(result.amountNumbers, result.lcm);
        }
    }
}
