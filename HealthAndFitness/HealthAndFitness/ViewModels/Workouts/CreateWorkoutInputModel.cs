namespace HealthAndFitness.ViewModels.Workouts
{
    using Microsoft.Build.Framework;

    public class CreateWorkoutInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
