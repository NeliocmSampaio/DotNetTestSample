using NSubstitute;
using Services;
using Services.Interfaces;
using Services.Models;
using Shouldly;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class CalculatorTest
    {
        private ISumService _sumService;
        private ISubtractionService _subtractionService;
        private ICalculatorService _calculatorService;

        private ISumService _mockedSumService;

        public CalculatorTest()
        {
            _sumService = new SumService();
            _subtractionService = new SubtractionService();

            _mockedSumService = Substitute.For<ISumService>();
        }

        [Theory]
        [InlineData(2, 2, Operation.Sum, 4)]
        [InlineData(2, -4, Operation.Sum, -2)]
        [InlineData(-2, 4, Operation.Sum, 2)]
        [InlineData(-2, 4, Operation.Subtract, -6)]
        [InlineData(2, -4, Operation.Subtract, 6)]
        public void TestProcessOperationSum(int value1, int value2, Operation operation, int expectedResult)
        {
            _calculatorService = new CalculatorService(_sumService, _subtractionService);

            var result = _calculatorService.ProcessOperation(value1, value2, operation);

            result.ShouldBe(expectedResult, $"Wrong answer! Result should be {expectedResult}, {result} was found.");
        }

        [Fact]
        public void TestReturnTrue()
        {
            _calculatorService = new CalculatorService(_sumService, _subtractionService);

            var result = _calculatorService.ReturnTrue();

            result.ShouldBeTrue($"Result should be true, {result} was found.");
        }

        [Fact]
        public void TestMockingSumService()
        {
            var value1 = 10;
            var value2 = 10;
            var operation = Operation.Sum;

            // Here the expected value is different from the sum between value1 and value2 just to show
            // Sum() will not be called actually. The mocked object will return a preprogramed value.
            var expectedValue = -1;

            _calculatorService = new CalculatorService(_mockedSumService, _subtractionService);

            // For any values received as parameter, Sum() will return the expectedValue.
            _mockedSumService.Sum(Arg.Any<int>(), Arg.Any<int>())
                                .ReturnsForAnyArgs( expectedValue );

            var result = _calculatorService.ProcessOperation(value1, value2, operation);

            result.ShouldBe(expectedValue, $"Wrong answer! Result should be {expectedValue}, {result} was found.");

            // Asserts Sum() was called once.
            _mockedSumService.Received(1).Sum(Arg.Any<int>(), Arg.Any<int>());
        }
    }
}
