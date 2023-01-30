var app = WebApplication.Create(args);

app.MapGet("/products", API_Exercise.Controllers.ProductsController.getAllProducts);
app.MapGet("/products/{id}", API_Exercise.Controllers.ProductsController.getProductById);

app.Run();

