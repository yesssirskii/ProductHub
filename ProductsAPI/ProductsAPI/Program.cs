using Microsoft.EntityFrameworkCore;
using ProductsAPI.Controllers;
using ProductsAPI.Repositories;
using ProductsAPI.Services;
using ProductsData.Entities;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adding services to the container:
builder.Services.AddScoped<IProductRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductsController>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProductDbContext>(options => {
  options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
}, ServiceLifetime.Transient);

// Fixing the POST method cycle error:
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Adding CORS:
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder => {
  builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
