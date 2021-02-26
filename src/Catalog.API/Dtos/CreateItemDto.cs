using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public string Name { get; init; }
        
        [Required]
        public string Description { get; init; }

        [Required]
        [Range(1, 9999)]
        public decimal Price { get; init; }
    }
}