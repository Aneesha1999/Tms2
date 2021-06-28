using Microsoft.EntityFrameworkCore.Migrations;

namespace Tms2.Migrations
{
    public partial class Tms2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admininfos",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admininfos", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "allocatevehicles",
                columns: table => new
                {
                    vehicleallocationtopassenger = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allocatevehicles", x => x.vehicleallocationtopassenger);
                });

            migrationBuilder.CreateTable(
                name: "empinfos",
                columns: table => new
                {
                    employeeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empinfos", x => x.employeeid);
                });

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "modifies",
                columns: table => new
                {
                    employee = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    vehicle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    routeinfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modifies", x => x.employee);
                });

            migrationBuilder.CreateTable(
                name: "routeinfos",
                columns: table => new
                {
                    rootnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehiclenumber = table.Column<int>(type: "int", nullable: false),
                    stops = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routeinfos", x => x.rootnumber);
                });

            migrationBuilder.CreateTable(
                name: "userregs",
                columns: table => new
                {
                    User_firstname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userregs", x => x.User_firstname);
                });

            migrationBuilder.CreateTable(
                name: "vehicleinfos",
                columns: table => new
                {
                    vehiclenumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    seat = table.Column<int>(type: "int", nullable: false),
                    operable = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleinfos", x => x.vehiclenumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admininfos");

            migrationBuilder.DropTable(
                name: "allocatevehicles");

            migrationBuilder.DropTable(
                name: "empinfos");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "modifies");

            migrationBuilder.DropTable(
                name: "routeinfos");

            migrationBuilder.DropTable(
                name: "userregs");

            migrationBuilder.DropTable(
                name: "vehicleinfos");
        }
    }
}
