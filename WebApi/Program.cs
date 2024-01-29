using Application.Interfaces;
using Application.Services;
using Infrastructure.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IOrganizationSummaryService, OrganizationSummaryService>();
builder.Services.AddScoped<IExternalDataProvider, ExternalDataProvider>();

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
app.MapHealthChecks("/health");

app.Run();

// Expose partial class for End-to-End Tests
public partial class Program { }