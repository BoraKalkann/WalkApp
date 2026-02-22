namespace WalkApp.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Length { get; set; }
        public string? WalkImageUrl { get; set; }
        
        public RegionDTO region { get; set; } = null!;
        public DifficultyDTO difficulty { get; set; } = null!;
    }
}
