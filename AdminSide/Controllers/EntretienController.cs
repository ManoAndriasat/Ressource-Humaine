using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RessourceHumaine;

public class EntretienController : Controller
{
    public IActionResult Index()
    {
        List<EntretienModel> ListeCandidat = EntretienModel.GetCandidat();
        ViewBag.ListeCandidat = ListeCandidat;
        return View();
    }
}
