using CustomerWebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


/* Database Context Dependency Injection */
/*
var dbHost = "shiva\\SQLEXPRESS";
var dbName = "dms_customer";
var dbPassword = "P@ssword_123";
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};Trusted_Connection=true;TrustServerCertificate=True";
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));
 */


/* Database Context Dependency Injection */
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True";
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
