using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisioConference.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProprietaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salon_Utilisateur_ProprietaireId",
                        column: x => x.ProprietaireId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilisateurUtilisateur",
                columns: table => new
                {
                    ColleguesId = table.Column<int>(type: "int", nullable: false),
                    UtilisateursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilisateurUtilisateur", x => new { x.ColleguesId, x.UtilisateursId });
                    table.ForeignKey(
                        name: "FK_UtilisateurUtilisateur_Utilisateur_ColleguesId",
                        column: x => x.ColleguesId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilisateurUtilisateur_Utilisateur_UtilisateursId",
                        column: x => x.UtilisateursId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JointureUtilisateurSalon",
                columns: table => new
                {
                    SalonId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JointureUtilisateurSalon", x => new { x.SalonId, x.UtilisateurId });
                    table.ForeignKey(
                        name: "FK_JointureUtilisateurSalon_Salon_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JointureUtilisateurSalon_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Salon_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fichier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fichier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fichier_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fichier_MessageId",
                table: "Fichier",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_JointureUtilisateurSalon_UtilisateurId",
                table: "JointureUtilisateurSalon",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SalonId",
                table: "Message",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UtilisateurId",
                table: "Message",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Salon_ProprietaireId",
                table: "Salon",
                column: "ProprietaireId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateurUtilisateur_UtilisateursId",
                table: "UtilisateurUtilisateur",
                column: "UtilisateursId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fichier");

            migrationBuilder.DropTable(
                name: "JointureUtilisateurSalon");

            migrationBuilder.DropTable(
                name: "UtilisateurUtilisateur");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Salon");

            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
