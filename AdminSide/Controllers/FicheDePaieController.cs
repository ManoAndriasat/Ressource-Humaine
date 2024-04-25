using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RessourceHumaine;

public class FicheDePaieController : Controller
{
    public IActionResult tableauFicheDePaie()
    {
        FicheDePaie ficheDePaie = new FicheDePaie();
        List<EmployerModel> allEmployer = EmployerModel.getAll();
        
        ficheDePaie.employers = allEmployer;
        ficheDePaie.ficheDePaixDetail = FicheDePaieDetails.getDetailFicheDePaie("null");
        return View("index", ficheDePaie);
    }
    public IActionResult insertion() {    
        List<EmployerModel> allEmployer = EmployerModel.getAll();
        return View("insertionFicheDePaix",allEmployer);
    }
    
    public IActionResult AllFiche(){
        List<string> Alldate = FicheDePaieDetails.AllDate();
        return View("AllFiche", Alldate);
    }
    public IActionResult insertionParametreFicheDePaie(IFormCollection form) {
       FicheDePaieDetails.insertFicheDePaie(
        form["employer"], 
        form["dateDebut"], 
        form["dateFin"], 
        form["nombreJours"], 
        form["salaireDeBase"], 
        form["heureSup30"], 
        form["heureSup40"], 
        form["heureSup50"], 
        form["heureSup100"], 
        form["primeDeRendement"],
        form["primeDanciennete"], 
        form["majorationHeureNuit"],
        form["primeDiverse"], 
        form["rappelsPeriodeAnterieure"], 
        form["droitConge"], 
        form["droitPreavis"], 
        form["indemniteDeLicenciement"],
        form["joursAbsence"]);
        
        return RedirectToAction("insertion", "FicheDePaie");
    }
}
