using System.ComponentModel.DataAnnotations;

namespace lostinthewoods.Models
{
    public class Trail : BaseEntity {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage="Enter name for the trail")]
        public string Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description should be more than 10")]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter numeric for length")]
        public double Length { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter numeric for Elevation Gain")]
        public double ElevationGain { get; set; }
        
        [Required]
        [RegularExpression("^(\-?\d+(\.\d+)?),\s*(\-?\d+(\.\d+)?)$", ErrorMessage="Invalid Longtitude")]
        public double Longtitude { get; set; }

        [Required]
        [RegularExpression("^(\-?\d+(\.\d+)?),\s*(\-?\d+(\.\d+)?)$")]
        public double Latitude { get; set; }

    }
}