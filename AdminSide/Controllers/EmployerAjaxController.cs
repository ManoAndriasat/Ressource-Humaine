using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

[ApiController]
[Route("/employerAjaxSearch")]
public class EmployerAjaxController : ControllerBase
{
    [HttpPost]
    public IActionResult VotreAction([FromBody] ValidationAjaxModel model)
    {
        // Traitez les données reçues dans model
        string tri = model.tri.ToString();
        string sort = model.sort.ToString();
        string genre = model.genre.ToString();
        string searchbar = model.searchval.ToString();
        List<EmployerModel> allEmployer = EmployerModel.getEmployerAjax(tri,sort,genre,searchbar);
        var response = allEmployer;

        return Ok(response);
    }
}
