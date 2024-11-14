using Lab2;
using System;
using System.Text;
using Xunit;

namespace Tests2
{

    public class Tests
    {
        // test for Calculation function
        [InlineData(1, 6, 0.166667)]
        [InlineData(1, 7, 0)]
        [InlineData(4, 14, 0.112654)]
        [InlineData(100, 100, 1.530647E-78)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 10, 0)]
        [Theory]
        public void Calculation_Test(int N, int Q, double result)
        {

            // Act

            double actualResult = Calculation.Calculate(N, Q);


            // Assert
            Assert.Equal(result, actualResult, 6);
        }



    }
}
