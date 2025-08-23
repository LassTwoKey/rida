using Microsoft.EntityFrameworkCore;
using App.Core.Abstractions;
using App.DataAccess;
using App.DataAccess.Repositories;
using App.Application.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddServer(new OpenApiServer { Url = "/api" });
});

builder.Services.AddDbContext<AppDbContext>(
    options => options
        .UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext))));

builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWithCredentials",
        builder =>
        {
            builder.WithOrigins(
                "http://localhost:3000",
                "http://localhost:3040"
                )
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowWithCredentials");
app.UseAuthorization();

app.UsePathBase(new PathString("/api"));
app.MapControllers();


app.Run();