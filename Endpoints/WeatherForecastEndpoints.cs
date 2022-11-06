using AppTest7.Models;
using AppTest7.Data;
using Microsoft.EntityFrameworkCore;

namespace AppTest7.Endpoints;
public static class WeatherForecastEndpoints
{
    public static WebApplication MapWeatherForecastEndpoints(this WebApplication app)
    {
        _ = app.MapGet("/weatherforecast", () =>
        {
            var summaries = new[] {
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
            return forecast;
        })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        return app;
    }
}