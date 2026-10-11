using Microsoft.AspNetCore.Mvc;
using weatherApp.Services;

namespace weatherApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{ciudad}")]
        public async Task<IActionResult> Get(string ciudad)
        {
            try
            {
                var clima = await _weatherService.ObtenerClimaAsycn(ciudad);
                return Ok(clima);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}