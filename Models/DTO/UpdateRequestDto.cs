using System.ComponentModel.DataAnnotations;

namespace WalkApp.Models.DTO
{
    public class UpdateRequestDto
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; } = default!;
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string Code { get; set; } = default!;
        public string? RegionImageUrl { get; set; }
    }
}
