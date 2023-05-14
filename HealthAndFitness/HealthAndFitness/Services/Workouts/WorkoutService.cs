namespace HealthAndFitness.Services.Workouts
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    using HealthAndFitness.Data;
    using HealthAndFitness.Models;
    using HealthAndFitness.ViewModels.Workouts;
    using HealthAndFitness.ViewModels.Exercises;

    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext context;

        public WorkoutService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Create(CreateWorkoutInputModel inputModel, string userId)
        {
            var workout = new Workout
            {
                Name = inputModel.Name,
                ImageUrl = inputModel.ImageUrl,
                AddedByUserId = userId,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.Workouts.AddAsync(workout);
            await this.context.SaveChangesAsync();

            return workout.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var workout = this.context.Workouts
                .FirstOrDefault(c => c.Id == id);

            if (workout == null)
            {
                return false;
            }
            else
            {
                workout.IsDeleted = true;
                await this.context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<WorkoutListViewModel> GetWorkoutsByUserId(string userId)
        {
            var workouts = await context.Workouts
                .Where(w => w.AddedByUserId == userId && w.IsDeleted == false)
                .Select(w => new WorkoutInListViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    ImageUrl = w.ImageUrl,
                    CreatedOn = w.CreatedOn
                })
                .ToListAsync();

            var viewModel = new WorkoutListViewModel
            {
                Workouts = workouts
            };

            return viewModel;
        }

        public async Task<List<WorkoutExerciseViewModel>> GetWorkoutExercises(int workoutId, string userId)
        {
            var workoutExercisesIds = await this.context.WorkoutExercises
                .Where(we => we.WorkoutId == workoutId)
                .Select(we => we.ExerciseId)
                .ToListAsync();

            var listOfExercises = new List<WorkoutExerciseViewModel>();

            foreach (var exerciseId in workoutExercisesIds)
            {
                var exercise = this.context.Exercises
                    .Where(e => e.Id == exerciseId)
                    .Select(e => new WorkoutExerciseViewModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        AddedByUsername = e.AddedByUser.UserName,
                        CreatedOn = e.CreatedOn,
                    })
                    .First();

                listOfExercises.Add(exercise);
            }

            return listOfExercises;
        }

        public async Task AddExerciseToWorkout(int exerciseId, int workoutId)
        {
            await this.context.WorkoutExercises.AddAsync(new WorkoutExercise
            {
                ExerciseId = exerciseId,
                WorkoutId = workoutId
            });

            await this.context.SaveChangesAsync();
        }

        public async Task<SelectList> WorkoutsSelectList()
        {
            var workouts = await this.context.Workouts.OrderBy(bt => bt.Name).ToListAsync();

            var selectList = new SelectList(workouts, "Id", "Name");

            return selectList;
        }
    }
}
