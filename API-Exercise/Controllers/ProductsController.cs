﻿using API_Exercise.Models;
using System;
using Newtonsoft.Json;

namespace API_Exercise.Controllers
{
	public class ProductsController
	{
		public static List<Product>? getAllProducts(double price = 0)
		{
            List<Product>? products = new List<Product>();

            if (price > 0)
            {
                products = ProductHydratorModel.getProductsByPrice(price);
            }
            else
            {
                products = ProductHydratorModel.getProducts();
            }
            
            if (products == null)
            {
                Console.WriteLine("Unable to retrieve data");
                return null;
            }

            return products;
        }

        public static object? getProductById(int id, string currency = "GBP")
        {
            Product? product = ProductHydratorModel.getProductById(id);
            if (product == null)
            {
                Console.WriteLine("Unable to retrieve data for product: " + id);
                return new ErrorResponse("No product with id " + id + " found.");
            }

            product.changeCurrency(currency);

            return product;
        }

    }
}

