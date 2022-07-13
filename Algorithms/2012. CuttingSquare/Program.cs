using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012.CuttingSquare
{
    public class Program
    {
        public static async Task Main()
        {
            var sides = await ReadCharacters();
            string result = CuttingSquare(sides);
            await WriteCharacters(result);
        }

        public static async Task<int[]> ReadCharacters()
        {
            string text = string.Empty;
            int[] sides = new int[4];
            string inputFileName = "input.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(path, inputFileName);

            try
            {
                using (StreamReader reader = File.OpenText(inputPath))
                {
                    text = await reader.ReadToEndAsync();
                    var result = text.Replace('\n', ' ').Split(' ');

                    if (result.Length != sides.Length)
                    {
                        throw new Exception("Wrong amount of data");
                    }

                    for (int i = 0; i < sides.Length; i++)
                    {
                        if (!int.TryParse(result[i], out sides[i]))
                        {
                            throw new Exception("Wrong data");
                        }

                        if (sides[i] < 1 || sides[i] > 1000)
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

            return sides;
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

        public static string CuttingSquare(int[] sides)
        {
            if (sides.Length != 4)
            {
                throw new Exception("Wrong data");
            }
            
            if (((sides[0] + sides[2]) == sides[1] && sides[1] == sides[3])
                || ((sides[0] + sides[3]) == sides[1] && sides[1] == sides[2])
                || ((sides[1] + sides[2]) == sides[0] && sides[0] == sides[3])
                || ((sides[1] + sides[3]) == sides[0] && sides[0] == sides[2]))
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
        }
    }
}
