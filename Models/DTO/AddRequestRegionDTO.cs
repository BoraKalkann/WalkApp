using System.ComponentModel.DataAnnotations;

namespace WalkApp.Models.DTO
{
    public class AddRequestRegionDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;
        [Required]
        [MaxLength(3,ErrorMessage ="Must be 3 Maximum!")]
        [MinLength(3,ErrorMessage ="Must be 3 Minimum")]
        public string Code { get; set; } = default!;
        public string? RegionImageUrl { get; set; }
    }
}
