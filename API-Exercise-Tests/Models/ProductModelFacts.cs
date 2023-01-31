using API_Exercise.Models;
using Xunit;

namespace API_Exercise_Tests;

public class ProductModelFacts
{
    [Fact]
    public void Instantiate_Product()
    {
        var product = new Product();
        Assert.IsType<Product>(product);
    }

    [Fact]
    public void Product_changeCurrency_valid()
    {
        var product = new Product();
        var result = product.changeCurrency("EUR");
        Assert.True(result);
    }

    [Fact]
    public void Product_changeCurrency_invalid()
    {
        var product = new Product();
        var result = product.changeCurrency("YEN");
        Assert.False(result);
    }
}


