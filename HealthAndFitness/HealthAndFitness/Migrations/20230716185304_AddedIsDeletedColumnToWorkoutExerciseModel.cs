using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthAndFitness.Migrations
{
    public partial class AddedIsDeletedColumnToWorkoutExerciseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WorkoutExercises",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WorkoutExercises");
        }
    }
}
