using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using RessourceHumaine;

public class DemandeCongeController : Controller
{
     public IActionResult Index(IFormCollection form)
    {
        ViewBag.allEmployer = EmployerModel.getAll();
        return View();
    }

       public IActionResult Validation(IFormCollection form)
    {
        ViewBag.ListeDemandeConge = DemandeCongeModel.AllDemande(0);
        return View("Validation","DemandeConge");
    }

     public IActionResult Validation2(IFormCollection form)
    {
        ViewBag.ListeDemandeConge = DemandeCongeModel.AllDemande(9);
        return View("Validation2","DemandeConge");
    }
    
    public IActionResult PrevisionConge()
    {
        ViewBag.PrevisionConge = DemandeCongeModel.PrevisionConge(10);
        return View("PrevisionConge","DemandeConge");
    }

    public IActionResult Valider(string id){
        DemandeCongeModel.UpdateEtatByCongeID(id,9);
        return RedirectToAction("Validation", "DemandeConge");
    }


    public IActionResult ValiderD(string id){
        DemandeCongeModel.UpdateEtatByCongeID(id,10);
        return RedirectToAction("Validation2", "DemandeConge");
    }

    public IActionResult Refuser(string id){
        DemandeCongeModel.UpdateEtatByCongeID(id,5);
        return RedirectToAction("Validation", "DemandeConge");
    }

public IActionResult Insert(IFormCollection form)
{
    DateTime dateDebut;
    if (DateTime.TryParse(form["dateD"], out dateDebut))
    {
        if (dateDebut > DateTime.Now.AddDays(15))
        {
            var demande = new DemandeCongeModel
            {
                ID_Conge = "CG" + DemandeCongeModel.GetID(),
                Matricule = form["Matricule"].ToString(),
                DateDepart = dateDebut,
                DateRetour = DateTime.Parse(form["dateR"]),
                ID_TypeConge = form["ID_TypeConge"].ToString(),
                Motif = form["Motif"].ToString(),
                Etat = 0
            };
            
            DemandeCongeModel.InsertDemandeConge(demande);
            return RedirectToAction("Validation", "DemandeConge");
        }
        else
        {
            ViewBag.erreur = "Veuillez prevenir 15 jours en avance pour prendre un Conge";
        }
    }
    else
    {
        ViewBag.erreur = "Format de date invalide. Utilisez la format JJ/MM/AAAA.";
    }

    ViewBag.allEmployer = EmployerModel.getAll();
    return View("Index");
}
}