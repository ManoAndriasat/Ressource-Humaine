using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RessourceHumaine;

public class EmployerController : Controller
{
    public IActionResult listEmployer()
    {
        List<EmployerModel> allEmployer = EmployerModel.getAll();
        return View("index", allEmployer);
    }
    public IActionResult Profil(string Matricule){
        ViewBag.Profil = EmployerModel.GetProfil(Matricule);
        return View("Profil");   
    }
    public IActionResult ProfilConge(string Matricule){
        
        ViewBag.Valider = DemandeCongeModel.SelectDemandeConge(10,Matricule);
        ViewBag.Profil = EmployerModel.GetProfil(Matricule);
        if(DemandeCongeModel.ResteConge(Matricule) <=90){
        ViewBag.reste = DemandeCongeModel.ResteConge(Matricule);
        }else{
            ViewBag.reste=90;
        }
        return View("ProfilConge");   
    }
}
