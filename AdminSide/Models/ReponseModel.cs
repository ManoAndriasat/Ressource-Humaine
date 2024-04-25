using Npgsql;
using System;

namespace RessourceHumaine
{
    public class ReponseModel
    {
        public string ID_Question { get; set; }
        public string Reponse { get; set; }
        public string Indice { get; set; }

        public ReponseModel(string idQuestion, string Response, string indice)
        {
            ID_Question = idQuestion;
            Reponse = Response;
            Indice = indice;
        }
        
        public static void InsertReponse(ReponseModel reponse)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO Reponse (ID_Question, reponse, Indice) " +
                                          "VALUES (@ID_Question, @Reponse, @Indice)";

                        cmd.Parameters.AddWithValue("@ID_Question", reponse.ID_Question);
                        cmd.Parameters.AddWithValue("@Reponse", reponse.Reponse);
                        cmd.Parameters.AddWithValue("@Indice", reponse.Indice);
                        
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
