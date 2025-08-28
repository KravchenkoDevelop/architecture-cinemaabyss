var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<RandomEventGenerator>();

var app = builder.Build();

app.MapControllers();

// health check
app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

app.Run();