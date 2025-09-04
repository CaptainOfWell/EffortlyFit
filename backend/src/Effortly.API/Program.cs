using Effortly.Infrastructure;
using Effortly.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

// Load environment-specific configuration
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure OpenAPI/Swagger for Scalar
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, effortlyDbContext, cancellationToken) =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "Effortly API",
            Version = "v1",
            Description = "API documentation for the EffortlyFit application.",
        };
        return Task.CompletedTask;
    });
});

// Add Infrastructure services
builder.Services.AddInfrastructure(builder.Configuration);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentCors",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Health Checks
builder.Services.AddHealthChecks()
    .AddDbContextCheck<EffortlyDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Map OpenAPI endpoint
    app.MapOpenApi();

    // Use Scalar for API documentation
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Effortly API")
            .WithTheme(ScalarTheme.Purple)
            .WithDarkModeToggle(true)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
            .WithEndpointPrefix("/scalar/{documentName}");
    });
    app.UseCors("DevelopmentCors");
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

// Apply pending migrations automatically in development
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<EffortlyDbContext>();
    if (dbContext.Database.GetPendingMigrations().Any())
    {
        Log.Information("Applying pending migrations...");
        dbContext.Database.Migrate();
    }
}

// Redirect root to API docs
app.MapGet("/", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();

Log.Information("Starting EffortlyFit API");
Log.Information("API Documentation available at: https://localhost:7159/scalar/v1");
app.Run();