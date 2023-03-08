namespace HealthAndFitness.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using HealthAndFitness.Models;
    using HealthAndFitness.Services.Workouts;
    using HealthAndFitness.ViewModels.Workouts;
    using Microsoft.AspNetCore.Authorization;

    public class WorkoutsController : Controller
    {
        private readonly IWorkoutService workoutService;
        private readonly UserManager<ApplicationUser> userManager;

        public WorkoutsController(IWorkoutService workoutService, UserManager<ApplicationUser> userManager)
        {
            this.workoutService = workoutService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkoutInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.workoutService.Create(inputModel, userId);

            return this.RedirectToAction("WorkoutsByUserId", "Workouts");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isWorkoutDeleted = this.workoutService.Delete(id);

            if (await isWorkoutDeleted == false)
            {
                ViewBag.ErrorMessage = $"Workout with id {id} cannot be found!";
                return this.View("NotFound");
            }

            return this.RedirectToAction("WorkoutsByUserId", "Workouts");
        }

        public async Task<IActionResult> WorkoutsByUserId()
        {
			var userId = this.userManager.GetUserId(this.User);
            var viewModel = await workoutService.GetWorkoutsByUserId(userId);

            return this.View(viewModel);
        }   
    }
}
