using System;

namespace API_Exercise.Services
{
	public static class CurrencyConverter
	{
        private readonly static string[] validCurrencies = { "GBP", "EUR", "USD" };

        public readonly static Dictionary<string, double> exchangeRates = new Dictionary<string, double>
        {
            {"GBP", 1 },
            { "EUR", 1.14 },
            { "USD", 1.24 }
        };

        private static string currency = "GBP";

        public static bool setCurrency(string currency)
        {
            if (validCurrencies.Contains(currency))
            {
                CurrencyConverter.currency = currency;
                return true;
            }
            return false;
        }

        public static double ConvertCurrency(double number)
        {
            return number * CurrencyConverter.exchangeRates[CurrencyConverter.currency];
        }

    }
}

