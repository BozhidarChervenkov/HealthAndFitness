using HealthAndFitness.Models;
namespace HealthAndFitness.ViewModels.Exercises
{
    public class ExerciseListViewModel
    {
        public IEnumerable<ExerciseInListViewModel> Exercises { get; set; }

        public string MuscleGroupName { get; set; }

        // Add exercise to workout view model:

        public int WorkoutId { get; set; }

        public int ExerciseId { get; set; }
    }
}
