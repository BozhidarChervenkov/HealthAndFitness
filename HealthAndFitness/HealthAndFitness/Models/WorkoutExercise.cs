namespace HealthAndFitness.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WorkoutExercise
    {
        [Required]
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        [Required]
        public int WorkoutId { get; set; }

        public Workout Workout { get; set; }

        public bool IsDeleted { get; set; }
    }
}
