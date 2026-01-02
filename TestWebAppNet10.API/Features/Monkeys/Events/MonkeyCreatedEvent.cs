using FastEndpoints;
using TestWebAppNet10.API.Common.Persistence;

namespace TestWebAppNet10.API.Features.Monkeys.Events;

public record MonkeyCreatedEvent(string MonkeyName, int MonkeyAge) : IEvent;

public class MonkeyCreatedEventHandler(
    ILogger<MonkeyCreatedEventHandler> logger,
    MonkeyRepository repository)
    : IEventHandler<MonkeyCreatedEvent>
{
    public Task HandleAsync(MonkeyCreatedEvent eventModel, CancellationToken ct)
    {
        var remainingCapacity = 5 - repository.GetAll().Count;

        logger.LogInformation(
            "Monkey '{MonkeyName}' (age {MonkeyAge}) has been created. Zoo capacity has decreased to {RemainingCapacity} available spots.",
            eventModel.MonkeyName,
            eventModel.MonkeyAge,
            remainingCapacity);

        return Task.CompletedTask;
    }
}