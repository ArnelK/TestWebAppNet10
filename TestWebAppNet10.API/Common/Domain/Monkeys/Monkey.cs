namespace TestWebAppNet10.API.Common.Domain.Monkeys;

public class Monkey
{
    private Monkey()
    {
    }

    public Guid Id { get; private set; }
    public int Age { get; private set; }
    public string Name { get; private set; } = null!;
    public Temperament Temperament { get; private set; }

    public static Monkey Create(string name, int age, Temperament temperament)
    {
        return new Monkey
        {
            Id = Guid.NewGuid(),
            Name = name,
            Age = age,
            Temperament = temperament
        };
    }
}

public enum Temperament
{
    Playful,
    Calm,
    Aggressive,
    Shy,
    Curious
}