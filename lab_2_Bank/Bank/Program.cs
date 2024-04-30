using System;
using System.Collections.Generic;
using System.Linq;

public class ATM
{
    private Dictionary<int, int> cashInventory;

    // Конструктор
    public ATM(Dictionary<int, int> initialInventory)
    {
        // Инициализация инвентаря банкомата
        cashInventory = new Dictionary<int, int>(initialInventory);
    }

    // Метод для выдачи наличных из банкомата
    public Dictionary<int, int>? DispenseCash(int amount)
    {
        if (amount <= 0) return null;

        // Создание словаря для хранения результатов выдачи
        var output = cashInventory.ToDictionary(entry => entry.Key, entry => 0);
        // Сортировка инвентаря банкомата по номиналу купюр
        var sortedInventory = cashInventory.OrderByDescending(note => note.Key);

        foreach (var (denomination, count) in sortedInventory)
        {
            var needed = Math.Min(amount / denomination, count);
            if (needed > 0)
            {
                output[denomination] = needed;
                amount -= needed * denomination;
                if (amount == 0) break;
            }
        }

        // Возврат результата выдачи или null, если запрошенная сумма недоступна
        return amount == 0 ? output : null;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Запрошенная сумма
        int amount_Requested = 550;

        // Исходный инвентарь банкомата
        var initial_Inventory = new Dictionary<int, int>
        {
            {10, 5},
            {50, 10},
            {100, 5},
            {500, 5}
        };
        ATM atm = new ATM(initial_Inventory);

        var dispenseResult = atm.DispenseCash(amount_Requested);

        // Проверка результата выдачи и вывод результата на консоль
        if (dispenseResult == null)
        {
            Console.WriteLine("Столько деняк тута нету.");
            return;
        }
        else
        {
            foreach (var note in dispenseResult)
            {
                Console.WriteLine($"{note.Key}: {note.Value}");
            }
        }
    }
}
