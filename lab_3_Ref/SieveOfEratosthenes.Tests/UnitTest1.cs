namespace SieveOfEratosthenes.Tests;

public class UnitTest1
{
    [Fact]
        public void GeneratePrimes_ReturnsEmptyArray_WhenMaxValueIsLessThanTwo()
        {
            int maxValue = 1;

            var result = PrimeGenerator.GeneratePrimes(maxValue);

            Assert.Empty(result);
        }

        [Fact]
        public void GeneratePrimes_ReturnsCorrectPrimes_WhenMaxValueIsTen()
        {
            int maxValue = 10;
            int[] expected = { 2, 3, 5, 7 };

            var result = PrimeGenerator.GeneratePrimes(maxValue);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GeneratePrimes_ReturnsCorrectPrimes_WhenMaxValueIsTwenty()
        {
            int maxValue = 20;
            int[] expected = { 2, 3, 5, 7, 11, 13, 17, 19 };

            var result = PrimeGenerator.GeneratePrimes(maxValue);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GeneratePrimes_ReturnsCorrectPrimes_WhenMaxValueIsThirty()
        {
            int maxValue = 30;
            int[] expected = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

            var result = PrimeGenerator.GeneratePrimes(maxValue);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GeneratePrimes_ReturnsCorrectPrimes_WhenMaxValueIsHundred()
        {
            int maxValue = 100;
            int[] expected = {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
                31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
                73, 79, 83, 89, 97
            };

            var result = PrimeGenerator.GeneratePrimes(maxValue);

            Assert.Equal(expected, result);
        }
}