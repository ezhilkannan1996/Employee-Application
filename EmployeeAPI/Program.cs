using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDataContext") ?? throw new InvalidOperationException("Connection string 'UserDataContext' not found.")));

// Add services to the container.
builder.Services.AddTransient<IEmployee, EmployeeServices>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<employeeApiDbContext>(options=>options.UseInMemoryDatabase("EmployeeDb"));

//builder.Services.AddDbContext<employeeApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<EmployeeDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeAPIContext")));

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
