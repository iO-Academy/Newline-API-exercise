using API_Exercise.Models;
using API_Exercise.Services;
using System;
using Newtonsoft.Json;

namespace API_Exercise.Controllers
{
    public class ProductsController
    {
        public static List<IProduct>? getAllProducts(IProductHydratorModel model)
        {
            List<IProduct>? products = model.getProducts();
            if (products == null)
            {
                Console.WriteLine("Unable to retrieve data");
                return null;
            }

            return products;
        }

        public static object? getProductById(int id, IProductHydratorModel model, string currency = "GBP")
        {
            IProduct? product = model.getProductById(id);

            if (product == null)
            {
                Console.WriteLine("Unable to retrieve data for product: " + id);
                return new ErrorResponse("No product with id " + id + " found.");
            }

            CurrencyConverter.setCurrency(currency);

            return product;
        }

    }
}

