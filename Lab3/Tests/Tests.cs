using Lab3;
using System;
using System.Text;
using Xunit;

namespace Tests3
{

    public class Tests
    {
        // test for Main function
        [Fact]
        public void Finding_Loop_In_Graph_1_Test()
        {
            // Arrange
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt"); 
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt");
            string[] actualResult;
            using (StreamWriter writer = new StreamWriter(inputPath, false))
            {
                writer.WriteLineAsync("3 4\r\n1 2\r\n2 3\r\n3 1\r\n3 2");
            }
            // Act
            Program.Main();
            using (StreamReader reader = new StreamReader(outputPath))
            {
                actualResult = reader.ReadToEnd().Split();
            }

            // Assert
            Assert.Equal("YES", actualResult[0]);
        }

        [Fact]
        public void Finding_Loop_In_Graph_2_Test()
        {
            // Arrange
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt");
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt");
            string[] actualResult;
            using (StreamWriter writer = new StreamWriter(inputPath, false))
            {
                writer.WriteLineAsync("2 3\r\n1 2\r\n2 1\r\n2 1");
            }
            // Act
            Program.Main();
            using (StreamReader reader = new StreamReader(outputPath))
            {
                actualResult = reader.ReadToEnd().Split();
            }

            // Assert
            Assert.Equal("NO", actualResult[0]);
        }

        [Fact]
        public void Finding_Loop_In_Graph_3_Test()
        {
            // Arrange
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt");

            using (StreamWriter writer = new StreamWriter(inputPath, false))
            {
                writer.WriteLineAsync("-1 0\r\n1 2\r\n2 1\r\n2 1");
            }
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); 

            // Act
            Program.Main(); 

            // Assert
            var output = consoleOutput.ToString();
            Assert.Contains("Error: invalid values of n or m. Numbers must be natural and 1 <= n <= 10^3, 0 <= m <= 10^5", output);
        }

        [Fact]
        public void Finding_Loop_In_Graph_4_Test()
        {
            // Arrange
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt");

            using (StreamWriter writer = new StreamWriter(inputPath, false))
            {
                writer.WriteLineAsync("1000000 1000000\r\n1 2\r\n2 1\r\n2 1");
            }
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); 

            // Act
            Program.Main(); 

            // Assert
            var output = consoleOutput.ToString();
            Assert.Contains("Error: invalid values of n or m. Numbers must be natural and 1 <= n <= 10^3, 0 <= m <= 10^5", output);
        }

        [Fact]
        public void Finding_Loop_In_Graph_5_Test()
        {
            // Arrange
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt");

            using (StreamWriter writer = new StreamWriter(inputPath, false))
            {
                writer.WriteLineAsync("2 3\r\n1 2\r\n2 2\r\n2 1");
            }
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); 

            // Act
            Program.Main(); 

            // Assert
            var output = consoleOutput.ToString();
            Assert.Contains("Error: Invalid edge values (2, 2). The vertices must be different natural numbers in the range from 1 to 2", output);
        }

    }
}