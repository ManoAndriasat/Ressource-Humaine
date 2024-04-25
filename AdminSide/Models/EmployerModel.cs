using Npgsql;
using System;

namespace RessourceHumaine
{
    public class EmployerModel
    {
        public string ID_Besoin { get; set; }
        public string ID_Candidat { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genre { get; set; }
        public string Email { get; set; }
        public string Situation { get; set; }
        public string Experience { get; set; }
        public string Proximite { get; set; }
        public string DiplomeNiveau { get; set; }
        public string DiplomeFiliere { get; set; }
        public string Matricule { get; set; }
        public string Date_naissance { get; set; }
        public string Numero_cin { get; set; }
        public string Contact { get; set; }
        public string Direction { get; set; }
        public string Fonction { get; set; }
        public string DateEmbauche {get; set;}
        public string nombreEmpHomme {get; set;}
        public string nombreEmpFemme {get; set;}
        public string infoH {get; set;}
        public string financeH {get; set;}
        public string marketingH {get; set;}
        public string infoF {get; set;}
        public string financeF {get; set;}
        public string marketingF {get; set;}

        public static string getnombreEmp(string type,string val,string genre){
            string requette = "SELECT count(*) count FROM liste_candidat_ambauche where "+type+"='"+val+"'";
            if(genre.Length>1){
                requette = "SELECT count(*) count FROM liste_candidat_ambauche where "+type+"='"+val+"' and genre='"+genre+"'";
            }
            string nombre = 9+"";
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(requette, conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Utilisation d'une boucle while pour parcourir tous les enregistrements
                            {
                                nombre = reader["count"].ToString();
                            }
                        }
                    }
                }
            }
            return nombre;
        }
    
        
        // calcul d'age
        public static string CalculerAge(string dateNaissanceStr)
        {
        // Analyse la chaîne de date/heure en un objet DateTime
        DateTime dateNaissance;
        if (DateTime.TryParseExact(dateNaissanceStr, "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out dateNaissance))
        {
            // Obtient la date/heure actuelle
            DateTime dateActuelle = DateTime.Now;

            // Calcule la différence entre la date actuelle et la date de naissance
            TimeSpan difference = dateActuelle - dateNaissance;

            // Calcule l'âge en fonction de la différence en années
            int age = (int)(difference.Days / 365.25);

            return age+" ans";
        }else{
            return "Erreur de calcul";
        }
        }

        // get all employer
        public static List<EmployerModel> getAll()
        {
            List<EmployerModel> allEmployer = new List<EmployerModel>();

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM liste_candidat_ambauche", conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Utilisation d'une boucle while pour parcourir tous les enregistrements
                            {
                                EmployerModel employer = new EmployerModel
                                {
                                    ID_Besoin = reader["ID_Besoin"].ToString(),
                                    ID_Candidat = reader["ID_Candidat"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Genre = reader["Genre"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Situation = reader["Situation"].ToString(),
                                    Experience = reader["Experience"].ToString(),
                                    Proximite = reader["Proximite"].ToString(),
                                    DiplomeNiveau = reader["DiplomeNiveau"].ToString(),
                                    DiplomeFiliere = reader["DiplomeFiliere"].ToString(),
                                    Matricule = reader["matricule"].ToString(),
                                    Date_naissance = CalculerAge(reader["date_naissance"].ToString()),
                                    DateEmbauche = reader["date_embauche"].ToString(),
                                    Numero_cin = reader["numero_cin"].ToString(),
                                    Contact = reader["contact"].ToString(),
                                    Direction = reader["direction"].ToString(),
                                    Fonction = reader["fonction"].ToString(),
                                    nombreEmpHomme = EmployerModel.getnombreEmp("genre","homme",""),
                                    nombreEmpFemme = EmployerModel.getnombreEmp("genre","femme",""),
                                    infoH = EmployerModel.getnombreEmp("direction","informatique","homme"),
                                    financeH = EmployerModel.getnombreEmp("direction","finance","homme"),
                                    marketingH = EmployerModel.getnombreEmp("direction","marketing","homme"),
                                    infoF = EmployerModel.getnombreEmp("direction","informatique","femme"),
                                    financeF = EmployerModel.getnombreEmp("direction","finance","femme"),
                                    marketingF = EmployerModel.getnombreEmp("direction","marketing","femme")
                                };

                                allEmployer.Add(employer);
                            }
                        }
                    }
                }
            }

            return allEmployer;
        }

public static EmployerModel GetProfil(string matricule)
{
    EmployerModel employer = null;

    using (NpgsqlConnection conn = new Connection().GetConnection())
    {
        if (conn != null)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM liste_candidat_ambauche WHERE matricule = @Matricule", conn))
            {
                cmd.Parameters.AddWithValue("@Matricule", matricule);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employer = new EmployerModel
                        {
                            ID_Besoin = reader["ID_Besoin"].ToString(),
                            ID_Candidat = reader["ID_Candidat"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Genre = reader["Genre"].ToString(),
                            Email = reader["Email"].ToString(),
                            Situation = reader["Situation"].ToString(),
                            Experience = reader["Experience"].ToString(),
                            Proximite = reader["Proximite"].ToString(),
                            DiplomeNiveau = reader["DiplomeNiveau"].ToString(),
                            DiplomeFiliere = reader["DiplomeFiliere"].ToString(),
                            Matricule = reader["matricule"].ToString(),
                            Date_naissance = CalculerAge(reader["date_naissance"].ToString()),
                                    DateEmbauche = reader["date_embauche"].ToString(),

                            Numero_cin = reader["numero_cin"].ToString(),
                            Contact = reader["contact"].ToString(),
                            Direction = reader["direction"].ToString(),
                            Fonction = reader["fonction"].ToString(),
                            nombreEmpHomme = EmployerModel.getnombreEmp("genre", "homme", ""),
                            nombreEmpFemme = EmployerModel.getnombreEmp("genre", "femme", ""),
                            infoH = EmployerModel.getnombreEmp("direction", "informatique", "homme"),
                            financeH = EmployerModel.getnombreEmp("direction", "finance", "homme"),
                            marketingH = EmployerModel.getnombreEmp("direction", "marketing", "homme"),
                            infoF = EmployerModel.getnombreEmp("direction", "informatique", "femme"),
                            financeF = EmployerModel.getnombreEmp("direction", "finance", "femme"),
                            marketingF = EmployerModel.getnombreEmp("direction", "marketing", "femme")
                        };
                    }
                }
            }
        }
    }

    return employer;
}


     public static List<EmployerModel> getEmployerAjax(string tri,string sort,string genre,string searchbar) {
        // searchbar
            string searchString = "Matricule like '%"+searchbar+"%' or firstname like '%"+searchbar+"%' or lastname like '%"+searchbar+"%' or Direction like '%"+searchbar+"%' or Fonction like '%"+searchbar+"%'";
            string requette = "SELECT * FROM liste_candidat_ambauche";
            if(genre=="tout"){
                if(searchbar.Length==0){
                    requette = requette+" order by "+sort+" "+tri;
                }else{
                    requette = requette+" where "+searchString+" order by "+sort+" "+tri;
                }
            }else{
                if(searchbar.Length==0){
                    requette = requette+" where genre='"+genre+"' "+" order by "+sort+" "+tri;
                }else{
                    requette = requette+" where ("+searchString+") and genre='"+genre+"' "+" order by "+sort+" "+tri;
                }
            }
            List<EmployerModel> allEmployer = new List<EmployerModel>();
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(requette, conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Utilisation d'une boucle while pour parcourir tous les enregistrements
                            {
                                EmployerModel employer = new EmployerModel
                                {
                                    ID_Besoin = reader["ID_Besoin"].ToString(),
                                    ID_Candidat = reader["ID_Candidat"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Genre = reader["Genre"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Situation = reader["Situation"].ToString(),
                                    Experience = reader["Experience"].ToString(),
                                    Proximite = reader["Proximite"].ToString(),
                                    DiplomeNiveau = reader["DiplomeNiveau"].ToString(),
                                    DiplomeFiliere = reader["DiplomeFiliere"].ToString(),
                                    Matricule = reader["matricule"].ToString(),
                                    Date_naissance = CalculerAge(reader["date_naissance"].ToString()),
                                    Numero_cin = reader["numero_cin"].ToString(),
                                    Contact = reader["contact"].ToString(),
                                    Direction = reader["direction"].ToString(),
                                    Fonction = reader["fonction"].ToString()
                                };

                                allEmployer.Add(employer);
                            }
                        }
                    }
                }
            }

            return allEmployer;
        }
    }
}