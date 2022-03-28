namespace urban_dictionary_spell_checker.Examples;

using Swashbuckle.AspNetCore.Filters;

public sealed class TextExample : IExamplesProvider<string>
{
  public string GetExamples()
  {
    return "No shit, I didn't mean to dis ya, brah!";
  }
}
