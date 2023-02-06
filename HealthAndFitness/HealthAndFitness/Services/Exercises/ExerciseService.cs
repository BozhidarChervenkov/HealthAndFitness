namespace HealthAndFitness.Services.Exercises
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    using HealthAndFitness.Data;
    using HealthAndFitness.Models;
    using HealthAndFitness.ViewModels.Exercises;

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
        public ExerciseListViewModel GetExercisesByMuscleGroup(int muscleGroupId)
        {
            var muscleGroupName = this.context.MuscleGroups
                .Where(m => m.Id == muscleGroupId)
                .Select(m => m.Name)
                .FirstOrDefault();

            var exercisesInList = this.context.Exercises
                .Where(e => e.MuscleGroupId == muscleGroupId)
                .Select(e => new ExerciseInListViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    AddedByUsername = e.AddedByUser.UserName,
                    CreatedOn = e.CreatedOn,
                    ImageUrl = e.Images.First().Url
                })
                .ToList();

            var exerciseListViewModel = new ExerciseListViewModel
            {
                Exercises = exercisesInList,
                MuscleGroupName = muscleGroupName
            };

            return exerciseListViewModel;
        }

        public SelectList MuscleGroupsSelectList()
        {
            var muscleGroupsTypes = this.context.MuscleGroups.OrderBy(bt => bt.Name).ToList();

            var selectList = new SelectList(muscleGroupsTypes, "Id", "Name");

            return selectList;
        }
    }
}
