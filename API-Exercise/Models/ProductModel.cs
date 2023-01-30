using System;
using API_Exercise.Services;

namespace API_Exercise.Models
{

    public class ProductHydratorModel
    {
        public static List<Product>? getProducts()
        {
            JsonFileReader reader = new JsonFileReader();
            List<Product> products = reader.ReadAndParse<List<Product>>("products.json");
            return products;
        }

        public static Product? getProductById(int id)
        {
            List<Product> products = ProductHydratorModel.getProducts();

            Product? filteredProduct = null;

            foreach (Product product in products)
            {
                if (product.id.Equals(id))
                {
                    filteredProduct = product;
                    break;
                }
            }

            return filteredProduct;
        }
        
    }

    public class Product
	{
		public int id { get; set; }
		public string title { get; set; }
        public string description { get; set; }
        private double _price;
        public double price
        {
            get { return _price * exchangeRates[currency]; }
            set { _price = value; }
        }
        public float discountPercentage { get; set; }
        public float rating { get; set; }
        public int stock { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        public string thumbnail { get; set; }
        public List<string> images { get; set; }
        private Dictionary<string, double> exchangeRates { get; }

        private string currency = "GBP";
        private readonly string[] validCurrencies = { "GBP", "EUR", "USD" };

        public Product()
        {
            exchangeRates = new Dictionary<string, double>();
            exchangeRates.Add("GBP", 1);
            exchangeRates.Add("EUR", 1.14);
            exchangeRates.Add("USD", 1.24);
        }

        public void changeCurrency(string currency)
        {
            if (validCurrencies.Contains(currency))
            {
                this.currency = currency;
            }
        }
    }
}

