﻿namespace HealthAndFitness.Services.Exercises
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using HealthAndFitness.Data;
    using HealthAndFitness.Models;
    using HealthAndFitness.ViewModels.Exercises;

    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext context;

        public ExerciseService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Create(CreateExerciseInputModel inputModel, string userId)
        {
            var exercise = new Exercise()
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                MuscleGroupId = inputModel.MuscleGroupId,
                Video = new Video
                {
                    Url = inputModel.VideoURL
                },
                AddedByUserId = userId,
                CreatedOn = DateTime.Now,
                Images = inputModel.Images,
            };

            await this.context.Exercises.AddAsync(exercise);
            await this.context.SaveChangesAsync();

            return exercise.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var exercise = this.context.Exercises
                .FirstOrDefault(c => c.Id == id);

            if (exercise == null)
            {
                return false;
            }
            else
            {
                exercise.IsDeleted = true;
                await this.context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<ExerciseByIdViewModel> GetExerciseById(int exerciseId)
        {
            var viewModel = await this.context.Exercises
                .Where(e => e.Id == exerciseId)
                .Select(e => new ExerciseByIdViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    MuscleGroupName = e.MuscleGroup.Name,
                    EmbeddedVideoCode = EmbeddedVideoCode(e.Video.Url),
                    AddedByUser = e.AddedByUser,
                    CreatedOn = e.CreatedOn,
                    Images = e.Images
                })
                .FirstOrDefaultAsync();

            return viewModel;
        }

        public async Task<ExerciseListViewModel> GetExercisesByMuscleGroup(int muscleGroupId)
        {
            var muscleGroupName = await this.context.MuscleGroups
                .Where(m => m.Id == muscleGroupId)
                .Select(m => m.Name)
                .FirstOrDefaultAsync();

            var exercisesInList = await this.context.Exercises
                .Where(e => e.MuscleGroupId == muscleGroupId && e.IsDeleted == false)
                .Select(e => new ExerciseInListViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    AddedByUsername = e.AddedByUser.UserName,
                    CreatedOn = e.CreatedOn,
                    ImageUrl = e.Images.First().Url
                })
                .ToListAsync();

            var exerciseListViewModel = new ExerciseListViewModel
            {
                Exercises = exercisesInList,
                MuscleGroupName = muscleGroupName!
            };

            return exerciseListViewModel;
        }

        public async Task<SelectList> MuscleGroupsSelectList()
        {
            var muscleGroupsTypes = await this.context.MuscleGroups.OrderBy(bt => bt.Name).ToListAsync();

            var selectList = new SelectList(muscleGroupsTypes, "Id", "Name");

            return selectList;
        }

        private static string EmbeddedVideoCode(string videoUrl)
        {
            int position = videoUrl.IndexOf("=") + 1;
            var embeddedCode = videoUrl.Substring(position, 11);

            return embeddedCode;
        }
    }
}
