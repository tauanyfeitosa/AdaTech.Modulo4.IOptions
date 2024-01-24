using Microsoft.AspNetCore.Mvc;
using AdaTech.Modulo4.IOptions.Services;

namespace AdaTech.Modulo4.IOptions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private readonly GreetingService _greetingService;

        public GreetingController(GreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet("greet/{name}")]
        public ActionResult<string> Greet(string name)
        {
            var message = _greetingService.Greet(name);
            return Ok(message);
        }

        [HttpGet("farewell/{name}")]
        public ActionResult<string> Farewell(string name)
        {
            var message = _greetingService.Farewell(name);
            return Ok(message);
        }
    }
}
