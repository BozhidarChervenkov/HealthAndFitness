namespace HealthAndFitness.ViewModels.Exercises
{
    using System.ComponentModel.DataAnnotations;
    
    using HealthAndFitness.Models;

    public class CreateExerciseInputModel
    {
        public CreateExerciseInputModel()
        {
            this.Images = new HashSet<Image>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int MuscleGroupId { get; set; }

        [Required]
        public string VideoURL { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}

