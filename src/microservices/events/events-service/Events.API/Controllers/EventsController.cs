using Confluent.Kafka;
using Events.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Events.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IProducer<string, string> _producer;

    public EventsController(IProducer<string, string> producer)
    {
        _producer = producer;
    }


    [HttpGet]
    [Route("health")]
    public IActionResult Get() => Ok(new { status = true });

    [HttpPost("movie")]
    public async Task<IActionResult> PublishMovieEvent([FromBody] Movie movieEvent)
    {
        return await PublishAsync(
            movieEvent,
            topic: "movie-events",
            category: "movie",
            idGenerator: e => $"movie-{e.MovieId}-{e.Action}");
    }

    [HttpPost("user")]
    public async Task<IActionResult> PublishUserEvent([FromBody] UserEvent userEvent)
    {
        return await PublishAsync(
            userEvent,
            topic: "user-events",
            category: "user",
            idGenerator: e => $"user-{e.UserId}-{e.Action}");
    }

    [HttpPost("payment")]
    public async Task<IActionResult> PublishPaymentEvent([FromBody] Payment paymentEvent)
    {
        return await PublishAsync(
            paymentEvent,
            topic: "payment-events",
            category: "payment",
            idGenerator: e => $"payment-{e.PaymentId}");
    }

    private async Task<IActionResult> PublishAsync<TEvent>(
        TEvent data,
        string topic,
        string category,
        Func<TEvent, string> idGenerator)
    {
        var evt = new Event(idGenerator(data),
                            category,
                            DateTime.UtcNow,
                            data);

        var serialized = JsonSerializer.Serialize(evt);

        var result = await _producer.ProduceAsync(
            topic,
            new Message<string, string>
            {
                Key = evt.Id,
                Value = serialized
            });

        var response = new Response("success", result.Partition.Value, result.Offset.Value, evt);
        return Created(string.Empty, response);
    }
}


