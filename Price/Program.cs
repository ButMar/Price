
using Microsoft.EntityFrameworkCore;
using Price;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PriceContext>(
       options => options.UseSqlServer("name=ConnectionStrings:PriceDatabase"));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
