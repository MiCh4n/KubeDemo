using System.ComponentModel.DataAnnotations;

namespace Editor.API.Dtos
{
    public record CreatePersonDto
    {
        [Required]
        public string Name { get; init; }
        
        [Required]
        public string Surname { get; init; }

        [Required]
        [Range(18, 120)]
        public int Age { get; init; }
    }
}