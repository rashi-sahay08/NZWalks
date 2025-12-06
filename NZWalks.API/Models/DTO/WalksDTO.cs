namespace NZWalks.API.Models.DTO
{
    public class WalksDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKms { get; set; }

        public string? WalkImgUrl { get; set; }

        public RegionDTO Region { get; set; }

        public DifficultyDTO Difficulty { get; set; }
    }
}
