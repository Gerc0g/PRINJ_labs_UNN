namespace Bank.tests;

public class UnitTest
    {
        [Fact]
        public void DispenseCash_EnoughCash_ReturnsCorrectDispensedAmount()
        {
            // Тест, если в банкомате достаточно денег для выдачи запрошенной суммы
            // то DispenseCash возвращает корректное количество купюр

            var initialInventory = new Dictionary<int, int>
            {
                {10, 5},
                {50, 10},
                {100, 5},
                {500, 5}
            };
            ATM atm = new ATM(initialInventory);
            int amountRequested = 550;

            var dispenseResult = atm.DispenseCash(amountRequested);

            Assert.NotNull(dispenseResult);
            Assert.Equal(1, dispenseResult[50]);
            Assert.Equal(1, dispenseResult[500]);
            Assert.Equal(0, dispenseResult[10]);
            Assert.Equal(0, dispenseResult[100]);
        }


        [Fact]
        public void DispenseCash_NegativeAmount_ReturnsNull()
        {
            // Тест, что если запрошенная сумма отрицательная
            // метод DispenseCash возвращает null

            var initialInventory = new Dictionary<int, int>
            {
                {10, 5},
                {50, 10},
                {100, 5},
                {500, 5}
            };
            ATM atm = new ATM(initialInventory);
            int amountRequested = -100;

            var dispenseResult = atm.DispenseCash(amountRequested);

            Assert.Null(dispenseResult);
        }

        [Fact]
        public void DispenseCash_ZeroAmount_ReturnsNull()
        {
            // Тест, что если запрошенная сумма равна нулю
            // метод DispenseCash возвращает null

            var initialInventory = new Dictionary<int, int>
            {
                {10, 5},
                {50, 10},
                {100, 5},
                {500, 5}
            };
            ATM atm = new ATM(initialInventory);
            int amountRequested = 0;

            var dispenseResult = atm.DispenseCash(amountRequested);

            Assert.Null(dispenseResult);
        }

        [Fact]
        public void DispenseCash_EmptyInventory_ReturnsNull()
        {
            // Тест, что если в банкомате нет денег
            // метод DispenseCash возвращает null

            var initialInventory = new Dictionary<int, int>();
            ATM atm = new ATM(initialInventory);
            int amountRequested = 100;

            var dispenseResult = atm.DispenseCash(amountRequested);

            Assert.Null(dispenseResult);
        }
    }