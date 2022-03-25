namespace urban_dictionary_spell_checker.Logic;

using System.Text;
using Database;
using Models;

public sealed class DefinitionsFinder : IDefinitionsFinder
{
  private readonly IDatabase _database;

  public DefinitionsFinder(IDatabase database)
  {
    _database = database;
  }

  public async Task<IDictionary<string, IEnumerable<Definition>>> GetDefinitions(string text)
  {
    var cleanTxt = RemoveSpecialCharacters(text);
    var words = cleanTxt
      .Split(' ')
      .Distinct();
    var retval = new Dictionary<string, IEnumerable<Definition>>();
    foreach (var word in words)
    {
      var defs = await _database.GetDefinitions(word);
      retval.Add(word, defs);
    }

    return retval;
  }

  private static string RemoveSpecialCharacters(string str)
  {
    var sb = new StringBuilder();
    foreach (var c in str.Where(c => char.IsLetter(c) || c is '\'' or ' '))
    {
      sb.Append(c);
    }

    return sb.ToString();
  }
}
