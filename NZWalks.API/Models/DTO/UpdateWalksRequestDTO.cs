using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateWalksRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length allowed is 100")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Maximum length allowed is 1000")]
        public string Description { get; set; }

        [Required]
        [Range(0, 50)]
        public double LengthInKms { get; set; }

        public string? WalkImgUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }

    }
}
