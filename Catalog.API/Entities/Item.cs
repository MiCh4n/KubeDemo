using System;

namespace Catalog.API.Entities
{
    public record Item
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public DateTime DateAdd { get; init; }
    }
}