using Api.Middleware.Exceptions;
using API.Middleware.Exceptions;
using BLL;
using BLL.Services;
using BLL.Services.Interfaces;
using BLL.Validation;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Exception Handling
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

//Fluent validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<AddOnDtoValidator>();

// Repositories + UoW
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAddOnRepository, AddOnRepository>();
builder.Services.AddScoped<IBouquetRepository, BouquetRepository>();

// Services
builder.Services.AddScoped<IAddOnService, AddOnService>();
builder.Services.AddScoped<IBouquetService, BouquetService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();