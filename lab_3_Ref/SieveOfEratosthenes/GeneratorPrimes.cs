namespace SieveOfEratosthenes
{
    public class PrimeGenerator
    {
        // <summary>
        /// Генерирует массив простых чисел до необходимого максимального значения.
        /// </summary>
        /// <param name="maxValue">Максимальное значение.</param>
        /// <returns>Массив чисел.</returns>
        public static int[] GeneratePrimes(int maxValue)
        {
            if (maxValue < 2)
                return new int[0];

            // Инициализация массива, простые числа отмечены как true
            bool[] isPrime = new bool[maxValue + 1];
            for (int i = 2; i <= maxValue; i++)
            {
                isPrime[i] = true;
            }

            // Отсев
            for (int i = 2; i * i <= maxValue; i++)
            {
                if (isPrime[i]) // Если i простое
                {
                    for (int j = 2 * i; j <= maxValue; j += i)
                    {
                        isPrime[j] = false; // Вычеркиваем кратные числа
                    }
                }
            }

            // Заполнение списка простыми числами
            List<int> primesList = new List<int>();
            for (int i = 2; i <= maxValue; i++)
            {
                if (isPrime[i])
                {
                    primesList.Add(i);
                }
            }

            return primesList.ToArray(); // Преобразуем список в массив и возвращаем
        }
    }
}
