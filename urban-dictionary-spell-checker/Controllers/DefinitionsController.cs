namespace urban_dictionary_spell_checker.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Logic;

[ApiController]
[Route("[controller]")]
public sealed class DefinitionsController : ControllerBase
{
  private readonly IDefinitionsFinder _definitionsFinder;

  public DefinitionsController(IDefinitionsFinder definitionsFinder)
  {
    _definitionsFinder = definitionsFinder;
  }

  [HttpPost]
  public async Task<IDictionary<string, IEnumerable<Definition>>> Post([FromBody] string text)
  {
    return await _definitionsFinder.GetDefinitions(text);
  }
}
