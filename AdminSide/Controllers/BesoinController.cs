using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

public class BesoinController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Insert(BesoinModel besoinModel)
    {
        BesoinModel besoin = new BesoinModel
        {
            Titre = besoinModel.Titre,
            Service = besoinModel.Service,
            Description = besoinModel.Description,
            Type = besoinModel.Type,
            Region = besoinModel.Region,
            HeureParJour = besoinModel.HeureParJour,
            JourParSemaine = besoinModel.JourParSemaine
        };

        String id = "BS" + besoin.GetNextID().ToString();
        besoin.ID_Besoin = id;
        besoin.InsertBesoin(besoin);

        // Store the ID in a session variable
        HttpContext.Session.SetString("BesoinID", id);

        return RedirectToAction("Index", "Coefficient");
    }
}
