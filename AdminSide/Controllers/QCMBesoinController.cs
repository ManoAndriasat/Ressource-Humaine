using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;
using System.Collections.Generic;

public class QCMBesoinController : Controller
{
    [HttpPost]
    public IActionResult Insert(List<string> selectedQuestions)
    {
        string besoinId = HttpContext.Session.GetString("BesoinID"); // Obtenez l'ID du besoin à partir de la session

        foreach (string questionId in selectedQuestions)
        {
            QCMBesoinModel qcmBesoin = new QCMBesoinModel(besoinId, questionId);
            QCMBesoinModel.InsertQCMBesoin(qcmBesoin);
        }

        return RedirectToAction("Index", "Besoin");
    }
}
