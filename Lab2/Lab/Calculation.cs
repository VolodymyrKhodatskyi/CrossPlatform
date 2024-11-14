using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class Calculation
    {

        public static double Calculate(int N, int Q)
        {
            if (Q < N || 6 * N < Q) // check for minimum and maximum possible sums
            {
                return 0;
            }

            double[] current = new double[Q + 1]; 
            double[] previous = new double[Q + 1];
            current[0] = 1;

            for (int i = 1; i <= N; i++)
            {
                Array.Copy(current, previous, current.Length); // swap arrays

                for (int j = 0; j <= Q; j++)
                {
                    current[j] = 0;
                    for (int k = 1; k <= 6; k++)
                    {
                        if (j - k >= 0)
                        {
                            current[j] += previous[j - k];
                        }
                    }
                    current[j] /= 6;
                }
            }
            double result = Math.Round(current[Q], 6); // rounding 
            return result;
        }
    }
}
