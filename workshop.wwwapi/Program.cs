using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;
using workshop.models;
using workshop.services.calculator;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<CalculationService>();
builder.Services.AddScoped<IRepository<Calculation>, Repository<Calculation>>();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Calculations"));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddFiltering().AddSorting().AddProjections();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()    
    .WriteTo.File("logs/Calculation-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();
app.MapGraphQL();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.ConfigureCalculatorEndpoints();

app.Run();


