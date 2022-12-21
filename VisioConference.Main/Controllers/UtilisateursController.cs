using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisioConference.DAO;
using VisioConference.Models;

namespace VisioConference.Main.Controllers
{
    public class UtilisateursController : Controller
    {
        private readonly IUtilisateurDAO _utilisateurDAO;

        public UtilisateursController(IUtilisateurDAO utilisateurDAO)
        {
            _utilisateurDAO = utilisateurDAO;
        }

        // GET: Utilisateurs
        public async Task<IActionResult> Index()
        {
            return View(await _utilisateurDAO.getAllUtilisateur());
        }

        //GET : Utilisateurs/SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        //POST: Utilisateurs/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("Id,Nom,Prenom,MotDePasse,DateDeNaissance,Email")] Utilisateur utilisateur)
        {            
            await _utilisateurDAO.AddUtilisateur(utilisateur);
            return RedirectToAction(nameof(Index));
        }

        // GET: Utilisateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _utilisateurDAO == null)
                return NotFound();

            var utilisateur = await _utilisateurDAO.getUtilisateurById((int)id);
            if (utilisateur == null)
                return NotFound();

            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _utilisateurDAO == null)
                return NotFound();

            var utilisateur = await _utilisateurDAO.getUtilisateurById((int)id);
            if (utilisateur == null)
                return NotFound();

            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,MotDePasse,DateDeNaissance,Email")] Utilisateur utilisateur)
        {
            if (id != utilisateur.Id)
            {
                return NotFound();
            }

            try
            {
                await _utilisateurDAO.UpdateUtilisateur(utilisateur);
            }
            catch (DbUpdateConcurrencyException)
            {
                var u = await _utilisateurDAO.getAllUtilisateur();
                if (!u.Contains(utilisateur))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Utilisateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _utilisateurDAO == null)
            {
                return NotFound();
            }

            var utilisateur = await _utilisateurDAO.getUtilisateurById((int)id);
            if(utilisateur == null)
            {
                return NotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_utilisateurDAO == null)
            {
                return Problem("Entity set 'UtilisateurDAO' is null.");
            }

            var utilisateur = await _utilisateurDAO.getUtilisateurById(id);
            if(utilisateur != null)
            {
                await _utilisateurDAO.DeleteUtilisateur(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
