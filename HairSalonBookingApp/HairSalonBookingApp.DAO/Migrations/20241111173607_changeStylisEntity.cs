using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairSalonBookingApp.DAO.Migrations
{
    public partial class changeStylisEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Stylists");

            migrationBuilder.DropColumn(
                name: "Master",
                table: "Stylists");

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Stylists",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_StaffManagers_BranchID",
                table: "StaffManagers",
                column: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffManagers_Branches_BranchID",
                table: "StaffManagers",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "BranchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffManagers_Branches_BranchID",
                table: "StaffManagers");

            migrationBuilder.DropIndex(
                name: "IX_StaffManagers_BranchID",
                table: "StaffManagers");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Stylists");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Stylists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Master",
                table: "Stylists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
