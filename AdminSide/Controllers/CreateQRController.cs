using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

public class CreateQRController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

     [HttpPost]
        public IActionResult Insert(IFormCollection formCollection)
        {
            // Access form data using formCollection
            string question = formCollection["question"]; // Note the typo here, it should be "question"
            string r1 = formCollection["R1"];
            string r2 = formCollection["R2"];
            string r3 = formCollection["R3"];
            string r4 = formCollection["R4"];
            string r5 = formCollection["R5"];
            string bonneReponse = formCollection["BR"];

            // Process the form data as needed
            String IDQ = "Q" + QuestionModel.GetNextID();
            QuestionModel.InsertQuestion(new QuestionModel(IDQ,question,bonneReponse));
            if (!string.IsNullOrEmpty(r1)){ReponseModel.InsertReponse(new ReponseModel(IDQ, r1, "1"));}
            if (!string.IsNullOrEmpty(r2)){ReponseModel.InsertReponse(new ReponseModel(IDQ, r2, "2"));}
            if (!string.IsNullOrEmpty(r3)){ReponseModel.InsertReponse(new ReponseModel(IDQ, r3, "3"));}
            if (!string.IsNullOrEmpty(r4)){ReponseModel.InsertReponse(new ReponseModel(IDQ, r4, "4"));}
            if (!string.IsNullOrEmpty(r5)){ReponseModel.InsertReponse(new ReponseModel(IDQ, r5, "5"));}

            return RedirectToAction("Index","Question");
        }
}
