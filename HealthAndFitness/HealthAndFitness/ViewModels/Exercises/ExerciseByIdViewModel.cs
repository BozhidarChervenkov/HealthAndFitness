namespace HealthAndFitness.ViewModels.Exercises
{
    using HealthAndFitness.Models;

    public class ExerciseByIdViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MuscleGroupName { get; set; }

        public string EmbeddedVideoCode { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public string CurrentUserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Image> Images { get; set; }

        // Add exercise to workout view model:

        public int WorkoutId { get; set; }
    }
}
