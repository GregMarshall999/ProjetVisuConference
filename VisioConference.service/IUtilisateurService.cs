﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VisioConference.Models;

namespace VisioConference.Service
{
    public interface IUtilisateurService
    {
        Task<ClaimsPrincipal> Login(string email, string password, bool isPersistent);

        Task<List<Utilisateur>> GetAllUtilisateur();

        Task AddUtilisateur(Utilisateur utilisateur);

        Task UpdateUtilisateur(Utilisateur utilisateur);

        Task<Utilisateur> GetUtilisateurById(int Id);

        Task DeleteUtilisateur(int IdUtilisateur);

        Task<bool> AddCollegue(int utilisateurId, string collegueEmail);

        Task DeleteCollegue(Utilisateur utilisateur, Utilisateur UtilisateurCollegue);

        Task<Dictionary<int, Utilisateur>> GetAllCollegue(int IdUtilisateur);

        Task<List<Utilisateur>> GetListCollegue(int Id);

        Task<Utilisateur> GetUtilisateurByEmail(string email);
    }
}
