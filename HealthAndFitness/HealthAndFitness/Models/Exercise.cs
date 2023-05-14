namespace HealthAndFitness.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class Exercise
    {
        public Exercise()
        {
            this.Images = new HashSet<Image>();
            this.WorkoutExercises = new HashSet<WorkoutExercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ExerciseNameMinLenght)]
        [MaxLength(ExerciseNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MinLength(ExerciseDescriptionMinLenght)]
        [MaxLength(ExerciseDescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public int MuscleGroupId { get; set; }

        public MuscleGroup MuscleGroup { get; set; }

        [Required]
        public int VideoId { get; set; }

        public Video Video { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set;}
    }
}
