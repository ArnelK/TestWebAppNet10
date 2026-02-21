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
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowFrontend");

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