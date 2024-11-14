using System;
using System.Text;

namespace Lab2
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            string InputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt");
            string OutputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt");
            CheckPaths(InputPath, OutputPath);
        }

        public static void CheckPaths(string InputPath, string OutputPath)
        {
            // check if File INPUT.txt exists
            if (!File.Exists(InputPath))
            {
                Console.WriteLine("Error! File INPUT.txt with path: " + InputPath + " wasnt found");
                using (StreamWriter writer = new StreamWriter(OutputPath, false))
                {
                    writer.WriteLineAsync(string.Empty);
                }
                return;
            }
            // read content of INPUT.txt file
            using (StreamReader reader = new StreamReader(InputPath))
            {
                string[] input;
                double result;
                input = reader.ReadToEnd().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (input.Length != 2)
                {
                    Console.WriteLine("Error! In the input file, there should be only 2 natural numbers(N <= 500, Q <= 3000) divided by space");
                    using (StreamWriter writer = new StreamWriter(OutputPath, false))
                    {
                        writer.WriteLineAsync(string.Empty);
                    }
                }
                // Trying to parse number from file
                else if (int.TryParse(input[0], out int N) && int.TryParse(input[1], out int Q))
                {
                    if (N < 0 || N > 500) // checking if first number is correct
                    {
                        Console.WriteLine("Error! In the input file, first number in input must be an integer not less than 0 and not more than 500");
                        using (StreamWriter writer = new StreamWriter(OutputPath, false))
                        {
                            writer.WriteLineAsync(string.Empty);
                        }
                    }
                    else if (Q < 0 || Q > 3000) // checking if second number is correct
                    {
                        Console.WriteLine("Error! In the input file, second number in input must be an integer not less than 0 and not more than 3000");
                        using (StreamWriter writer = new StreamWriter(OutputPath, false))
                        {
                            writer.WriteLineAsync(string.Empty);
                        }
                    }
                    else // if number is correct
                    {
                        Console.WriteLine("A numbers that was entered N: " + N + " and Q: " + Q);
                        Console.WriteLine("Start searching for probability");
                        result = Calculation.Calculate(N, Q);

                        using (StreamWriter writer = new StreamWriter(OutputPath, false))
                        {
                            writer.WriteLineAsync(result.ToString(System.Globalization.CultureInfo.InvariantCulture)); // converting double to american notation
                        }
                        Console.WriteLine("The result was written to a file OUTPUT.txt");
                    }

                }
                else // if content is not number
                {
                    Console.WriteLine("Error! In the input file, there should be only 2 natural numbers(N <= 500,  Q <= 3000) divided by space");
                    using (StreamWriter writer = new StreamWriter(OutputPath, false))
                    {
                        writer.WriteLineAsync(string.Empty);
                    }
                }



            }
        }
    }
}