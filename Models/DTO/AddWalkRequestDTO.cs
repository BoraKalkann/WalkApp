namespace WalkApp.Models.DTO
{
    public class AddWalkRequestDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Length { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
