using Microsoft.EntityFrameworkCore;
using RentApp.Repository;
using RentApp.Repository.Entities;
using RentApp.Repository.Implementation;
using RentApp.Repository.Interface;
using RentApp.Services;
using RentApp.Services.Implementation;
using RentApp.Services.Interface;
using RentApp.Services.Price;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IBookServices, BookServices>();
builder.Services.AddTransient<IBookRepository, BookRepository>();

builder.Services.AddTransient<IRidecarServices, RidecarServices>();
builder.Services.AddTransient<IRidecarRepository, RidecarRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RentApp"), b => b.MigrationsAssembly("RentApp.Repository")));
builder.Services.AddScoped<PriceCalculator>(); // ? Register in DI container

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
