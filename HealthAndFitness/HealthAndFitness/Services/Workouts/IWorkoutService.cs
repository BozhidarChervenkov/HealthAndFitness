namespace HealthAndFitness.Services.Workouts
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    using HealthAndFitness.ViewModels.Workouts;

    public interface IWorkoutService
    {
        Task<int> Create(CreateWorkoutInputModel inputModel, string userId);

        Task<bool> Delete(int id);

        Task<WorkoutListViewModel> GetWorkoutsByUserId(string userId);

        Task<List<WorkoutExerciseViewModel>> GetWorkoutExercises(int workoutId, string userId);

        Task AddExerciseToWorkout(int exerciseId, int workoutId);

        Task<SelectList> WorkoutsSelectList();
    }
}
