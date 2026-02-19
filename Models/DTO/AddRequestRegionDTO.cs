namespace WalkApp.Models.DTO
{
    public class AddRequestRegionDTO
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? RegionImageUrl { get; set; }
    }
}
