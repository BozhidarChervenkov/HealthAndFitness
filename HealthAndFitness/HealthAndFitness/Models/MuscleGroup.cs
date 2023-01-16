namespace HealthAndFitness.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class MuscleGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(MuscleGroupNameMinLenght)]
        [MaxLength(MuscleGroupNameMaxLenght)]
        public string Name { get; set; }
    }
}
