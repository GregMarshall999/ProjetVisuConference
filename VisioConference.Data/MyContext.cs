﻿using VisioConference.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioConference.Data
{
    internal class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Fichier> Fichier { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Salon> Salon { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
        public virtual DbSet<UtilisateurSalon> JointureUtilisateurSalon { get; set; }
        public virtual DbSet<Collegue> Collegue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salon>()
                .HasOne(s => s.Proprietaire)
                .WithMany(p => p.SalonsCrees)
                .HasForeignKey(s => s.ProprietaireId);

            modelBuilder.Entity<Collegue>()
                .HasOne(c => c.Utilisateur)
                .WithMany(u => u.ColleguesUtilisateur)
                .HasForeignKey(c => c.UtilisateurId);

            modelBuilder.Entity<UtilisateurSalon>()
                .HasKey(us => new
                {
                    us.SalonId,
                    us.UtilisateurId,
                });

            modelBuilder.Entity<UtilisateurSalon>()
                .HasOne(us => us.Utilisateur)
                .WithMany(u => u.UtilisateursSalons)
                .HasForeignKey(us => us.UtilisateurId);

            modelBuilder.Entity<UtilisateurSalon>()
                 .HasOne(us => us.Salon)
                .WithMany(s => s.UtilisateursSalons)
                .HasForeignKey(us => us.SalonId);
        }
    }
}
