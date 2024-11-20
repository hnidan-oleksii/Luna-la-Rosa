using Api.Middleware.Exceptions;
using API.Middleware.Exceptions;
using BLL;
using BLL.Services;
using BLL.Services.Interfaces;
using BLL.Validation;
using DAL.Context;
using DAL.Helpers.Search;
using DAL.Helpers.Sorting;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
var connectionString = builder.Configuration.GetConnectionString("PgsqlConnection");
builder.Services.AddDbContext<LunaContext>(options =>
{
    options.EnableSensitiveDataLogging();
    options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
});

// Exception Handling
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

//Fluent validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<AddOnDtoValidator>();

// Repositories + UoW
builder.Services.AddScoped(typeof(ISortHelper<>), typeof(SortHelper<>));
builder.Services.AddScoped(typeof(ISearchHelper<>), typeof(SearchHelper<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAddOnRepository, AddOnRepository>();
builder.Services.AddScoped<IBouquetRepository, BouquetRepository>();
builder.Services.AddScoped<IFlowerRepository, FlowerRepository>();

// Services
builder.Services.AddScoped<IAddOnService, AddOnService>();
builder.Services.AddScoped<IBouquetService, BouquetService>();
builder.Services.AddScoped<IFlowerService, FlowerService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LunaContext>();
    await dbContext.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();