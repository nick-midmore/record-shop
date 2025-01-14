using Newtonsoft.Json.Serialization;
using RecordShop;
using RecordShop.Controllers;
using RecordShop.Data;
using RecordShop.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ShopContext>();
builder.Services.AddScoped<AlbumController>();
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<AlbumService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
