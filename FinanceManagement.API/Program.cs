<<<<<<< HEAD
using FinanceManagement.DATA.Repositories;
using FinanceManagement.DOMAIN.Data;
using FinanceManagement.DOMAIN.Repository;
=======
using FinanceManagement.DATA.Data;
using FinanceManagement.DATA.IRepo;
using FinanceManagement.DATA.Repo;
using FinanceManagement.SERVICES.Interface;
using FinanceManagement.SERVICES.Services;
>>>>>>> origin/Roles,Projects,Roles,TimeSheetControllersAdded
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
// Configure database context
builder.Services.AddDbContext<FinanceDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PgSqlConn")));
// Configure repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
=======
// Add services to the container.
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PgSqlConn")));

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
>>>>>>> origin/Roles,Projects,Roles,TimeSheetControllersAdded

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
