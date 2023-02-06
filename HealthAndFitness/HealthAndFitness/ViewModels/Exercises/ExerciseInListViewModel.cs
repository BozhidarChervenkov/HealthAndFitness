namespace HealthAndFitness.ViewModels.Exercises
{
    using HealthAndFitness.Models;

    public class ExerciseInListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MuscleGroupId { get; set; }

        public string AddedByUsername { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImageUrl { get; set; }
    }
}
