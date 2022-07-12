using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2011.AgeAnalysis
{
    public class Program
    {
        public static async Task Main()
        {
            int age =  await ReadCharacters();
            string result = AgeAnalysis(age);
            await WriteCharacters(result);
        }

        public static async Task<int> ReadCharacters()
        {
            string result = string.Empty;
            int age = -1;
            string inputFileName = "input.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(path, inputFileName);

            try
            {
                using (StreamReader reader = File.OpenText(inputPath))
                {
                    Console.WriteLine("Opened file.");
                    result = await reader.ReadToEndAsync();
                    Console.WriteLine("Contains: " + result);

                    if ((!int.TryParse(result, out age)) || age < 0 || age > 150)
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

            return age;
        }

        public static async Task WriteCharacters(string result)
        {
            string outputFileName = "output.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string outputPath = Path.Combine(path, outputFileName);

            try
            {
                using (StreamWriter writer = File.CreateText(outputPath))
                {
                    await writer.WriteAsync(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string AgeAnalysis(int age)
        {
            if (age >= 0 && age < 7)
            {
                return "preschool child";
            }
            else if (age >= 7 && age < 18)
            {
                return "schoolchild " + (age - 6);
            }
            else if (age >= 18 && age <= 22)
            {
                return "student " + (age - 17);
            }
            else if (age > 22 && age <= 150)
            {
                return "specialist";
            }

            return string.Empty;
        }
    }
}
