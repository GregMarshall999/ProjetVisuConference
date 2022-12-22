using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisioConference.Data.Migrations
{
    public partial class AjoutduIsRequiredenBDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPersistent",
                table: "Utilisateur",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPersistent",
                table: "Utilisateur");
        }
    }
}
