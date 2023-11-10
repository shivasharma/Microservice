using ProductWebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/*
var dbHost = "localhost";
var dbName = "dms_product";
var dbPassword = "Shiva@123";

var connectionString = $"server={dbHost};Initial Catalog={dbName};port=3306;user=root;password={dbPassword};";
builder.Services.AddDbContext<ProductDbContext>(opt => opt.UseMySQL(connectionString));
*/

/* Database Context Dependency Injection */
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");

var connectionString = $"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword}";
builder.Services.AddDbContext<ProductDbContext>(o => o.UseMySQL(connectionString));

/* ===================================== */


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
