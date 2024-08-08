
using Data.Implementations;
using Data.Interfaces;
using Entity.Model.Contexts;
using Microsoft.EntityFrameworkCore;
using Data.Implements;
using Bunnisses.Security.Implemetations;
using Bunnisses.Security.Interface;
using Bunnisses.Security.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContexts>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBDefaultConnection")));


// Registra IPersonaData y su implementaci�n
builder.Services.AddScoped<IPersonData, PersonData>();
builder.Services.AddScoped<IPersonBussines, PersonBusiness>();

builder.Services.AddScoped<IRoleData, RoleData>();
builder.Services.AddScoped<IRolBusiness, RoleBusiness>();

builder.Services.AddScoped<IModuleData, ModuleData>();
builder.Services.AddScoped<IModuleBusiness, ModuleBusiness>();

builder.Services.AddScoped<IUser_roleData, User_RoleData>();
builder.Services.AddScoped<IUser_RoleBusiness, User_RoleBusiness>();

builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();

builder.Services.AddScoped<IViewData, ViewData>();
builder.Services.AddScoped<IViewBusiness, ViewBusiness>();

builder.Services.AddScoped<IRole_ViewData, Rol_ViewData>();
builder.Services.AddScoped<IRole_ViewBusiness, Role_ViewBusiness>();


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
