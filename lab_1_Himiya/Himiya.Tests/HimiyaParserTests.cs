namespace Himiya.Tests;

public class UnitTest1
{
    [Fact]
    // Тестирование простой формулы воды (H2O). Ожидается корректное разделение элементов и их количества.
    public void Parse_SimpleWater_ShouldCorrectlyParse()
    {
        var result = HimiyaParser.Parse("H2O");
        Assert.Equal("H:2;O:1", result);
    }

    [Fact]
    // Тестирование формулы гидроксида меди (Cu(OH)2). Ожидается определение элементов в скобках и их умножение.
    public void Parse_CopperHydroxide_ShouldCorrectlyParse()
    {
        var result = HimiyaParser.Parse("Cu(OH)2");
        Assert.Equal("Cu:1;O:2;H:2", result);
    }

    [Fact]
    // Тестирование формулы этилового алкоголя (C2H5OH). Формула содержитт несколько типов элементов и груп.
    public void Parse_Ethanol_ShouldCorrectlyParse()
    {
        var result = HimiyaParser.Parse("C2H5OH");
        Assert.Equal("C:2;H:6;O:1", result);
    }

    [Fact]
    // Проверка поведения на пустую строку. Ожидается возврат пустой строки.
    public void Parse_EmptyString_ShouldReturnEmpty()
    {
        var result = HimiyaParser.Parse("");
        Assert.Equal("", result);
    }

    [Fact]
    // Тестирование разбора более сложной формулы, сульфат аммония ((NH4)2SO4).
    // Тест проверяет корректность обработки вложенных скобок и множителей.
    public void Parse_ComplexMolecule_ShouldCorrectlyParse()
    {
        var result = HimiyaParser.Parse("(NH4)2SO4");
        Assert.Equal("N:2;H:8;S:1;O:4", result);
    }
}