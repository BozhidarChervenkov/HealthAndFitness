namespace HealthAndFitness.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(VideoUrlMinLenght)]
        [MaxLength(VideoUrlMaxLenght)]
        public string Url { get; set; }
    }
}
