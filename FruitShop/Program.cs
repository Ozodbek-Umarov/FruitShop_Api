using Application.Common;
using Application.Common.Validators;
using Application.Helper.Security;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructures;
using Infrastructures.Interfaces;
using Infrastructures.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();
builder.Services.AddScoped<IValidator<Fruit>, FruitValidator>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFruitService, FruitService>();

builder.Services.AddTransient<IAuthManager, AuthManager>();
builder.Services.AddTransient<IAccountService, AccountService>();

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
