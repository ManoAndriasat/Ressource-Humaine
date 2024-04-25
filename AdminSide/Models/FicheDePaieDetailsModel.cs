using Npgsql;
using System;
using RessourceHumaine;


namespace RessourceHumaine
{
    public class FicheDePaieDetails{
        public EmployerModel employer{get; set;}
        public string salaireDeBase {get; set;}
        public string tauxJournaliers {get; set;}
        public string tauxHoraires {get; set;}
        public string dateDebut {get; set;}
        public string dateFin {get; set;}
        public string montantSalaireDuDate {get; set;}
        public string nombreDabsenceDeductible {get; set;}
        public string montantDabsence {get; set;}

         public string nombreJours  {get;set;}
         public string heureSup30   {get;set;}
         public string heureSup40   {get;set;}
         public string heureSup50   {get;set;}
         public string heureSup100  {get;set;}
         public string primeDeRendement  {get;set;}
         public string primeDanciennete {get;set;}
         public string majorationHeureNuit   {get;set;}
         public string primeDiverse {get;set;}
         public string rappelsPeriodeAnterieure {get;set;}
         public string droitConge   {get;set;}
         public string droitPreavis {get;set;}
         public string indemniteDeLicenciement {get;set;}
        public string joursAbsence {get;set;}

        
        public static FicheDePaieDetails getDetailFicheDePaie(string ID_Candidat){
            FicheDePaieDetails ficherdepaix = new FicheDePaieDetails();
            EmployerModel employer = new EmployerModel();
            employer.ID_Besoin = "aucun(ne)";
            employer.ID_Candidat = "aucun(ne)";
            employer.FirstName ="aucun(ne)";
            employer.LastName = "aucun(ne)";
            employer.Genre ="aucun(ne)";
            employer.Email = "aucun(ne)";
            employer.Situation = "aucun(ne)";
            employer.Experience = "aucun(ne)";
            employer.Proximite = "aucun(ne)";
            employer.DiplomeNiveau = "aucun(ne)";
            employer.DiplomeFiliere = "aucun(ne)";
            employer.Matricule = "aucun(ne)";
            employer.Date_naissance = "aucun(ne)";
            employer.Numero_cin = "aucun(ne)";
            employer.Contact = "aucun(ne)";
            employer.Direction = "aucun(ne)";
            employer.Fonction = "aucun(ne)";
            Boolean idExist = false;
            for (int i = 0; i < EmployerModel.getAll().Count; i++)
            {
                if (ID_Candidat == EmployerModel.getAll()[i].ID_Candidat)
                {
                    employer = EmployerModel.getAll()[i];
                    idExist = true;
                    break;
                }
            }
            if (idExist)
            {
                ficherdepaix.salaireDeBase = "salaire de base disponible";
                ficherdepaix.tauxJournaliers = "taux journalier disponible";
                ficherdepaix.tauxHoraires = "taux horaire disponible";
                ficherdepaix.dateDebut = "34/56/6789";
                ficherdepaix.dateFin = "34/24/3400";
                ficherdepaix.montantSalaireDuDate = "800 Ariary";
                ficherdepaix.nombreDabsenceDeductible = "5 jours";
                ficherdepaix.montantDabsence = "5 Ariary";
            }else{
                using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("select * from fiche_de_paie_details where matricule='"+ID_Candidat+"'", conn))
                    // and date_debut>'2023-10-20'
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Utilisation d'une boucle while pour parcourir tous les enregistrements
                            {
                            ficherdepaix.dateDebut = reader["date_debut"].ToString();
                            ficherdepaix.dateFin = reader["date_fin"].ToString();
                            ficherdepaix.nombreJours = reader["nombre_de_jours"].ToString();
                            ficherdepaix.salaireDeBase = reader["salaire_de_base"].ToString();
                            ficherdepaix.heureSup30 = reader["heure_sup_30"].ToString();
                            ficherdepaix.heureSup40 = reader["heure_sup_40"].ToString();
                            ficherdepaix.heureSup50 = reader["heure_sup_50"].ToString();
                            ficherdepaix.heureSup100 = reader["heure_sup_100"].ToString();
                            ficherdepaix.primeDeRendement = reader["prime_de_rendement"].ToString();
                            ficherdepaix.primeDanciennete = reader["prime_d_anciennete"].ToString();
                            ficherdepaix.majorationHeureNuit = reader["majoration_heure_nuit"].ToString();
                            ficherdepaix.primeDiverse = reader["prime_diverse"].ToString();
                            ficherdepaix.rappelsPeriodeAnterieure = reader["rappels_periode_anterieure"].ToString();
                            ficherdepaix.droitConge = reader["droit_conge"].ToString();
                            ficherdepaix.droitPreavis = reader["droit_preavis"].ToString();
                            ficherdepaix.indemniteDeLicenciement = reader["indemnite_de_licenciement"].ToString();
                            ficherdepaix.joursAbsence = reader["jours_absence"].ToString();
                            }
                        }
                    }
                }
            }
            }
            ficherdepaix.employer = employer;
            return ficherdepaix;
        }
    

        // select * from fiche_de_paie_details where matricule='3428' and date_debut='2023-10-20'
        public static FicheDePaieDetails getDetailFicheDePaix(string ID_Candidat,string date_debut){
            FicheDePaieDetails ficherdepaix = new FicheDePaieDetails();
            EmployerModel employer = new EmployerModel();
            employer.ID_Besoin = "aucun(ne)";
            employer.ID_Candidat = "aucun(ne)";
            employer.FirstName ="aucun(ne)";
            employer.LastName = "aucun(ne)";
            employer.Genre ="aucun(ne)";
            employer.Email = "aucun(ne)";
            employer.Situation = "aucun(ne)";
            employer.Experience = "aucun(ne)";
            employer.Proximite = "aucun(ne)";
            employer.DiplomeNiveau = "aucun(ne)";
            employer.DiplomeFiliere = "aucun(ne)";
            employer.Matricule = "aucun(ne)";
            employer.Date_naissance = "aucun(ne)";
            employer.Numero_cin = "aucun(ne)";
            employer.Contact = "aucun(ne)";
            employer.Direction = "aucun(ne)";
            employer.Fonction = "aucun(ne)";
            Boolean idExist = false;
            for (int i = 0; i < EmployerModel.getAll().Count; i++)
            {
                if (ID_Candidat == EmployerModel.getAll()[i].ID_Candidat)
                {
                    employer = EmployerModel.getAll()[i];
                    idExist = true;
                    break;
                }
            }
            if (idExist)
            {
                ficherdepaix.salaireDeBase = "salaire de base disponible";
                ficherdepaix.tauxJournaliers = "taux journalier disponible";
                ficherdepaix.tauxHoraires = "taux horaire disponible";
                ficherdepaix.dateDebut = "34/56/6789";
                ficherdepaix.dateFin = "34/24/3400";
                ficherdepaix.montantSalaireDuDate = "800 Ariary";
                ficherdepaix.nombreDabsenceDeductible = "5 jours";
                ficherdepaix.montantDabsence = "5 Ariary";
            }else{
                using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("select * from fiche_de_paie_details where matricule='"+ID_Candidat+"'and date_debut='"+date_debut+"'", conn))
                    // and date_debut>'2023-10-20'
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Utilisation d'une boucle while pour parcourir tous les enregistrements
                            {
                            ficherdepaix.dateDebut = reader["date_debut"].ToString();
                            ficherdepaix.dateFin = reader["date_fin"].ToString();
                            ficherdepaix.nombreJours = reader["nombre_de_jours"].ToString();
                            ficherdepaix.salaireDeBase = reader["salaire_de_base"].ToString();
                            ficherdepaix.heureSup30 = reader["heure_sup_30"].ToString();
                            ficherdepaix.heureSup40 = reader["heure_sup_40"].ToString();
                            ficherdepaix.heureSup50 = reader["heure_sup_50"].ToString();
                            ficherdepaix.heureSup100 = reader["heure_sup_100"].ToString();
                            ficherdepaix.primeDeRendement = reader["prime_de_rendement"].ToString();
                            ficherdepaix.primeDanciennete = reader["prime_d_anciennete"].ToString();
                            ficherdepaix.majorationHeureNuit = reader["majoration_heure_nuit"].ToString();
                            ficherdepaix.primeDiverse = reader["prime_diverse"].ToString();
                            ficherdepaix.rappelsPeriodeAnterieure = reader["rappels_periode_anterieure"].ToString();
                            ficherdepaix.droitConge = reader["droit_conge"].ToString();
                            ficherdepaix.droitPreavis = reader["droit_preavis"].ToString();
                            ficherdepaix.indemniteDeLicenciement = reader["indemnite_de_licenciement"].ToString();
                            ficherdepaix.joursAbsence = reader["jours_absence"].ToString();
                            }
                        }
                    }
                }
            }
            }
            ficherdepaix.employer = employer;
            return ficherdepaix;
        }
    


    public static List<FicheDePaieDetails> AllFiche()
{
    List<FicheDePaieDetails> fiches = new List<FicheDePaieDetails>();

    using (NpgsqlConnection conn = new Connection().GetConnection())
    {
        if (conn != null)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM fiche_de_paie_details", conn))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FicheDePaieDetails ficherdepaix = new FicheDePaieDetails();

                        ficherdepaix.dateDebut = reader["date_debut"].ToString();
                        ficherdepaix.dateFin = reader["date_fin"].ToString();
                        ficherdepaix.nombreJours = reader["nombre_de_jours"].ToString();
                        ficherdepaix.salaireDeBase = reader["salaire_de_base"].ToString();
                        ficherdepaix.heureSup30 = reader["heure_sup_30"].ToString();
                        ficherdepaix.heureSup40 = reader["heure_sup_40"].ToString();
                        ficherdepaix.heureSup50 = reader["heure_sup_50"].ToString();
                        ficherdepaix.heureSup100 = reader["heure_sup_100"].ToString();
                        ficherdepaix.primeDeRendement = reader["prime_de_rendement"].ToString();
                        ficherdepaix.primeDanciennete = reader["prime_d_anciennete"].ToString();
                        ficherdepaix.majorationHeureNuit = reader["majoration_heure_nuit"].ToString();
                        ficherdepaix.primeDiverse = reader["prime_diverse"].ToString();
                        ficherdepaix.rappelsPeriodeAnterieure = reader["rappels_periode_anterieure"].ToString();
                        ficherdepaix.droitConge = reader["droit_conge"].ToString();
                        ficherdepaix.droitPreavis = reader["droit_preavis"].ToString();
                        ficherdepaix.indemniteDeLicenciement = reader["indemnite_de_licenciement"].ToString();
                        ficherdepaix.joursAbsence = reader["jours_absence"].ToString();

                        // Récupérez les détails de l'employeur associé à la fiche de paie
                        string ID_Candidat = reader["matricule"].ToString();
                        EmployerModel employer = EmployerModel.GetProfil(ID_Candidat);

                        ficherdepaix.employer = employer;

                        fiches.Add(ficherdepaix);
                    }
                }
            }
        }
    }

    return fiches;
}

    
    public static void insertFicheDePaie(
        string employer, 
        string dateDebut, 
        string dateFin, 
        string nombreJours, 
        string salaireDeBase, 
        string heureSup30, 
        string heureSup40, 
        string heureSup50, 
        string heureSup100, 
        string primeDeRendement,
        string primeDanciennete, 
        string majorationHeureNuit,
        string primeDiverse, 
        string rappelsPeriodeAnterieure, 
        string droitConge, 
        string droitPreavis, 
        string indemniteDeLicenciement,
        string joursAbsence) {
           using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                      cmd.Connection = conn;
                        cmd.CommandText = "insert into fiche_de_paie_details(matricule,date_debut ,date_fin ,nombre_de_jours,salaire_de_base,heure_sup_30,heure_sup_40,heure_sup_50,heure_sup_100,prime_de_rendement,prime_d_anciennete,majoration_heure_nuit,prime_diverse,rappels_periode_anterieure,droit_conge,droit_preavis,indemnite_de_licenciement,jours_absence)"+
                        "values ('"+employer+"','"+dateDebut+"','"+dateFin+"','"+nombreJours+"','"+
                        salaireDeBase+"','"+heureSup30+"','"+heureSup40+"','"+
                        heureSup50+"','"+heureSup100+"','"+primeDeRendement+"','"+primeDanciennete+"','"+majorationHeureNuit+"','"+
                        primeDiverse+"','"+rappelsPeriodeAnterieure+"','"+droitConge+"','"+droitPreavis+"','"+indemniteDeLicenciement+"','"+joursAbsence+"')";
                    cmd.ExecuteNonQuery();
                   }
                }
            }
        }

        public static void UpdateValue(string columnName, string value, string type, string date, string Matricule)
{
    DateTime datedebut = DateTime.Parse(date);
    int valeur = int.Parse(value);

    using (NpgsqlConnection conn = new Connection().GetConnection())
    {
        if (conn != null)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;

                string monthYearFilter = "EXTRACT(YEAR FROM date_debut) = @year AND EXTRACT(MONTH FROM date_debut) = @month";

                if (type == "change")
                {
                    cmd.CommandText = $"UPDATE fiche_de_paie_details SET {columnName} = @value WHERE {monthYearFilter} AND matricule = @Matricule";
                }
                else if (type == "add")
                {
                    cmd.CommandText = $"UPDATE fiche_de_paie_details SET {columnName} = {columnName} + @value WHERE {monthYearFilter} AND matricule = @Matricule";
                }
                else
                {
                    cmd.CommandText = $"UPDATE fiche_de_paie_details SET {columnName} = {1234567}";
                    return;
                }

                cmd.Parameters.AddWithValue("value", valeur);
                cmd.Parameters.AddWithValue("year", datedebut.Year);
                cmd.Parameters.AddWithValue("month", datedebut.Month);
                cmd.Parameters.AddWithValue("Matricule", Matricule);

                cmd.ExecuteNonQuery();
            }
        }
    }
}   
    
    public static List<string> AllDate()
{
    List<string> dates = new List<string>();

    using (NpgsqlConnection conn = new Connection().GetConnection())
    {
        if (conn != null)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("select date_debut from fiche_de_paie_details group by date_debut order by date_debut asc", conn))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dates.Add(reader["date_debut"].ToString());
                    }
                }
            }
        }
    }

    return dates;
}
   public static List<string> getAllMatriculeByDate(string date_debut)
{
    List<string> dates = new List<string>();

    using (NpgsqlConnection conn = new Connection().GetConnection())
    {
        if (conn != null)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("select matricule from fiche_de_paie_details where date_debut='"+date_debut+"'", conn))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dates.Add(reader["matricule"].ToString());
                    }
                }
            }
        }
    }

    return dates;
}


    }
}