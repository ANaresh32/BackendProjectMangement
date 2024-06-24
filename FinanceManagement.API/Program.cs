using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;
using FinanceManagement.DATA.Repo;
using FinanceManagement.SERVICES.Interface;
using FinanceManagement.SERVICES.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PgSqlConn" +
    "")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeProjectRepository, EmployeeProjectRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITimesheetRepository, TimesheetRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITimesheetService, TimesheetService>();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();
    SeedData(dbContext);
}

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

void SeedData(FinanceDbContext context)
{
    if (!context.Roles.Any())
    {
        context.Roles.AddRange(
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Admin"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "User"
            }
        );
        context.SaveChanges();
    }

    if (!context.Employees.Any())
    {
        var adminRole = context.Roles.First(r => r.Name == "Admin");
        var userRole = context.Roles.First(r => r.Name == "User");

        context.Employees.AddRange(
            new Employee
            {
                Id = Guid.NewGuid(),
                EmployeeId = "E001",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PasswordHash = "password", 
                DateOfJoining = DateTime.UtcNow,
                RoleId = adminRole.Id,
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                EmployeeId = "E002",
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PasswordHash = "password", // In a real scenario, use a hashed password
                DateOfJoining = DateTime.UtcNow,
                RoleId = userRole.Id,
            }
        );
        context.SaveChanges();
    }
}