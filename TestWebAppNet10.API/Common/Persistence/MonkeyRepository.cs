using TestWebAppNet10.API.Common.Domain.Monkeys;

namespace TestWebAppNet10.API.Common.Persistence;

public class MonkeyRepository
{
    private readonly List<Monkey> _monkeys =
    [
        Monkey.Create("George", 5, Temperament.Playful),
        Monkey.Create("Charlie", 3, Temperament.Curious),
        Monkey.Create("Luna", 7, Temperament.Calm)
    ];

    public void Create(Monkey monkey)
    {
        _monkeys.Add(monkey);
    }

    public IReadOnlyList<Monkey> GetAll()
    {
        return _monkeys.AsReadOnly();
    }

    public bool Delete(Guid id)
    {
        var monkey = GetById(id);
        if (monkey is null) return false;

        _monkeys.Remove(monkey);
        return true;
    }

    public Monkey? GetById(Guid id)
    {
        return _monkeys.FirstOrDefault(m => m.Id == id);
    }
}