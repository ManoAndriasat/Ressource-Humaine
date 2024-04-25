using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using RessourceHumaine;

public class LoginController : Controller
{
    public IActionResult Index(string user)
    {
        HttpContext.Session.SetString("user", user);
        return RedirectToAction("AllFiche", "FicheDePaie");
    }
}
