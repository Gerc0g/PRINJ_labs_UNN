using SieveOfEratosthenes;

int maxValue = 100;
int[] primes = GeneratorPrimes.generatePrimes(maxValue);
Console.WriteLine($"Результат для maxValue = {maxValue}: {string.Join(", ", primes)}");
