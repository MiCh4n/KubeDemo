using System;

namespace Editor.API.Entities
{
    public record Person
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public int Age { get; init; }
        public DateTime DateAdd { get; init; }
    }
}