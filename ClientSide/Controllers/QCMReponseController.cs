using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using Microsoft.AspNetCore.Http;
using System;

public class QCMReponseController : Controller
{
    [HttpPost]
    public IActionResult Insert(IFormCollection form)
    {
        string ID_Besoin = HttpContext.Session.GetString("Offre_ID");
        string ID_Candidat = HttpContext.Session.GetString("Candidat_ID");
  

        foreach (var key in form.Keys)
        {
            var values = form[key].ToString().Split('.');
            if (values.Length == 2)
            {
                string ID_Question = values[0];
                string Indice = values[1];

                var qcmReponse = new QCMReponseModel
                {
                    ID_Besoin = ID_Besoin,
                    ID_Candidat = ID_Candidat,
                    ID_Question = ID_Question,
                    Reponse = Indice
                };

                qcmReponse.InsertQCMReponse(qcmReponse);
            }
        }

        List<QuestionModel> Questions = QuestionModel.GetAllQuestions();
        List<QCMReponseModel> QCMReponse = QCMReponseModel.SelectQCMReponsesByID(ID_Besoin,ID_Candidat);

        List<CoefficientModel> coefficients =  CoefficientModel.SelectCoefficientByID(ID_Besoin);
        CandidatModel candidat =  CandidatModel.SelectCandidatByID(ID_Candidat);
        
        int ScoreQCM = QCMReponseModel.CompareAndCalculateScore(Questions,QCMReponse);
        int ScoreCV = CoefficientModel.ScoreCV(coefficients, candidat);

        CandidatNoteModel.InsertCandidatNote(new CandidatNoteModel(ID_Candidat,ScoreQCM+ScoreCV));

        return RedirectToAction("Index", "Offre");
    }
}
