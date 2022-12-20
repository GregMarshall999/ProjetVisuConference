using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisioConference.Data.Migrations
{
    public partial class _2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JointureUtilisateurSalon_Salon_SalonId",
                table: "JointureUtilisateurSalon");

            migrationBuilder.DropForeignKey(
                name: "FK_JointureUtilisateurSalon_Utilisateur_UtilisateurId",
                table: "JointureUtilisateurSalon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JointureUtilisateurSalon",
                table: "JointureUtilisateurSalon");

            migrationBuilder.RenameTable(
                name: "JointureUtilisateurSalon",
                newName: "UtilisateursSalons");

            migrationBuilder.RenameIndex(
                name: "IX_JointureUtilisateurSalon_UtilisateurId",
                table: "UtilisateursSalons",
                newName: "IX_UtilisateursSalons_UtilisateurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtilisateursSalons",
                table: "UtilisateursSalons",
                columns: new[] { "SalonId", "UtilisateurId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UtilisateursSalons_Salon_SalonId",
                table: "UtilisateursSalons",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilisateursSalons_Utilisateur_UtilisateurId",
                table: "UtilisateursSalons",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilisateursSalons_Salon_SalonId",
                table: "UtilisateursSalons");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilisateursSalons_Utilisateur_UtilisateurId",
                table: "UtilisateursSalons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtilisateursSalons",
                table: "UtilisateursSalons");

            migrationBuilder.RenameTable(
                name: "UtilisateursSalons",
                newName: "JointureUtilisateurSalon");

            migrationBuilder.RenameIndex(
                name: "IX_UtilisateursSalons_UtilisateurId",
                table: "JointureUtilisateurSalon",
                newName: "IX_JointureUtilisateurSalon_UtilisateurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JointureUtilisateurSalon",
                table: "JointureUtilisateurSalon",
                columns: new[] { "SalonId", "UtilisateurId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JointureUtilisateurSalon_Salon_SalonId",
                table: "JointureUtilisateurSalon",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JointureUtilisateurSalon_Utilisateur_UtilisateurId",
                table: "JointureUtilisateurSalon",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "Id");
        }
    }
}
