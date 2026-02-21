namespace ZooMonkeys.Domain.Monkeys;

public enum Temperament
{
    Playful,
    Calm,
    Aggressive,
    Shy,
    Curious
}

// ----------------------
// EVENTS
// ----------------------
public interface IMonkeyEvent { }

public record MonkeyRegistered(Guid Id, string Name, int Age, Temperament Temperament) : IMonkeyEvent;
public record MonkeyDeleted(Guid Id) : IMonkeyEvent;

// ----------------------
// COMMANDS
// ----------------------
public interface IMonkeyCommand { }

public record RegisterMonkey(Guid Id, string Name, int Age, Temperament Temperament) : IMonkeyCommand;
public record DeleteMonkey(Guid Id) : IMonkeyCommand;

// ----------------------
// STATE
// ----------------------
public record MonkeyState(Guid Id, string Name, int Age, Temperament Temperament, bool IsDeleted)
{
    public static MonkeyState Initial => new(Guid.Empty, string.Empty, 0, Temperament.Playful, true);
}

// ----------------------
// PURE FUNCTIONS (BEHAVIOR)
// ----------------------
public static class MonkeyBehavior
{
    /// <summary>
    /// Processes a command against the current state and returns a new event.
    /// Pure Function: No I/O, no side effects.
    /// </summary>
    public static IMonkeyEvent Process(RegisterMonkey cmd, MonkeyState currentState)
    {
        if (currentState.Id != Guid.Empty && !currentState.IsDeleted)
        {
            throw new InvalidOperationException($"Monkey '{cmd.Name}' is already registered or active.");
        }
        
        if (string.IsNullOrWhiteSpace(cmd.Name))
        {
            throw new ArgumentException("Name cannot be empty.", nameof(cmd.Name));
        }

        if (cmd.Age < 0)
        {
            throw new ArgumentException("Age cannot be negative.", nameof(cmd.Age));
        }

        return new MonkeyRegistered(cmd.Id, cmd.Name, cmd.Age, cmd.Temperament);
    }

    /// <summary>
    /// Processes a delete command.
    /// </summary>
    public static IMonkeyEvent Process(DeleteMonkey cmd, MonkeyState currentState)
    {
        if (currentState.IsDeleted || currentState.Id == Guid.Empty)
        {
            throw new InvalidOperationException("Monkey does not exist or is already deleted.");
        }

        if (currentState.Id != cmd.Id)
        {
            throw new InvalidOperationException("Command ID does not match current state ID.");
        }

        return new MonkeyDeleted(cmd.Id);
    }
    
    /// <summary>
    /// Evolves the state based on an event. Used by Projections/Event Sourcing.
    /// </summary>
    public static MonkeyState Apply(IMonkeyEvent @event, MonkeyState state) =>
        @event switch
        {
            MonkeyRegistered e => new MonkeyState(e.Id, e.Name, e.Age, e.Temperament, false),
            MonkeyDeleted _ => state with { IsDeleted = true },
            _ => state
        };
}
