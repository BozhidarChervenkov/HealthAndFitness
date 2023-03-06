namespace HealthAndFitness.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Workout
    {
        public Workout()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
