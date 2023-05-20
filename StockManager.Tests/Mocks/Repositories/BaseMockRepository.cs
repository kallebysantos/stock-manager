using System.Reflection;
using System.Text.Json;

namespace StockManager.Tests.Mocks.Repositories;

public abstract record BaseMockRepository<TEntity>
{
    public HashSet<TEntity>? Entities { get; set; } = new();

    public async Task PopulateFromJson(string file)
    {
        var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Mocks/Data", file);
        var jsonFile = File.OpenRead(Path.ChangeExtension(filepath, "json"));

        Entities = await JsonSerializer.DeserializeAsync<HashSet<TEntity>>(jsonFile);
    }
}