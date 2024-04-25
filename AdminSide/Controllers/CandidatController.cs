using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

public class CandidatController : Controller {
    public IActionResult Index() {
        List<CandidatModel> allCandidat = CandidatModel.getAll();
        ViewBag.allCandidat = allCandidat;
        return View();
    }

    public IActionResult formEmbauche(IFormCollection form) {
        ViewBag.idCandidat = form["nameCandidat"];
        return View("formulaireEmbauche", "Candidat");
    }

    public IActionResult insertEmbauche(IFormCollection form) {
        CandidatModel.InsertCandidatEmbauche(form["idCandidat"], form["dateNaissance"], form["dateEmbauche"], form["numCIN"], form["contact"], form["direction"], form["fonction"]);
        return RedirectToAction("Index", "Candidat");
    }
}