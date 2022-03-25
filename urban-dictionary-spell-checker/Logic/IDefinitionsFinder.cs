namespace urban_dictionary_spell_checker.Logic;

using Models;

public interface IDefinitionsFinder
{
  // [phrase] --> [definitions]
  Task<IDictionary<string, IEnumerable<Definition>>> GetDefinitions(string text);
}