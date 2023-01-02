using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Talabat.DTOS
{
    public class CustmuerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}
