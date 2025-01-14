using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Entities;

public class Animal
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public List<Stuff> Stuffs { get; set; }
}