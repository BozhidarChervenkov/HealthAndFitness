namespace HealthAndFitness.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using HealthAndFitness.Models;
    using HealthAndFitness.Services.Workouts;
    using HealthAndFitness.ViewModels.Workouts;
    
    public class WorkoutsController : Controller
    {
        private readonly IWorkoutService workoutService;
        private readonly UserManager<ApplicationUser> userManager;

        public WorkoutsController(IWorkoutService workoutService, UserManager<ApplicationUser> userManager)
        {
            this.workoutService = workoutService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> WorkoutsByUserId()
        {
			var userId = this.userManager.GetUserId(this.User);
            var viewModel = await workoutService.GetWorkoutsByUserId(userId);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkoutInputModel inputModel)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.workoutService.Create(inputModel, userId);

            return this.RedirectToAction("WorkoutsByUserId", "Workouts");
        }     
    }
}
