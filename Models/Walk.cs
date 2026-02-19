namespace WalkApp.Models
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Length { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        // Nav props (EF Core konvansiyonuyla eşleşecek şekilde)
        public Region Region { get; set; } = null!;
        public Difficulty Difficulty { get; set; } = null!;
    }
}
