using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

public class EmployeController : Controller {
    public IActionResult formSalaireBase() {
        List<EmployeModel> employeModels = EmployeModel.getAllEmploye();

        return View("index", employeModels);
    }

    // insert donnees
    public IActionResult insertEmp(IFormCollection form) {
        if(form["employe"] != "null") {
            EmployeModel.insertSalaireBase(form["employe"], double.Parse(form["salaireBase"]));
        } else {
            Console.WriteLine("employe vide");
        }
        
        return RedirectToAction("formSalaireBase");
    }
}