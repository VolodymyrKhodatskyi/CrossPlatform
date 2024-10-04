using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Numerics;
using System.Text;
using Lab;


namespace Lab
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            string InputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt");
            string OutputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt");
            // check if File INPUT.txt exists
            if (!File.Exists(InputPath))
            {
                Console.WriteLine("Error! File INPUT.txt with path: " + InputPath + " wasnt found");
                return;
            }
            // read content of INPUT.txt file
            using (StreamReader reader = new StreamReader(InputPath))
            {
                string? line;
                string result;
                line = reader.ReadToEnd();
                
                // Trying to parse number from file
                if (int.TryParse(line, out int N))
                {
                    if (N < 1 || N > 2147483647) // checking if number is correct
                    {
                        Console.WriteLine("Error! In the input file, a number is entered incorrectly. The input must be an integer not less than 1 and not more than 2147483647");
                        using (StreamWriter writer = new StreamWriter(OutputPath, false))
                        {
                            writer.WriteLineAsync(string.Empty);
                        }
                    }
                    else // if number is correct
                    {
                        Console.WriteLine("A number that was entered " + N);
                        Console.WriteLine("Start searching for a smooth number by number " + N);
                        result = Calculation.Calculate(N);
                        using (StreamWriter writer = new StreamWriter(OutputPath, false))
                        {
                            writer.WriteLineAsync(result);
                        }
                        Console.WriteLine("The result was written to a file OUTPUT.txt");
                    }

                }
                else // if content is not number
                {
                    Console.WriteLine("Error! In the input file, a number is entered incorrectly. The input must be an integer not less than 1 and not more than 2147483647");
                    using (StreamWriter writer = new StreamWriter(OutputPath, false))
                    {
                        writer.WriteLineAsync(string.Empty);
                    }
                }



            }
        }
    }
}

