using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

public class OffreController : Controller
{
    public IActionResult Index()
    {
        List<BesoinModel> AllBesoins = BesoinModel.SelectAllBesoins();
        ViewBag.AllBesoins = AllBesoins;
        if(HttpContext.Session.GetString("Offre_ID")!=null){
            String id= HttpContext.Session.GetString("Offre_ID");
            BesoinModel BesoinDetails = BesoinModel.SelectBesoinByID(id); // Passer l'ID récupéré en paramètre
            ViewBag.BesoinDetails = BesoinDetails;

            List<CoefficientModel> AllCoefficients = CoefficientModel.SelectCoefficientByID(id);
            ViewBag.AllCoefficients = AllCoefficients;
        }
        return View();
    }

    public IActionResult Details(string id)
    {
        HttpContext.Session.SetString("Offre_ID", id);
        return RedirectToAction("Index", "Offre");
    }
}
