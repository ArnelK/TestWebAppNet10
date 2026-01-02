using FastEndpoints;

namespace TestWebAppNet10.API.Features.Monkeys.Commands;

public record EmailZooCommand(string MonkeyName, int MonkeyAge) : ICommand;

public class EmailZooCommandHandler(ILogger<EmailZooCommandHandler> logger) : ICommandHandler<EmailZooCommand>
{
    public Task ExecuteAsync(EmailZooCommand command, CancellationToken ct)
    {
        const string to = "admin@example.com";
        const string subject = "New Monkey Added";
        var body =
            $"A new monkey named {command.MonkeyName} (age {command.MonkeyAge}) has been added to the collection.";

        logger.LogInformation(
            "Email sent to zoo - To: {To}, Subject: {Subject}, Body: {Body}",
            to,
            subject,
            body);

        return Task.CompletedTask;
    }
}