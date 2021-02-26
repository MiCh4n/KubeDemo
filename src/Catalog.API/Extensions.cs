using Catalog.API.Dtos;
using Catalog.API.Entities;

namespace Catalog.API
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                DateAdd = item.DateAdd
            };
        }
    }
}