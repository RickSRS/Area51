using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_JWT.ViewModel;

namespace WebAPI_JWT.Controller;

[ApiController]
[Route("[controller]")]
public class WeatherForecast : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public WeatherForecastViewModel[] GetWeatherForecast()
    {
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        }).ToArray();
    }
}