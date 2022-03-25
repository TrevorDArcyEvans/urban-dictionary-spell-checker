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
    var retval = new Dictionary<string, IEnumerable<Definition>>();
    var words = RemoveSpecialCharacters(text).Split(' ');
    var wordsPhrases = words.Distinct().Concat(GetPhrases(words));

    foreach (var wordsPhrase in wordsPhrases)
    {
      var defs = await _database.GetDefinitions(wordsPhrase);
      retval.Add(wordsPhrase, defs);
    }

    return retval;
  }

  private static IEnumerable<string> GetPhrases(string[] words, int depth = 2)
  {
    var retval = new List<string>();
    for (var i = 0; i < words.Length - depth + 1; i++)
    {
      var phrase = $"{words[i]} {words[i + 1]}";
      retval.Add(phrase);
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
