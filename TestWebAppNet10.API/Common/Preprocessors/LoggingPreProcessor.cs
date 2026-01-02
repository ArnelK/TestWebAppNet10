using System.Text.Json;
using FastEndpoints;

namespace TestWebAppNet10.API.Common.Preprocessors;

public class LoggingPreProcessor<TRequest>(ILogger<LoggingPreProcessor<TRequest>> logger) : IGlobalPreProcessor
{
    public Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
    {
        var endpointName = context.HttpContext.GetEndpoint()?.DisplayName ?? "Unknown";
        var request = context.Request;

        var requestJson = request is not null
            ? JsonSerializer.Serialize(request, new JsonSerializerOptions { WriteIndented = false })
            : "No request body";

        logger.LogInformation(
            "Calling endpoint: {Endpoint} with request: {Request}",
            endpointName,
            requestJson);

        return Task.CompletedTask;
    }
}