using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013.NumberOfLows
{
    public class Program
    {
        public static async Task Main()
        {
            var numbers = await ReadCharacters();
            int numberOfLows = NumberOfLows(numbers);
            await WriteCharacters(numberOfLows);
        }

        public static async Task<int[]> ReadCharacters()
        {
            int[] numbers = null;
            string inputFileName = "input.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(path, inputFileName);

            try
            {
                using (StreamReader reader = File.OpenText(inputPath))
                {
                    string text = await reader.ReadToEndAsync();
                    var lines = text.Split('\n');

                    if (lines.Length != 2)
                    {
                        throw new Exception("Wrong data");
                    }

                    if (!int.TryParse(lines[0], out int size) || size < 1 || size > 10000)
                    {
                        throw new Exception("Wrong data");
                    }

                    numbers = new int[size];
                    var result = lines[1].Split(' ');

                    if (result.Length != numbers.Length)
                    {
                        throw new Exception("Wrong amount of data");
                    }

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (!int.TryParse(result[i], out numbers[i]) || numbers[i] < -10000 || numbers[i] > 1000)
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

        public static async Task WriteCharacters(int numberOfLows)
        {
            string outputFileName = "output.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string outputPath = Path.Combine(path, outputFileName);

            try
            {
                using (StreamWriter writer = File.CreateText(outputPath))
                {
                    await writer.WriteAsync(numberOfLows.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int NumberOfLows(int[] numbers)
        {
            if (numbers.Length < 1)
            {
                Console.WriteLine("Does not contain numbers");
                return 0;
            }

            int min = numbers[0];
            int numberOfLows = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                    numberOfLows = 1;
                }
                else if (numbers[i] == min)
                {
                    numberOfLows++;
                }
            }

            return numberOfLows;
        }
    }
}
