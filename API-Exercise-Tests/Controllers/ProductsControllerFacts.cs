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
        // Arrange
        var product = new Mock<Product>();
        var model = new Mock<IProductHydratorModel>();
        var products = new List<Product>();
        products.Add(product.Object);
        model.Setup(x => x.getProducts()).Returns(products.Cast<IProduct>().ToList());

        var expected = new List<Product>();

        // Act
        var result = ProductsController.getAllProducts(model.Object);

        // Assert
        Assert.IsType<List<IProduct>>(result);
    }

    [Fact]
    public void getProductById_success()
    {
        var product = new Mock<IProduct>();
        product.Setup(x => x.id).Returns(1);
        var model = new Mock<IProductHydratorModel>();
        model.Setup(x => x.getProductById(It.IsAny<int>())).Returns(product.Object);

        var returnedProduct = ProductsController.getProductById(1, model.Object);

        //Assert.IsType<API_Exercise.Models.Product>(returnedProduct);
        Assert.Equal(1, product.Object.id);

    }
}

