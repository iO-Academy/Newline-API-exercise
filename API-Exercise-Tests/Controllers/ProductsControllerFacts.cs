using Moq;
using System;
using API_Exercise.Controllers;
using API_Exercise.Models;

namespace API_Exercise_Tests.Controllers;

public class ProductsControllerFacts
{

    [Fact]
    public void getAllProducts_shouldReturnListOfProducts()
    {
        var product = new Mock<IProduct>();
        var model = new Mock<IProductHydratorModel>();
        var products = new List<IProduct>()
        {
            product.Object
        };
        model.Setup(x => x.getProducts()).Returns(products);

        var result = ProductsController.getAllProducts(model.Object);

        Assert.IsType<List<IProduct>>(result);
    }

    [Fact]
    public void getAllProducts_withPriceFilter_shouldReturnListOfProducts()
    {
        var product = new Mock<IProduct>();
        var model = new Mock<IProductHydratorModel>();
        var products = new List<IProduct>()
        {
            product.Object
        };
        model.Setup(x => x.getProductsByPrice(It.IsAny<double>())).Returns(products);

        var result = ProductsController.getAllProducts(model.Object, 55.5);

        Assert.IsType<List<IProduct>>(result);
        model.Verify(x => x.getProductsByPrice(It.IsAny<double>()));
    }

    [Fact]
    public void getAllProducts_shouldReturnNull()
    {
        var model = new Mock<IProductHydratorModel>();
        model.Setup(x => x.getProducts()).Returns((List<IProduct>)null);

        var result = ProductsController.getAllProducts(model.Object);

        // cannot test Console.WriteLine - should use a Logger class and test that is called
        Assert.Null(result);
    }

    [Fact]
    public void getProductById_shouldReturnProduct()
    {
        var product = new Mock<IProduct>();
        var model = new Mock<IProductHydratorModel>();
        model.Setup(x => x.getProductById(It.IsAny<int>())).Returns(product.Object);

        var result = ProductsController.getProductById(1, model.Object);

        Assert.Equal(product.Object, result);
        product.Verify(x => x.changeCurrency(It.IsAny<string>()));

    }

    [Fact]
    public void getProductById_shouldReturnErrorResponse()
    {
        var model = new Mock<IProductHydratorModel>();
        model.Setup(x => x.getProducts()).Returns((List<IProduct>)null);

        var result = (ErrorResponse)ProductsController.getProductById(1, model.Object);

        Assert.IsType<ErrorResponse>(result);
        Assert.Matches("No product with id 1 found.", result.message);

    }
}

