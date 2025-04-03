using Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    public class CalculatorTest
    {
        [Fact]
        public void Add_GivenTwoInts_ReturnsSum()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add(1, 2);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_GivenSecondValueIsZero_ReturnsFirstValue()
        {
            // Arrange
            var calc = new Calculator();

            // Act

            var result = calc.Add(1, 0);

            // Assert
            Assert.Equal(1, result);
        }
    }
}
