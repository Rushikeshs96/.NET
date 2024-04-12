using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Dev.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "logins",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "logins",
                newName: "Email");
        }
    }
}
