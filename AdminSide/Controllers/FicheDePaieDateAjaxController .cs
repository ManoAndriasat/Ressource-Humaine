using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

[ApiController]
[Route("/date_fiche")]
public class FicheDePaieDateAjaxController : ControllerBase
{
    [HttpPost]
    public IActionResult VotreAction([FromBody] DateArgAjaxModel model)
    {
        // Traitez les données reçues dans model
        string matricule = model.matricule.ToString();
        List<string> dates = DateFicheDePaieModel.getDateBymatricule(matricule);
        var response = dates;

        return Ok(response);
    }
}
