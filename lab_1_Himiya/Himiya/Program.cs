using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class HimiyaParser
{
    // Основной метод для разбора формулы
    public static string Parse(string formula)
    {
        // Словарь для хранения элементов и их количеств
        var elements = new Dictionary<string, int>();
        // Регулярное выражение для поиска элементов и групп элементов
        var matches = Regex.Matches(formula, @"([A-Z][a-z]*)(\d*)|\(([^)]+)\)(\d*)").Cast<Match>().ToList();
        // Разбор формулы
        ParseFormula(matches, elements);
        // Преобразование словаря в строку
        return string.Join(";", elements.Select(item => $"{item.Key}:{item.Value}"));
    }

    // Вспомогательный рекурсивный метод для разбора формулы
    private static void ParseFormula(List<Match> matches, Dictionary<string, int> elements)
    {
        foreach (Match match in matches)
        {
            var element = match.Groups[1].Value;
            if (string.IsNullOrEmpty(element)) // Разбор скобочных групп
            {
                var elementsInParentheses = match.Groups[3].Value;
                var multiplier = string.IsNullOrEmpty(match.Groups[4].Value) ? 1 : int.Parse(match.Groups[4].Value);
                var tempElements = new Dictionary<string, int>();
                ParseFormula(Regex.Matches(elementsInParentheses, @"([A-Z][a-z]*)(\d*)|\(([^)]+)\)(\d*)").Cast<Match>().ToList(), tempElements);
                MultiplyElementsCount(tempElements, multiplier, elements);
            }
            else // Обработка отдельных элементов
            {
                var count = string.IsNullOrEmpty(match.Groups[2].Value) ? 1 : int.Parse(match.Groups[2].Value);
                if (elements.ContainsKey(element))
                {
                    elements[element] += count;
                }
                else
                {
                    elements[element] = count;
                }
            }
        }
    }

    // Умножение количества каждого элемента на множитель для групп элементов в скобках
    private static void MultiplyElementsCount(Dictionary<string, int> tempElements, int multiplier, Dictionary<string, int> elements)
    {
        foreach (var item in tempElements)
        {
            if (elements.ContainsKey(item.Key))
            {
                elements[item.Key] += item.Value * multiplier;
            }
            else
            {
                elements[item.Key] = item.Value * multiplier;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var formulas = new[] { "H2O", "Cu(OH)2", "C2H5OH" };
        // Итерация по списку формул
        foreach (var formula in formulas)
        {
            Console.WriteLine(HimiyaParser.Parse(formula));
        }
    }
}
