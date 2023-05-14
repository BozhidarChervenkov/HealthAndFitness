namespace HealthAndFitness.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class Workout
    {
        public Workout()
        {
            this.Exercises = new HashSet<Exercise>();
            this.WorkoutExercises = new HashSet<WorkoutExercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(WorkoutNameMinLenght)]
        [MaxLength(WorkoutNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MinLength(ImageUrlMinLenght)]
        [MaxLength(ImageUrlMaxLenght)]
        public string ImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
