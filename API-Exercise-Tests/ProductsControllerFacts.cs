using Moq;
using System;
using API_Exercise.Controllers;
using API_Exercise.Models;

namespace API_Exercise_Tests.Controllers;

public class ProductsControllerFacts
{

    [Fact]
    public void getProducts_ShouldReturnListOfProducts()
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
    public void getProductById_shouldReturnProduct()
    {
        var product = new Mock<IProduct>();
        var model = new Mock<IProductHydratorModel>();
        model.Setup(x => x.getProductById(It.IsAny<int>())).Returns(product.Object);

        var result = ProductsController.getProductById(1, model.Object);

        Assert.Equal(product.Object, result);
        product.Verify(x => x.changeCurrency(It.IsAny<string>()));

    }
}

