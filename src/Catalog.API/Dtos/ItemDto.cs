using System;

namespace Catalog.API.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        
        public string Name { get; init; }
        
        public string Description { get; init; }
        
        public decimal Price { get; init; }
        
        public DateTime DateAdd { get; init; }
    }
}