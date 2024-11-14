using Lab1;
using System;
using System.Text;
using Xunit;

namespace Tests1
{

    public class Tests
    {
        // test for Calculation function
        [InlineData(1, "1")]
        [InlineData(11, "12")]
        [InlineData(239, "1135")]
        [InlineData(2147483647, "11111111333333344444444444444777777778999")]
        [InlineData(123456789, "3333344444455555557888889999")]
        [InlineData(987654321, "1112222223333455556666666667788889999")]
        [Theory]
        public void Calculation_Test(int input, string result)
        {

            // Act
            
            string actualResult = Calculation.Calculate(input);
            

            // Assert
            Assert.Equal(result, actualResult);
        }



    }
}