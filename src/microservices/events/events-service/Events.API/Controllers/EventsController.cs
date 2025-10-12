using Confluent.Kafka;
using Events.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Events.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{

    [HttpGet]
    [Route("health")]
    public IActionResult Get() => Ok(new { status = true });

    [HttpPost("movie")]
    public async Task<IActionResult> CreateMovieEvent([FromBody] Event eventJson, IProducer<string,string> producer)
    {
       var result = ProcessAndDeliverMessage<Event>(producer, eventJson);

        return Ok(result);
    }

    [HttpPost("user")]
    public async Task<IActionResult> CreateUserEvent([FromBody] string? userEventJson, IProducer<string,string> producer)
    {
        
        return Ok();
    }

    [HttpPost("payment")]
    public async Task<IActionResult> CreatePaymentEvent([FromBody] string? paymentEventJson, IProducer<string,string> producer)
    {
       

        return Ok();
    }

    private DeliveryResult<string, string> ProcessAndDeliverMessage<T>(IProducer<string, string> producer, T type)
    {
        var message = new Message<string, string>();

        return null;
    }

}
