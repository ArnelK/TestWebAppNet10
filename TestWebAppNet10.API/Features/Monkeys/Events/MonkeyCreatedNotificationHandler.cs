using FastEndpoints;

namespace TestWebAppNet10.API.Features.Monkeys.Events;

public class MonkeyCreatedNotificationHandler(ILogger<MonkeyCreatedNotificationHandler> logger)
    : IEventHandler<MonkeyCreatedEvent>
{
    public Task HandleAsync(MonkeyCreatedEvent eventModel, CancellationToken ct)
    {
        logger.LogInformation(
            "📱 Sending push notification: New monkey '{MonkeyName}' added!",
            eventModel.MonkeyName);

        // In real app, you'd call a notification service here
        return Task.CompletedTask;
    }
}