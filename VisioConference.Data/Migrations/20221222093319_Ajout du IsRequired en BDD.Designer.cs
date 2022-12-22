﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisioConference.Data;

#nullable disable

namespace VisioConference.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20221222093319_Ajout du IsRequired en BDD")]
    partial class AjoutduIsRequiredenBDD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UtilisateurUtilisateur", b =>
                {
                    b.Property<int>("ColleguesId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateursId")
                        .HasColumnType("int");

                    b.HasKey("ColleguesId", "UtilisateursId");

                    b.HasIndex("UtilisateursId");

                    b.ToTable("UtilisateurUtilisateur");
                });

            modelBuilder.Entity("VisioConference.Models.Fichier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("FData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FNom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Fichier");
                });

            modelBuilder.Entity("VisioConference.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalonId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("VisioConference.Models.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProprietaireId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProprietaireId");

                    b.ToTable("Salon");
                });

            modelBuilder.Entity("VisioConference.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateDeNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPersistent")
                        .HasColumnType("bit");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("VisioConference.Models.UtilisateurSalon", b =>
                {
                    b.Property<int>("SalonId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("SalonId", "UtilisateurId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("UtilisateursSalons");
                });

            modelBuilder.Entity("UtilisateurUtilisateur", b =>
                {
                    b.HasOne("VisioConference.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("ColleguesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisioConference.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UtilisateursId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VisioConference.Models.Fichier", b =>
                {
                    b.HasOne("VisioConference.Models.Message", null)
                        .WithMany("piècesJointe")
                        .HasForeignKey("MessageId");
                });

            modelBuilder.Entity("VisioConference.Models.Message", b =>
                {
                    b.HasOne("VisioConference.Models.Salon", "Salon")
                        .WithMany("Messages")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisioConference.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Salon");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("VisioConference.Models.Salon", b =>
                {
                    b.HasOne("VisioConference.Models.Utilisateur", "Proprietaire")
                        .WithMany("SalonsCrees")
                        .HasForeignKey("ProprietaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proprietaire");
                });

            modelBuilder.Entity("VisioConference.Models.UtilisateurSalon", b =>
                {
                    b.HasOne("VisioConference.Models.Salon", "Salon")
                        .WithMany("UtilisateursSalons")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisioConference.Models.Utilisateur", "Utilisateur")
                        .WithMany("UtilisateursSalons")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Salon");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("VisioConference.Models.Message", b =>
                {
                    b.Navigation("piècesJointe");
                });

            modelBuilder.Entity("VisioConference.Models.Salon", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UtilisateursSalons");
                });

            modelBuilder.Entity("VisioConference.Models.Utilisateur", b =>
                {
                    b.Navigation("SalonsCrees");

                    b.Navigation("UtilisateursSalons");
                });
#pragma warning restore 612, 618
        }
    }
}
