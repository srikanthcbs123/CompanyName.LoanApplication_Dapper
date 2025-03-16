using CompanyName.LoanApplication_Dapper.Connection;
using CompanyName.LoanApplication_Dapper.Interfaces;
using CompanyName.LoanApplication_Dapper.Repositories;
using CompanyName.LoanApplication_Dapper.Sevices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDepartementService,DepartementService>();
builder.Services.AddScoped<IDepartementRepository,DepartementRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();//we are reaing the connection string here
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
