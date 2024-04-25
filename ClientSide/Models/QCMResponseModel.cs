using Npgsql;
using System;
using System.Collections.Generic;

namespace RessourceHumaine
{
    public class QCMReponseModel
    {
        public string ID_Besoin { get; set; }
        public string ID_Candidat { get; set; }
        public string ID_Question { get; set; }
        public string Reponse { get; set; }

        public void InsertQCMReponse(QCMReponseModel qcmReponse)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO QCMReponse (ID_Besoin, ID_Candidat, ID_Question, Reponse) " +
                            "VALUES (@ID_Besoin, @ID_Candidat, @ID_Question, @Reponse)";
                        cmd.Parameters.AddWithValue("@ID_Besoin", qcmReponse.ID_Besoin);
                        cmd.Parameters.AddWithValue("@ID_Candidat", qcmReponse.ID_Candidat);
                        cmd.Parameters.AddWithValue("@ID_Question", qcmReponse.ID_Question);
                        cmd.Parameters.AddWithValue("@Reponse", qcmReponse.Reponse);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static List<QCMReponseModel> SelectQCMReponsesByID(string ID_Besoin, string ID_Candidat)
        {
            List<QCMReponseModel> qcmReponses = new List<QCMReponseModel>();

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM QCMReponse WHERE ID_Besoin = @ID_Besoin AND ID_Candidat = @ID_Candidat", conn))
                {
                    cmd.Parameters.AddWithValue("@ID_Besoin", ID_Besoin);
                    cmd.Parameters.AddWithValue("@ID_Candidat", ID_Candidat);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            QCMReponseModel qcmReponse = new QCMReponseModel
                            {
                                ID_Besoin = reader["ID_Besoin"].ToString(),
                                ID_Candidat = reader["ID_Candidat"].ToString(),
                                ID_Question = reader["ID_Question"].ToString(),
                                Reponse = reader["Reponse"].ToString()
                            };
                            qcmReponses.Add(qcmReponse);
                        }
                    }
                }
            }
            return qcmReponses;
        }


        public QCMReponseModel GetQCMReponseByQuestionID(List<QCMReponseModel> qcmReponses, string ID_Question)
        {
            foreach (var qcmReponse in qcmReponses)
            {
                if (qcmReponse.ID_Question == ID_Question)
                {
                    return qcmReponse; // Renvoyer la réponse trouvée
                }
            }
            return null;
        }

    

        public static int CompareAndCalculateScore(List<QuestionModel> questions, List<QCMReponseModel> qcmReponses)
        {
            int score = 0;
            foreach (var qcmReponse in qcmReponses)
            {
                foreach (var question in questions)
                {
                    if(qcmReponse.ID_Question==question.ID_Question){
                         if(qcmReponse.Reponse==question.BonneReponse){
                            score = score +10;
                        }
                    }
                }
            }
            return score;
        }
    }
}
