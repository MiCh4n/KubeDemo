using Editor.API.Dtos;
using Editor.API.Entities;

namespace Editor.API
{
    public static class Extensions
    {
        public static PersonDto AsDto(this Person person)
        {
            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Age = person.Age,
                DateAdd = person.DateAdd
            };
        }
    }
}