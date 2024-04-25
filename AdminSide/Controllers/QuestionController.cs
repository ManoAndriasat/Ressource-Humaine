using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

public class QuestionController : Controller
{
    public IActionResult Index()
    {
        List<QuestionModel> AllQuestions = QuestionModel.GetAllQuestions();
        return View(AllQuestions);
    }
}
