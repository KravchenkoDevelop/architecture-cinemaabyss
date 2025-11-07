using Events.API;
using Confluent.Kafka;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Kafka producer
builder.Services.AddSingleton<IProducer<string, string>>(_ =>
{
    var brokers = Environment.GetEnvironmentVariable("KAFKA_BROKERS") ?? "localhost:9092";
    var config = new ProducerConfig { BootstrapServers = brokers };
    return new ProducerBuilder<string, string>(config).Build();
});


var app = builder.Build();
app.MapControllers();
app.Run();
