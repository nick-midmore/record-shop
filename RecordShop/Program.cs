using Newtonsoft.Json;
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
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddOpenApi();

builder.Services.AddScoped<ShopContext>();
builder.Services.AddScoped<AlbumController>();
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<StockController>();
builder.Services.AddScoped<StockRepository>();
builder.Services.AddScoped<StockService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

