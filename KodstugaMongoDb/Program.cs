// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.Marshalling;
using DataAccess;
using DataAccess.Entities;
using EfDataAccessTEst;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

Console.WriteLine("Hello, World!");


var animal = new Animal
{
    Id = Guid.NewGuid(),
    Name = "Fluffy",
    Type = "Cat",
    Stuffs = [new Stuff { Name = "thing" }]
};


var mongoClient = new MongoClient("mongodb://localhost:27017");

var dbContextOptions =
    new DbContextOptionsBuilder<AppDbContext>().UseMongoDB(mongoClient, "EfCoreDb");


using (var context = new AppDbContext(dbContextOptions.Options))
{
    context.Animals.Add(animal);

    context.SaveChanges();
}


Console.ReadKey();