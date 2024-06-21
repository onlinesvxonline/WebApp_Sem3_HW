using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using WebAppGeek.Abstraction;

var builder = WebApplication.CreateBuilder(args);

var httpClient = new HttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.Map("/api/product", app =>
{
    app.Run(async context =>
    {
        var productRepository = app.Services.GetRequiredService<IProductRepository>();
        // Handle product API requests
        await context.Response.WriteAsync("Product API Gateway");
    });
});

app.Map("/api/productgroup", app =>
{
    app.Run(async context =>
    {
        var productGroupRepository = app.Services.GetRequiredService<IProductGroupRepository>();
        // Handle product group API requests
        await context.Response.WriteAsync("Product Group API Gateway");
    });
});

app.Run();