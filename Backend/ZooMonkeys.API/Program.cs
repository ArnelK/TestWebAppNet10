using FastEndpoints;
using FastEndpoints.Swagger;
using Marten;
using Marten.Events.Projections;
using ZooMonkeys.API.Projections;
using System.Text.Json.Serialization;
using JasperFx.CodeGeneration;
using ZooMonkeys.Domain.Monkeys;
using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

builder.Services.AddMarten(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("DefaultConnection is not configured.");
    }
    
    options.Connection(connectionString);
    options.AutoCreateSchemaObjects = JasperFx.AutoCreate.All;
    options.GeneratedCodeMode = JasperFx.CodeGeneration.TypeLoadMode.Static;
    
    options.UseSystemTextJsonForSerialization(
        Weasel.Core.EnumStorage.AsString,
        Marten.Casing.CamelCase,
        serializerOptions =>
        {
            serializerOptions.TypeInfoResolver = AppJsonSerializerContext.Default;
        });

    options.Projections.Add<MonkeyStateProjection>(JasperFx.Events.Projections.ProjectionLifecycle.Inline);
}).UseLightweightSessions();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseFastEndpoints()
   .UseSwaggerGen();

app.Run();

[JsonSerializable(typeof(MonkeyRegistered))]
[JsonSerializable(typeof(MonkeyDeleted))]
[JsonSerializable(typeof(MonkeyState))]
[JsonSerializable(typeof(ZooMonkeys.API.Features.Monkeys.CreateMonkeyRequest))]
[JsonSerializable(typeof(ZooMonkeys.API.Features.Monkeys.CreateMonkeyResponse))]
[JsonSerializable(typeof(ZooMonkeys.API.Features.Monkeys.GetMonkeysResponse))]
[JsonSerializable(typeof(ZooMonkeys.API.Features.Monkeys.GetMonkeyRequest))]
[JsonSerializable(typeof(ZooMonkeys.API.Features.Monkeys.DeleteMonkeyRequest))]
[JsonSerializable(typeof(IEnumerable<MonkeyState>))]
[JsonSerializable(typeof(IReadOnlyList<MonkeyState>))]
[JsonSerializable(typeof(List<MonkeyState>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
