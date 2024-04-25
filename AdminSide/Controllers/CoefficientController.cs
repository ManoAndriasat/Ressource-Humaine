using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using Microsoft.AspNetCore.Http;
using System;


public class CoefficientController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

   [HttpPost]
    public IActionResult Insert(IFormCollection form)
    {
        string besoinID = HttpContext.Session.GetString("BesoinID");
        
        InsertCoefficient(besoinID, "diplome", form["diplome"], form["diplomeCoeff"]);
        InsertCoefficient(besoinID, "genre", form["genre"], form["genreCoeff"]);
        InsertCoefficient(besoinID, "situation", form["situation"], form["situationCoeff"]);
        InsertCoefficient(besoinID, "experience", form["experience"], form["experienceCoeff"]);
        InsertCoefficient(besoinID, "proximite", form["proximite"], form["proximiteCoeff"]);

        return RedirectToAction("Index", "Question");
    }

    private void InsertCoefficient(string besoinID, string category, string value, string coeff)
    {
        string[] values = value.ToString().Split('.');
        int coefficient = int.Parse(coeff);

        CoefficientModel.InsertCoefficient(new CoefficientModel(besoinID, category, values[0], int.Parse(values[1]), coefficient));
    }
}
