namespace urban_dictionary_spell_checker.Models;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public sealed class Definition
{
  [BsonId]
  public ObjectId id { get; init; }

  public string definition { get; init; }
  public string permalink { get; init; }
  public int thumbs_up { get; init; }
  public string author { get; init; }
  public string word { get; init; }
  public int defid { get; init; }
  public string current_vote { get; init; }
  public string example { get; init; }
  public int thumbs_down { get; init; }
  public string[] tags { get; init; }
  public string[] sounds { get; init; }
  public string lowercase_word { get; init; }
}
