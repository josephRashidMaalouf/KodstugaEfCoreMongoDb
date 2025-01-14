using DataAccess.Entities;
using MongoDB.Driver;

namespace DataAccess.Repositories;

public class AnimalRepository
{
    private readonly IMongoCollection<Animal> _collection;  
    private const string CollectionName = "Animals";
    private const string DatabaseName = "AnimalDb";
    private const string ConnectionString = "mongodb://localhost:27017";

    public AnimalRepository()
    {
        var client = new MongoClient(ConnectionString);
        var database = client.GetDatabase(DatabaseName);
        _collection = database.GetCollection<Animal>(CollectionName);
    }

    public async Task<IEnumerable<Animal>> GetAllAsync()
    {
        var filter = Builders<Animal>.Filter.Empty;
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<Animal>GetByNameAsync(string name)
    {
        var filter = Builders<Animal>.Filter.Eq(x => x.Name, name);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Animal> AddAsync(Animal animal)
    {
        await _collection.InsertOneAsync(animal);
        return animal;
    }

}