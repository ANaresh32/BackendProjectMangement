using FinanceManagement.DATA.Repositories;
using FinanceManagement.DOMAIN.Data;
using FinanceManagement.DOMAIN.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database context
builder.Services.AddDbContext<FinanceDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PgSqlConn")));
// Configure repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Remove trailing slash
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Ensure credentials are allowed if needed
    });
});
var app = builder.Build();


app.UseCors("AllowSpecificOrigin"); // Ensure CORS is used before other middlewares

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});


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
