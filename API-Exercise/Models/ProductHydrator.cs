using System;
using API_Exercise.Services;

namespace API_Exercise.Models;

public interface IProductHydratorModel
{
    public List<IProduct>? getProducts();
    public IProduct? getProductById(int id);
}

public class ProductHydratorModel : IProductHydratorModel
{
    public List<IProduct>? getProducts()
    {
        JsonFileReader reader = new JsonFileReader();
        List<Product> products = reader.ReadAndParse<List<Product>>("products.json");
        return products.Cast<IProduct>().ToList();
    }

    public IProduct? getProductById(int id)
    {
        List<IProduct> products = this.getProducts();
        if (products == null)
        {
            return null;
        }

        IProduct? filteredProduct = null;

        foreach (IProduct product in products)
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
