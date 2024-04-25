using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using RessourceHumaine;

public class CongeEmployerController : Controller
{
    public IActionResult Index(IFormCollection form)
    {
        string Matricule = HttpContext.Session.GetString("Matricule");
        ViewBag.CongeValider = DemandeCongeModel.SelectDemandeConge(10,Matricule);
        ViewBag.CongeRefuser = DemandeCongeModel.SelectDemandeConge(5,Matricule);
        return View();
    }

    public IActionResult Click(String Matricule){
        HttpContext.Session.SetString(Matricule,"Matricule");
        return RedirectToAction("Index", "CongeEmployer");
    }
}
