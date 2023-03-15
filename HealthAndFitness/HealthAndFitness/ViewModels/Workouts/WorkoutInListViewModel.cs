using HealthAndFitness.Models;

namespace HealthAndFitness.ViewModels.Workouts
{
    public class WorkoutInListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
