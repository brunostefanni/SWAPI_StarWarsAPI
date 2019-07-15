using System;
using Xunit;
using SWAPI.Application;
using SWAPI.Application.UseCases;

namespace SWAPI.UnitTests.UseCaseTests
{
    public class StarshipResupplyRequiredTests
    {
        [Fact]
        public void ReceiveInputedValue_Must_Return_1()
        {
            //Arrange
            var useCaseStarshipResupply = new StarshipResupplyRequired();   
            var console = new TestConsoleVirtual();

            //Act
            var inputedValue = useCaseStarshipResupply.ReceiveInputedValue(console);

            // Assert
            Assert.Equal(1, inputedValue);
        }

        [Fact]
        public void ValidateInputedValue_Must_Return_True()
        {
            //Arrange
            var useCaseStarshipResupply = new StarshipResupplyRequired();
            var console = new TestConsoleVirtual();

            //Act
            var validatedInputedValue = useCaseStarshipResupply.ValidateInputedValue("100000",console);

            // Assert
            Assert.True(validatedInputedValue);
        }

        [Fact]
        public void ValidateInputedValue_Must_Return_False()
        {
            //Arrange
            var useCaseStarshipResupply = new StarshipResupplyRequired();
            var console = new TestConsoleVirtual();

            //Act
            var validatedInputedValue = useCaseStarshipResupply.ValidateInputedValue("AAA", console);

            // Assert
            Assert.False(validatedInputedValue);
        }
    }

    public class TestConsoleVirtual : ConsoleVirtual
    {        
        private string[] values = { "1" };
        private int index = 0;
        public override string GetInputedValue()
        {
            return values[index++];
        }

        public override void SetWriteLine(string value)
        {
            var noReturn = value;
        }
    }
}
