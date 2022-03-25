using MongoDB.Driver;
using urban_dictionary_spell_checker.Database;
using urban_dictionary_spell_checker.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var serviceCollection = builder.Services;
serviceCollection.AddSingleton<IDatabase, MongoDatabase>();
serviceCollection.AddSingleton<IDefinitionsFinder, DefinitionsFinder>();
serviceCollection.AddSingleton(_ => new MongoClient(builder.Configuration.GetConnectionString("MongoDb")) as IMongoClient);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
