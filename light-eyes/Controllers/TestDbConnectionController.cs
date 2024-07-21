using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace light_eyes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDbConnectionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TestDbConnectionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    return Ok("Connection successful");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }
    }
}
