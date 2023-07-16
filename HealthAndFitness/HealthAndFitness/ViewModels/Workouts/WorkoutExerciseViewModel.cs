namespace HealthAndFitness.ViewModels.Workouts
{
    public class WorkoutExerciseViewModel
    {
        public int Id { get; set; }

        public int WorkoutId { get; set; }

        public string Name { get; set; }

        public string AddedByUsername { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
