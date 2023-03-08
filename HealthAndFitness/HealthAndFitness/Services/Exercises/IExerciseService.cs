namespace HealthAndFitness.Services.Exercises
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    using HealthAndFitness.ViewModels.Exercises;

    public interface IExerciseService
    {
        Task<int> Create(CreateExerciseInputModel inputModel, string userId);

        Task<bool> Delete(int id);

        Task<ExerciseByIdViewModel> GetExerciseById(int exerciseId);

        Task<ExerciseListViewModel> GetExercisesByMuscleGroup(int muscleGroupId);

        Task<SelectList> MuscleGroupsSelectList();
    }
}
