using System.Text;
using API.Keycloak;
using Api.Middleware.Exceptions;
using API.Middleware.Exceptions;
using BLL;
using BLL.Services;
using BLL.Services.Interfaces;
using BLL.Validation.AddOn;
using DAL.Context;
using DAL.Helpers.Search;
using DAL.Helpers.Sorting;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter the Bearer token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

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
builder.Services.AddScoped<ICustomBouquetRepository, CustomBouquetRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepisitory>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Services
builder.Services.AddScoped<IAddOnService, AddOnService>();
builder.Services.AddScoped<IBouquetService, BouquetService>();
builder.Services.AddScoped<IFlowerService, FlowerService>();
builder.Services.AddScoped<ICustomBouquetService, CustomBouquetService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();

//Keycloak
/*builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"{builder.Configuration["Keycloak:BaseUrl"]}/realms/{builder.Configuration["Keycloak:Realm"]}",

            ValidateAudience = true,
            ValidAudience = "account",

            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,

            IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
            {
                var client = new HttpClient();
                var keyUri = $"{parameters.ValidIssuer}/protocol/openid-connect/certs";
                var response = client.GetAsync(keyUri).Result;
                var keys = new JsonWebKeySet(response.Content.ReadAsStringAsync().Result);

                return keys.GetSigningKeys();
            }
        };

        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
    });

builder.Services.AddHttpClient();
builder.Services.AddScoped<KeycloakAuthService>();*/

// Add services to the container
var key = Encoding.UTF8.GetBytes("W8zDp4x2mY9vK6nF3qR7tW5eX2aZ7pU6sQ9bJ4vL2cT8nR5oX3kV6rP7mY2qJ9");
builder.Services.AddAuthentication(options =>
    {
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
