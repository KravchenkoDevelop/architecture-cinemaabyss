using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace events_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly RandomEventGenerator _generator;

    public EventsController(RandomEventGenerator generator)
    {
        _generator = generator;
    }

    [HttpGet("movie")]
    public IActionResult PublishMovieEvent()
    {
        var ev = _generator.Generate("movie");
        return Ok(ev);
    }

    [HttpGet("user")]
    public IActionResult PublishUserEvent()
    {
        var ev = _generator.Generate("user");
        return Ok(ev);
    }

    [HttpGet("payment")]
    public IActionResult PublishPaymentEvent()
    {
        var ev = _generator.Generate("payment");
        return Ok(ev);
    }
    }
}
