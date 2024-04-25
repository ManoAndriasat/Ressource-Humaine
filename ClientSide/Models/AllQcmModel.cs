using Npgsql;
using System;
using System.Collections.Generic;

namespace RessourceHumaine
{
    public class AllQcm
    {
        public string ID_Besoin { get; set; }
        public string ID_Question { get; set; }
        public string Question { get; set; }
        public string Reponse { get; set; }
        public string Indice { get; set; }

        public static List<AllQcm> SelectAllByBesoin(string idBesoin)
        {
            List<AllQcm> allQcms = new List<AllQcm>();
            
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM AllQcm WHERE ID_Besoin = @ID_Besoin";
                        cmd.Parameters.AddWithValue("@ID_Besoin", idBesoin);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AllQcm qcm = new AllQcm
                                {
                                    ID_Besoin = reader["ID_Besoin"].ToString(),
                                    ID_Question = reader["ID_Question"].ToString(),
                                    Question = reader["Question"].ToString(),
                                    Reponse = reader["Reponse"].ToString(),
                                    Indice = reader["Indice"].ToString()
                                };
                                allQcms.Add(qcm);
                            }
                        }
                    }
                }
            }

            return allQcms;
        }

        public AllQcm GetQcmByQuestionID(List<AllQcm> allQcms, string ID_Question)
        {
            // Parcourir la liste des objets AllQcm pour trouver l'objet correspondant à l'ID de la question
            foreach (var qcm in allQcms)
            {
                if (qcm.ID_Question == ID_Question)
                {
                    return qcm; // Renvoyer l'objet trouvé
                }
            }

            // Si aucun objet correspondant n'est trouvé, renvoyer null
            return null;
        }

    }
}
