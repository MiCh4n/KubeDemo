using System;
using System.Collections.Generic;
using Editor.API.Entities;

namespace Editor.API.Repositories
{
    public interface IPersonsRepository
    {
        Person GetPerson(Guid id);
        IEnumerable<Person> GetPersons();
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Guid id);
    }
}