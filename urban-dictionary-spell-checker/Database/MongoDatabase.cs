namespace urban_dictionary_spell_checker.Database;

using Models;
using MongoDB.Driver;

public sealed class MongoDatabase : IDatabase
{
  private readonly IMongoClient _client;

  public MongoDatabase(IMongoClient client)
  {
    _client = client;
  }

  public async Task<IEnumerable<Definition>> GetDefinitions(string phrase, int limit = 2)
  {
    var lcPhrase = phrase.ToLowerInvariant();
    var defs = await _client
      .GetDatabase("urban-dictionary")
      .GetCollection<Definition>("words")
      .Find(
        Builders<Definition>.Filter
          .Where(x => x.lowercase_word == lcPhrase))
      .SortByDescending(x => x.thumbs_up)
      .Limit(limit)
      .ToListAsync();
    return defs;
  }
}
