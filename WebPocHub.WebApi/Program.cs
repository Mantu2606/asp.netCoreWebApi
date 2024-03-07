using Microsoft.EntityFrameworkCore;
using WebPocHub.dal;
using WebPocHub.Dal;
using WebPocHub.Models; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// This is .AddDbContext is linking to database 
builder.Services.AddDbContext<WebPocHubDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConStr")));
builder.Services.AddTransient<ICommonRepository<Employee>, CommonRepository<Employee>>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
