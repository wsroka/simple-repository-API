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
         
        StudentRepository studentRepository = new StudentRepository();
        [HttpPost("DajMnieUsera")]
        public IActionResult AddData([FromHeader] Student dupa)
        {
            studentRepository.Database_Insert(dupa);
            return Ok();
        }

    }
}
