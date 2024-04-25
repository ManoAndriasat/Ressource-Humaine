using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

public class CandidatController : Controller{

    [HttpPost]
    public IActionResult Register(CandidatModel candidat)
    {
        string ID_Candidat = "CA" + CandidatModel.GetNextID();
        candidat.ID_Candidat = ID_Candidat;
        candidat.ID_Besoin = HttpContext.Session.GetString("Offre_ID");
        CandidatModel.InsertCandidat(candidat);
        HttpContext.Session.SetString("Candidat_ID", ID_Candidat);
        return RedirectToAction("Index", "QCMBesoin");
    }
}
