﻿namespace HealthAndFitness.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using HealthAndFitness.Models;
    using HealthAndFitness.Services.Exercises;
    using HealthAndFitness.ViewModels.Exercises;

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
        public async Task<IActionResult> Create()
        {
            ViewBag.MuscleGroupsSelectList = await this.exerciseService.MuscleGroupsSelectList();

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseInputModel inputModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return this.View(inputModel);
            //}

            var userId = this.userManager.GetUserId(this.User);

            var exerciseId = await this.exerciseService.Create(inputModel, userId);

            return this.RedirectToAction("ExerciseById", "Exercises", new { id = exerciseId });
        }

        [HttpGet]
        public async Task<IActionResult> ById (int exerciseId)
        {
            var viewModel = await this.exerciseService.GetExerciseById(exerciseId);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult ByMuscleGroup()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> AllByMuscleGroup(int muscleGroupId)
        {
            var exercises = await this.exerciseService.GetExercisesByMuscleGroup(muscleGroupId);

            return this.View(exercises);
        }
    }
}
