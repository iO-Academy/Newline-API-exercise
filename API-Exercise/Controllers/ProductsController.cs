﻿using API_Exercise.Models;
using System;
using Newtonsoft.Json;

namespace API_Exercise.Controllers
{
	public class ProductsController
	{
		public static List<Product>? getAllProducts()
		{
            List<Product>? products = ProductHydratorModel.getProducts();
            if (products == null)
            {
                Console.WriteLine("Unable to retrieve data");
                return null;
            }

            return products;
        }

        public static Product? getProductById(int id, string currency = "GBP")
        {
            Console.WriteLine(currency);
            Product? product = ProductHydratorModel.getProductById(id);
            if (product == null)
            {
                Console.WriteLine("Unable to retrieve data for product: " + id);
                return null;
            }

            product.changeCurrency(currency);

            return product;
        }
        
    }
}
