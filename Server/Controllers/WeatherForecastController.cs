using AppNetS22021.Server.Models;
using AppNetS22021.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppNetS22021.Server.Controllers
{
    

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        [Route("api/EjecutarConsulta")]
        public int EjecutarConsulta()
        {
            int resultado = 0;
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                Facultad es = new Facultad()
                {
                    Nombre = "Facultad de Ciencias y Tecnologias"
                };
                db.Facultad.Add(es);
                db.SaveChanges();
            }
            return resultado;
        }



        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
