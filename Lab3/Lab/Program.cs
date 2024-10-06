using System;
using System.IO;
using System.Text;

namespace Lab
{
    public static class Program
    {
        const int MAX_VERTEXES_COUNT = 1005;
        static int[,] graphMatrix = new int[MAX_VERTEXES_COUNT, MAX_VERTEXES_COUNT]; // adjacency table
        static int[] usedVertices = new int[MAX_VERTEXES_COUNT]; // array of used vertices
        static bool flag = false;
        static int n, m;
        static string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt");
        static string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt");

        static void Dfs(int v, int previous = -1)
        {
            usedVertices[v] = 1; // note that we have visited this vertex
            for (int i = 1; i <= n; i++) // go through the vertices
            {
                if (i != previous && graphMatrix[v, i] == 1) // don't go back the same way
                {
                    if (usedVertices[i] == 1) // if this vertex has already been visited
                    {
                        flag = true; // loop found
                        return;
                    }
                    else
                    {
                        Dfs(i, v); // recursive transition to the next vertex
                    }
                }
            }
        }

        static bool ValidateFirstLine(string[] firstLine)
        {
            if (firstLine.Length != 2)
            {
                Console.WriteLine("Error: the first line must contain exactly two natural numbers");
                return false;
            }

            if (!int.TryParse(firstLine[0], out n) || !int.TryParse(firstLine[1], out m) || n < 1 || n > 1000 || m < 0 || m > 100000)
            {
                Console.WriteLine("Error: invalid values of n or m. Numbers must be natural and 1 <= n <= 10^3, 0 <= m <= 10^5");
                return false;
            }

            return true;
        }

        static bool ValidateEdgeLine(string[] edgeLine)
        {
            if (edgeLine.Length != 2)
            {
                Console.WriteLine("Error: each line after the first must contain exactly two natural numbers");
                return false;
            }

            if (!int.TryParse(edgeLine[0], out int u) || !int.TryParse(edgeLine[1], out int v) || u <= 0 || v <= 0 || v > n || u > n || u == v)
            {
                Console.WriteLine($"Error: Invalid edge values ({edgeLine[0]}, {edgeLine[1]}). The vertices must be different natural numbers in the range from 1 to {n}");
                return false;
            }

            graphMatrix[u, v] = graphMatrix[v, u] = 1; // fill in the adjacency matrix
            return true;
        }

        public static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            try
            {
                string[] lines = File.ReadAllLines(inputPath); // read all lines of the file

                if (lines.Length == 0)
                {
                    Console.WriteLine("Error: The file is empty");
                    using (StreamWriter writer = new StreamWriter(outputPath, false))
                    {
                        writer.WriteLineAsync(string.Empty);
                    }
                    return;
                }

                string[] firstLine = lines[0].Split(); // the first line contains n and m
                if (!ValidateFirstLine(firstLine))
                {
                    using (StreamWriter writer = new StreamWriter(outputPath, false))
                    {
                        writer.WriteLineAsync(string.Empty);
                    }
                    return;
                }

                // fill in the adjacency matrix
                for (int i = 1; i <= m; i++)
                {
                    if (i >= lines.Length)
                    {
                        Console.WriteLine("Error: Not enough data to describe all edges");
                        using (StreamWriter writer = new StreamWriter(outputPath, false))
                        {
                            writer.WriteLineAsync(string.Empty);
                        }
                        return;
                    }

                    string[] edgeLine = lines[i].Split();
                    if (!ValidateEdgeLine(edgeLine))
                    {
                        using (StreamWriter writer = new StreamWriter(outputPath, false))
                        {
                            writer.WriteLineAsync(string.Empty);
                        }
                        return;
                    }
                }


                // looking for a loop
                for (int i = 1; i <= n; i++)
                {
                    if (flag)
                    {
                        break; // if we found a loop, we exit
                    }
                    if (usedVertices[i] == 0)
                    {
                        Dfs(i); // start the search from this vertex
                    }

                }
                Console.WriteLine("Start looking for loop in graph with " + n + " vertices, and " + m + " edges");
                Console.WriteLine("Where edges are:");
                for (int k = 1; k < lines.Length; k++)
                {
                    Console.WriteLine(lines[k]);
                }

                // Виведення результату
                if (flag)
                {
                    Console.WriteLine("Result: YES, was written in file OUTPUT.txt");
                    using (StreamWriter writer = new StreamWriter(outputPath, false))
                    {
                        writer.WriteLineAsync("YES");
                    }
                }
                else
                {
                    Console.WriteLine("Result: NO, was written in file OUTPUT.txt");
                    using (StreamWriter writer = new StreamWriter(outputPath, false))
                    {
                        writer.WriteLineAsync("NO");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}
