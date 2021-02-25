using System;
using System.Collections.Generic;
using Editor.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Editor.API.Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        private const string DbName = "editor";
        private const string CollectionName = "persons";
        private readonly IMongoCollection<Person> personsCollection;
        private readonly FilterDefinitionBuilder<Person> filterBuilder = Builders<Person>.Filter;
        
        public PersonsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DbName);
            personsCollection = database.GetCollection<Person>(CollectionName);
        }

        public void CreatePerson(Person person)
        {
            personsCollection.InsertOne(person);
        }

        public void DeletePerson(Guid id)
        {
            var filter = filterBuilder.Eq(person => person.Id, id);
            personsCollection.DeleteOne(filter);
        }

        public Person GetPerson(Guid id)
        {
            var filter = filterBuilder.Eq(person => person.Id, id);
            return personsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Person> GetPersons()
        {
            return personsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdatePerson(Person person)
        {
            var filter = filterBuilder.Eq(existingPerson => existingPerson.Id, person.Id);
            personsCollection.ReplaceOne(filter, person);
        }
    }
}