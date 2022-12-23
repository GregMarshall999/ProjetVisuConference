using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisioConference.Data.Migrations
{
    public partial class AjoutNomdansSalon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Salon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Salon");
        }
    }
}
