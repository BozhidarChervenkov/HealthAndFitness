namespace HealthAndFitness.Services.Workouts
{
    using HealthAndFitness.ViewModels.Workouts;

    public interface IWorkoutService
    {
        Task<int> Create(CreateWorkoutInputModel inputModel, string userId);

        Task<WorkoutListViewModel> GetWorkoutsByUserId(string userId);
	}
}
