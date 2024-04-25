using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourceHumaine;
using System;

[ApiController]
[Route("/getAllFicheByDate")]
public class FicheDePaieByDateAjaxController  : ControllerBase
{
    [HttpPost]
    public IActionResult VotreAction([FromBody] FicheDePaieAjaxModel model)
    {
        // Traitez les données reçues dans model
        string matricules = model.matricule.ToString();
        string date_debut = model.date_debut.ToString();
        List<EmployerModel> allEmployer = EmployerModel.getAll();
        EmployerModel employer = new EmployerModel();
        FicheDePaieDetails ficheDePaieDetails = new FicheDePaieDetails();
        List<FicheDePaieDetails> listFicheDePaieDate = new List<FicheDePaieDetails>();
        List<string> list_matricule = FicheDePaieDetails.getAllMatriculeByDate(date_debut);
        string matricule = "none";
        for(int io = 0; io< list_matricule.Count;io++)        
        {
            matricule = list_matricule[io];
            ficheDePaieDetails.dateDebut = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).dateDebut;
            ficheDePaieDetails.dateFin = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).dateFin;
            ficheDePaieDetails.nombreJours = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).nombreJours;
            ficheDePaieDetails.salaireDeBase = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).salaireDeBase;
            ficheDePaieDetails.heureSup30 = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).heureSup30;
            ficheDePaieDetails.heureSup40 = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).heureSup40;
            ficheDePaieDetails.heureSup50 = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).heureSup50;
            ficheDePaieDetails.heureSup100 = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).heureSup100;
            ficheDePaieDetails.primeDeRendement = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).primeDeRendement;
            ficheDePaieDetails.primeDanciennete = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).primeDanciennete;
            ficheDePaieDetails.majorationHeureNuit = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).majorationHeureNuit;
            ficheDePaieDetails.primeDiverse = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).primeDiverse;
            ficheDePaieDetails.rappelsPeriodeAnterieure = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).rappelsPeriodeAnterieure;
            ficheDePaieDetails.droitConge = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).droitConge;
            ficheDePaieDetails.droitPreavis = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).droitPreavis;
            ficheDePaieDetails.indemniteDeLicenciement = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).indemniteDeLicenciement;
            ficheDePaieDetails.joursAbsence = FicheDePaieDetails.getDetailFicheDePaix(matricule,date_debut).joursAbsence;
            for (int i = 0; i < allEmployer.Count; i++)
            {
            if (allEmployer[i].Matricule == matricule)
            {
                employer = allEmployer[i];
                break;
            }
            }
            ficheDePaieDetails.employer = employer;
            listFicheDePaieDate.Add(ficheDePaieDetails);
        }
        var response = listFicheDePaieDate;

        return Ok(response);
    }
}
