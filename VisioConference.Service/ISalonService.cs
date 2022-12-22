﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.Models;

namespace VisioConference.Service
{
    public interface ISalonService
    {
        Task CreateSalon(Salon salon);

        Task<List<Salon>> GetAllSalon();

        // Le propriétaire peut ajouter des utilisateurs
        Task AddUserSalon(Salon salon, Utilisateur utilisateur);

        // Le propriétaire pourra supprimer les utilisateurs de son salon s'il le souhaite
        Task DeleteUserSalon(Salon salon, Utilisateur utilisateur);

        Task<List<Utilisateur>> GetUtilisateursSalon(Salon salon);

        Task<List<Message>> GetMessagesSalon(Salon salon);

        Task<Salon> GetSalonById(int id);

        Task DeleteSalon(Salon salon);

        // Utilisateur est propriétaire du salon ?? -> True = oui
        Task<bool> IsProprietaireSalon(Utilisateur utilisateur, Salon salon);

        Task<List<Salon>> GetSalonCree(int utilisateurId);
        Task<List<Salon>> GetSalonInvitee(int utilisteurId);
    }
}