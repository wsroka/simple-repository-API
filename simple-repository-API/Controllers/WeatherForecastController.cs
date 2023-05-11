using Microsoft.AspNetCore.Mvc;
using simple_repository_API.Models;

namespace simple_repository_API.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("dejMniecOs")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("obojetnie")]
        public List<Student> Get2([FromBody] Student dupa)
        {
            return database_Connection.Database_connect();
        }
         
        Database_Connection database_Connection = new Database_Connection();
        [HttpPost("DajMnieUsera")]
        public IActionResult AddData([FromHeader] Student dupa)
        {
            database_Connection.Database_Insert(dupa);
            return Ok();
        }
        [HttpDelete("dupa")]
        public IActionResult Database_Delete(int studentId)
        {
            database_Connection.Database_Delete(studentId);
            return RedirectToAction("Index");
        }

    }
}
