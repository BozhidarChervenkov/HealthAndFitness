namespace HealthAndFitness.ViewModels.Exercises
{
    public class ExerciseListViewModel
    {
        public IEnumerable<ExerciseInListViewModel> Exercises { get; set; }

        public string MuscleGroupName { get; set; }
    }
}
