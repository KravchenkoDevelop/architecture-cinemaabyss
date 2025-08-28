using events_service;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllers();

// Swagger (для dotnet tool run swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Random event generator
builder.Services.AddSingleton<RandomEventGenerator>();

var app = builder.Build();

// Swagger middleware (можно оставить для runtime)
app.UseSwagger();
app.UseSwaggerUI();

// контроллеры
app.MapControllers();

// health check
app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

app.Run();
