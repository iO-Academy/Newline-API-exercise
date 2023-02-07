using API_Exercise.Services;

namespace API_Exercise_Tests;

public class CurrencyConverterFacts
{
    [Fact]
    public void CurrencyConverter_ReturnsTrueWithValidCurrency()
    {
        var result = CurrencyConverter.setCurrency("USD");
        Assert.True(result);
    }

    [Fact]
    public void CurrencyConverter_ReturnsFalseWithInvalidCurrency()
    {
        var result = CurrencyConverter.setCurrency("YEN");
        Assert.False(result);
    }

    [Fact]
    public void CurrencyConverter_ConvertsCurrencyCorrectly_USD()
    {
        CurrencyConverter.setCurrency("USD");
        var result = CurrencyConverter.ConvertCurrency(1);
        Assert.Equal(1.24, result);
    }

    [Fact]
    public void CurrencyConverter_ConvertsCurrencyCorrectly_EUR()
    {
        CurrencyConverter.setCurrency("EUR");
        var result = CurrencyConverter.ConvertCurrency(1);
        Assert.Equal(1.14, result);
    }
}
