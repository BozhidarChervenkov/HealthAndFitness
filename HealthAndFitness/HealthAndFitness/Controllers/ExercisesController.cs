namespace HealthAndFitness.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ExercisesController : Controller
    {
        public ExercisesController()
        {
        }

        public IActionResult ByMuscleGroup()
        {
            return this.View();
        }
    }
}
