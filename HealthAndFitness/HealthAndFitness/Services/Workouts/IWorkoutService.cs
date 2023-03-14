namespace HealthAndFitness.Services.Workouts
{
    using HealthAndFitness.ViewModels.Workouts;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IWorkoutService
    {
        Task<int> Create(CreateWorkoutInputModel inputModel, string userId);

        Task<bool> Delete(int id);

        Task<WorkoutListViewModel> GetWorkoutsByUserId(string userId);

        Task AddExerciseToWorkout(int exerciseId, int workoutId);

        Task<SelectList> WorkoutsSelectList();
    }
}
