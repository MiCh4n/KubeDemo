using System;
using System.Collections.Generic;
using System.Linq;
using Editor.API.Dtos;
using Editor.API.Entities;
using Editor.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Editor.API.Controllers
{
    [ApiController]
    [Route("persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsRepository repository;
        
        public PersonsController(IPersonsRepository repository)
        {
            this.repository = repository;
        }
        
        // GET /persons
        [HttpGet]
        public IEnumerable<PersonDto> GetPersons()
        {
            var persons = repository.GetPersons().Select(person => person.AsDto());
            return persons;
        }

        // GET /persons/{id}
        [HttpGet("{id}")]
        public ActionResult<PersonDto> GetPerson(Guid id)
        {
            var person = repository.GetPerson(id);

            if (person is null)
            {
                return NotFound();
            }

            return person.AsDto();
        }

        // POST /persons
        [HttpPost]
        public ActionResult<PersonDto> CreatePerson(CreatePersonDto personDto)
        {
            Person person = new()
            {
                Id = Guid.NewGuid(),
                Name = personDto.Name,
                Surname = personDto.Surname,
                Age = personDto.Age,
                DateAdd = DateTime.Now
            };

            repository.CreatePerson(person);

            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person.AsDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult Updateperson(Guid id, UpdatePersonDto personDto)
        {
            var existingPerson = repository.GetPerson(id);

            if (existingPerson is null)
            {
                return NotFound();
            }

            Person updatedPerson = existingPerson with
            {
                Name = personDto.Name,
                Surname = personDto.Surname,
                Age = personDto.Age
            };

            repository.UpdatePerson(updatedPerson);

            return NoContent();
        }

        // DELETE /persons/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(Guid id)
        {
            var existingPerson = repository.GetPerson(id);

            if (existingPerson is null)
            {
                return NotFound();
            }

            repository.DeletePerson(id);

            return NoContent();
        }
    }
}