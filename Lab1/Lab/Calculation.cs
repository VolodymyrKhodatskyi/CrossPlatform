using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class Calculation
    {
        // create a two-dimensional array to store the number of smooth numbers of length i with the first digit j
        static List<List<ulong>> matrixOfNumberOfSmoothNumbers = new List<List<ulong>>();

        // main function to find smooth number
        public static string Calculate(int N)
        {

            // initialize the dimension of the matrix 44 by 10
            for (int i = 0; i < 44; i++)
            {
                matrixOfNumberOfSmoothNumbers.Add(new List<ulong>(new ulong[10]));
            }

            // fill the first line from 1 to 9 with the value 1
            for (int i = 1; i < 10; i++)
            {
                matrixOfNumberOfSmoothNumbers[1][i] = 1;
            }

            // calculate the number of smooth numbers for each length and the first digit
            for (int i = 2; i < matrixOfNumberOfSmoothNumbers.Count; ++i)
            {
                for (int j = 1; j < 10; ++j)
                {
                    matrixOfNumberOfSmoothNumbers[i][j] = (ulong)matrixOfNumberOfSmoothNumbers[i - 1].Skip(j).Sum(x => (long)x);
                }
            }

            List<int> digitsOfResult = new List<int>();
            ulong nPrevious = 0, nCurrent = 0;
            int firstDigit = 1, rankOfNumber = 1;

            // The main cycle of searching for the desired number
            while (rankOfNumber > 0)
            {
                bool found = false; 

                for (int i = rankOfNumber; i < matrixOfNumberOfSmoothNumbers.Count && !found; ++i)
                {
                    for (int j = firstDigit; j < 10; ++j)
                    {
                        nPrevious = nCurrent;
                        nCurrent += matrixOfNumberOfSmoothNumbers[i][j];
                        if (nPrevious < (ulong)N && nCurrent >= (ulong)N)
                        {
                            nCurrent -= matrixOfNumberOfSmoothNumbers[i][j];
                            digitsOfResult.Add(j);
                            rankOfNumber = (i - 1);
                            firstDigit = j;
                            found = true; 
                            break; 
                        }
                    }
                }

                if (!found)
                {
                    break; // Exit outer loop if not found
                }

            }

            // making whole number
            string result = string.Join("", digitsOfResult);
            // print the result
            Console.WriteLine("The desired smooth number: " + result);

            return result;
        }
    }
}

