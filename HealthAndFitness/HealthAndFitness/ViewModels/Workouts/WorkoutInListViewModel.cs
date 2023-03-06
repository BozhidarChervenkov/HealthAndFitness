using HealthAndFitness.Models;

namespace HealthAndFitness.ViewModels.Workouts
{
    public class WorkoutInListViewModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
