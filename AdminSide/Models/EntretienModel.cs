using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;


namespace RessourceHumaine
{
    public class EntretienModel
    {
        public string ID_Candidat { get; set; }
        public string Prenom { get; set; } // Nouvelle propriété
        public string Nom { get; set; } // Nouvelle propriété
        public string Sexe { get; set; }
        public string PosteRecherche { get; set; }
        public decimal Note { get; set; }

        public EntretienModel()
        {
        }

        public EntretienModel(string idCandidat, string prenom, string nom, string sexe, string posteRecherche, decimal note)
        {
            ID_Candidat = idCandidat;
            Prenom = prenom;
            Nom = nom;
            Sexe = sexe;
            PosteRecherche = posteRecherche;
            Note = note;
        }

        public static List<EntretienModel> GetCandidat()
        {
            List<EntretienModel> employees = new List<EntretienModel>();

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM Entretien WHERE Note IS NOT NULL AND Note <> 0 ORDER BY Note DESC";

                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                EntretienModel employee = new EntretienModel
                                {
                                    ID_Candidat = row["ID_Candidat"].ToString(),
                                    Prenom = row["Prenom"].ToString(), // Extraction du prénom
                                    Nom = row["Nom"].ToString(), // Extraction du nom
                                    Sexe = row["Sexe"].ToString(),
                                    PosteRecherche = row["PosteRecherche"].ToString(),
                                    Note = Convert.ToDecimal(row["Note"])
                                };

                                employees.Add(employee);
                            }
                        }
                    }
                }
            }

            return employees;
        }


    }
}
