using Fiap_Aula11_MinimalAPI;
using Microsoft.AspNetCore.Authorization;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISayHello, SayHello>();
builder.Services.AddSingleton<SayHelloProgram>(new SayHelloProgram());

// Add services to the container.
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

//Aqui estamos adicionando um middleware
app.Use(async (context, next) => 
{
    if (!context.Request.Headers.TryGetValue("X-API-KEY", out var apiKey) &&
        context.GetEndpoint()?.Metadata.GetMetadata<AllowAnonymousAttribute>() is null)
    {
        await context.Response.WriteAsync("Não foi possível localizar a API Key");
        return;
    }

    await next.Invoke();
});

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var weatherGroup = app.MapGroup("/Weather");
var othersGroup = app.MapGroup("/Others");

//Código padrão weather
weatherGroup.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return Results.Ok(forecast);
})
.WithName("GetWeatherForecast")
.WithTags("Weather")
.AllowAnonymous()
.WithOpenApi();

weatherGroup.MapGet("/weatherforecast2", WheaterForecastProcess)
.WithName("GetWeatherForecast2")
.WithTags("Weather")
.AllowAnonymous()
.WithOpenApi();

//Teste para separação de grupo
othersGroup.MapGet("/sayHello", (ISayHello sayHello) =>
{
    return Results.Ok(sayHello.BoasVindas());
})
.WithName("SayHello")
.WithTags("Other")
.AllowAnonymous()
.WithOpenApi();

othersGroup.MapGet("/sayHelloProgram", (SayHelloProgram sayHelloProgram) =>
{
    return Results.Ok(sayHelloProgram.BoasVindas());
})
.WithName("SayHelloProgram")
.WithTags("Other")
.WithOpenApi();

app.Run();

static IResult WheaterForecastProcess()
{
    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return TypedResults.Ok(forecast);
}

public class SayHelloProgram()
{
    public string BoasVindas()
    {
        return "Boas Vindas";
    }
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
