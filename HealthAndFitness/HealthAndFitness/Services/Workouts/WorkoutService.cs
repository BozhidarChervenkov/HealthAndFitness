namespace HealthAndFitness.Services.Workouts
{
    using HealthAndFitness.Data;
    using HealthAndFitness.Models;
    using HealthAndFitness.ViewModels.Workouts;
    using Microsoft.EntityFrameworkCore;

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
                AddedByUserId = userId
            };

            await this.context.Workouts.AddAsync(workout);
            await this.context.SaveChangesAsync();

            return workout.Id;
        }

		public async Task<WorkoutListViewModel> GetWorkoutsByUserId(string userId)
		{
            var workouts = await context.Workouts
                .Where(w => w.AddedByUserId == userId)
                .Select(w => new WorkoutInListViewModel
                {
                    Name = w.Name,
                    ImageUrl = w.ImageUrl
                })
                .ToListAsync();

            var viewModel = new WorkoutListViewModel
            {
                Workouts = workouts
            };

            return viewModel;
		}
	}
}
