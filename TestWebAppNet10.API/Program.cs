using FastEndpoints;
using FastEndpoints.Swagger;
using TestWebAppNet10.API.Common.Middleware;
using TestWebAppNet10.API.Common.Persistence;
using TestWebAppNet10.API.Common.Preprocessors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSingleton<MonkeyRepository>()
    .AddFastEndpoints()
    .SwaggerDocument()
    .AddCommandMiddleware(c =>
        c.Register(typeof(CommandLogger<,>)));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseFastEndpoints(c =>
    {
        c.Endpoints.Configurator = ep => { ep.PreProcessor<LoggingPreProcessor<object>>(Order.Before); };
    })
    .UseSwaggerGen();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();