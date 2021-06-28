using Microsoft.EntityFrameworkCore.Migrations;

namespace Tms2.Migrations
{
    public partial class tmspro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "seat",
                table: "vehicleinfos",
                newName: "Availableseats");

            migrationBuilder.RenameColumn(
                name: "vehicleallocationtopassenger",
                table: "allocatevehicles",
                newName: "Employeename");

            migrationBuilder.AddColumn<int>(
                name: "Employeeage",
                table: "allocatevehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Employeelocation",
                table: "allocatevehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Empphoneno",
                table: "allocatevehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "vehicleallocationtoEmployee",
                table: "allocatevehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employeeage",
                table: "allocatevehicles");

            migrationBuilder.DropColumn(
                name: "Employeelocation",
                table: "allocatevehicles");

            migrationBuilder.DropColumn(
                name: "Empphoneno",
                table: "allocatevehicles");

            migrationBuilder.DropColumn(
                name: "vehicleallocationtoEmployee",
                table: "allocatevehicles");

            migrationBuilder.RenameColumn(
                name: "Availableseats",
                table: "vehicleinfos",
                newName: "seat");

            migrationBuilder.RenameColumn(
                name: "Employeename",
                table: "allocatevehicles",
                newName: "vehicleallocationtopassenger");
        }
    }
}
