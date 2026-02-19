namespace WalkApp.Models.DTO
{
    public class RegionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? RegionImageUrl { get; set; }
    }
}
    