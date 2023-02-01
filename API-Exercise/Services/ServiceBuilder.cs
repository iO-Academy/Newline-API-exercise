using API_Exercise.Models;
using System;

namespace API_Exercise.Services;

public static class ServiceBuilder
{
    public static WebApplicationBuilder configure(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductHydratorModel, ProductHydratorModel>();
        builder.Services.AddSingleton<ProductHydratorModel>();

        return builder;
    }
}