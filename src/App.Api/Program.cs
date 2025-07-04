using Microsoft.EntityFrameworkCore;
using App.Core.Abstractions;
using App.DataAccess;
using App.DataAccess.Repositories;
using App.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddServer(new OpenApiServer { Url = "/api" });
    c.DocumentFilter<BasePathFilter>("/api");
});

builder.Services.AddDbContext<AppDbContext>(
    options => options
        .UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext))));

builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "My API V1");
    });

app.UseAuthorization();

app.UsePathBase(new PathString("/api"));
app.MapControllers();

app.Run();