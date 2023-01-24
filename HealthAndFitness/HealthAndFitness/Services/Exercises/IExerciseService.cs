namespace HealthAndFitness.Services.Exercises
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    using HealthAndFitness.ViewModels.Exercises;

    public interface IExerciseService
    {
        int Create(CreateExerciseInputModel inputModel, string userId);

        SelectList MuscleGroupsSelectList();
    }
}
