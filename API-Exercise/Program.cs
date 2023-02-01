var builder = WebApplication.CreateBuilder(args);

builder = API_Exercise.Services.ServiceBuilder.configure(builder);

var app = builder.Build();

app.MapGet("/products", API_Exercise.Controllers.ProductsController.getAllProducts);
app.MapGet("/products/{id}", API_Exercise.Controllers.ProductsController.getProductById);

app.Run();