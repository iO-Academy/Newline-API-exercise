using System;
namespace API_Exercise.Services;

public static class ServiceBuilder
{
	public static WebApplicationBuilder configure(WebApplicationBuilder builder)
	{
        builder.Services.AddSingleton<API_Exercise.Models.ProductHydratorModel>();

        return builder;
	}
}


