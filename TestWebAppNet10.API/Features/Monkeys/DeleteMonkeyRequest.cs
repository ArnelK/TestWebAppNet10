using FastEndpoints;
using FluentValidation;
using TestWebAppNet10.API.Common.Persistence;

namespace TestWebAppNet10.API.Features.Monkeys;

public record DeleteMonkeyRequest(Guid Id);

public class DeleteMonkeyEndpoint(MonkeyRepository repository)
    : Endpoint<DeleteMonkeyRequest>
{
    public override void Configure()
    {
        Delete("/{Id}");
        Group<MonkeyGroup>();
    }

    public override async Task HandleAsync(DeleteMonkeyRequest req, CancellationToken ct)
    {
        var success = repository.Delete(req.Id);

        if (!success)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await Send.NoContentAsync(ct);
    }

    public class DeleteMonkeyValidator : Validator<DeleteMonkeyRequest>
    {
        public DeleteMonkeyValidator()
        {
            RuleFor(request => request.Id)
                .Must(id => Guid.TryParse(id.ToString(), out id)).WithMessage("Id must be a valid guid");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        }
    }

    public class DeleteMonkeySummary : Summary<DeleteMonkeyEndpoint>
    {
        public DeleteMonkeySummary()
        {
            Summary = "Delete a monkey by id";
            Description = "Deletes a monkey from the collection by id";

            Response(204, "Monkey deleted successfully");
            Response(404, "Monkey not found to delete");
            Response(400, "Invalid request data");
            Response(500, "Internal server error");

            ExampleRequest = new DeleteMonkeyRequest(Guid.NewGuid());
        }
    }
}