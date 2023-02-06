namespace HealthAndFitness.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using HealthAndFitness.Models;
    using HealthAndFitness.ViewModels.Exercises;
    using HealthAndFitness.Services.Exercises;
    using Microsoft.AspNetCore.Authorization;

    public class ExercisesController : Controller
    {
        private readonly IExerciseService exerciseService;
        private readonly UserManager<ApplicationUser> userManager;

        public ExercisesController(IExerciseService exerciseService, UserManager<ApplicationUser> userManager)
        {
            this.exerciseService = exerciseService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MuscleGroupsSelectList = this.exerciseService.MuscleGroupsSelectList();

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateExerciseInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var userId = this.userManager.GetUserId(this.User);

            var exerciseId = this.exerciseService.Create(inputModel, userId);

            return this.RedirectToAction("ExerciseById", "Exercises", new { id = exerciseId });
        }

        [HttpGet]
        public IActionResult ByMuscleGroup()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult AllByMuscleGroup(int muscleGroupId)
        {
            var exercises = this.exerciseService.GetExercisesByMuscleGroup(muscleGroupId);

            return this.View(exercises);
        }
    }
}
