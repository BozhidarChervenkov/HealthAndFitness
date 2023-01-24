using HealthAndFitness.Data;
using HealthAndFitness.Models;
using HealthAndFitness.ViewModels.Exercises;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthAndFitness.Services.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext context;

        public ExerciseService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Create(CreateExerciseInputModel inputModel, string userId)
        {
            var exercise = new Exercise()
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                MuscleGroupId = inputModel.MuscleGroupId,
                Video = new Video
                {
                    Url = inputModel.VideoURL
                },
                AddedByUserId = userId,
                CreatedOn = DateTime.Now,
                Images = inputModel.Images,
            };

            this.context.Exercises.Add(exercise);
            this.context.SaveChanges();

            return exercise.Id;
        }

        public SelectList MuscleGroupsSelectList()
        {
            var muscleGroupsTypes = this.context.MuscleGroups.OrderBy(bt => bt.Name).ToList();

            var selectList = new SelectList(muscleGroupsTypes, "Id", "Name");

            return selectList;
        }
    }
}
