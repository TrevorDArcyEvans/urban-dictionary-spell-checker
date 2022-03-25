namespace urban_dictionary_spell_checker.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Database;

[ApiController]
[Route("[controller]")]
public sealed class DefinitionsController : ControllerBase
{
  private readonly IDatabase _database;

  public DefinitionsController(IDatabase database)
  {
    _database = database;
  }

  [HttpPost]
  public async Task<IEnumerable<Definition>> Post([FromBody] string text)
  {
    return await _database.GetDefinitions(text);
  }
}
