using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

public class CinController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


}
