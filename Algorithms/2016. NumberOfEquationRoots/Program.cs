using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016.NumberOfEquationRoots
{
    public class Program
    {
        public static async Task Main()
        {
            var coefs = await ReadCharacters();
            int result = NumberOfEquationRoots(coefs);
            await WriteCharacters(result);
        }

        public static async Task<int[]> ReadCharacters()
        {
            int[] coefficients = new int[3];
            string inputFileName = "input.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(path, inputFileName);

            try
            {
                using (StreamReader reader = File.OpenText(inputPath))
                {
                    string text = await reader.ReadToEndAsync();
                    var result = text.Split(' ');

                    if (result.Length != coefficients.Length)
                    {
                        throw new Exception("Wrong amount of data");
                    }

                    for (int i = 0; i < coefficients.Length; i++)
                    {
                        if (!int.TryParse(result[i], out coefficients[i]) || coefficients[i] < -100 || coefficients[i] > 100)
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

            return coefficients;
        }

        public static async Task WriteCharacters(int result)
        {
            string outputFileName = "output.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string outputPath = Path.Combine(path, outputFileName);

            try
            {
                using (StreamWriter writer = File.CreateText(outputPath))
                {
                    await writer.WriteAsync(result.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int NumberOfEquationRoots(int[] coefs)
        {
            if (coefs.Length != 3)
            {
                throw new Exception("Wrong amount of data");
            }

            if (coefs[0] == 0 && coefs[1] == 0 && coefs[2] == 0)
            {
                return -1;
            }

            double discriminant = coefs[0] != 0 ? Math.Pow(coefs[1], 2)  - 4 * coefs[0] * coefs[2] : 0;

            if (discriminant > 0)
            {
                return 2;
            }
            else if (discriminant == 0)
            {
                return 1;
            }
            else if (discriminant < 0)
            {
                return 0;
            }

            return 0;
        }
    }
}
