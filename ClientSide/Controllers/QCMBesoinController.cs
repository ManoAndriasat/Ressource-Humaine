using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;
using System.Collections.Generic;

public class QCMBesoinController : Controller
{
    public IActionResult Index()
    {
        String idBesoin= HttpContext.Session.GetString("Offre_ID");
        List<AllQcm> qcmList = AllQcm.SelectAllByBesoin(idBesoin);
        ViewBag.AllQCMBesoins = qcmList;
        return View();
    }
}
