using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

public class UpdateFDPController : Controller
{
    public IActionResult Index()
    {
        List<EmployerModel> employe = EmployerModel.getAll();
        ViewBag.allEmployer =employe;
        return View();
    }

    public IActionResult Update(string columnName, string value, string type, string dateDebut, string Matricule){
        FicheDePaieDetails.UpdateValue(columnName,value,type,dateDebut,Matricule);
        return RedirectToAction("Index", "UpdateFDP");
    }
}
