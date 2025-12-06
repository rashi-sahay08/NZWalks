using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class RegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code must have a minimum length of 3")]
        [MaxLength(3, ErrorMessage = "Code must have a maximum length of 3")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name must have maximum 100 characters")]
        public string Name { get; set; }

        public string? RegionImgUrl { get; set; }
    }
}
