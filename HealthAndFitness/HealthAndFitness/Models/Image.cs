namespace HealthAndFitness.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ImageUrlMinLenght)]
        [MaxLength(ImageUrlMaxLenght)]
        public string Url { get; set; }

        public int? ExerciseId { get; set; }

        public Exercise Exercise { get; set; }
    }
}
