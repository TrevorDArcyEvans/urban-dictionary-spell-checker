namespace urban_dictionary_spell_checker.Database;

using Models;

public interface IDatabase
{
  Task<IEnumerable<Definition>> GetDefinitions(string words);
}
