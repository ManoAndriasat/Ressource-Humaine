using Npgsql;
using System;

namespace RessourceHumaine
{
    public class QCMBesoinModel
    {
        public string ID_Besoin { get; set; }
        public string ID_Question { get; set; }

        public QCMBesoinModel(string idBesoin, string idQuestion)
        {
            ID_Besoin = idBesoin;
            ID_Question = idQuestion;
        }

        public static void InsertQCMBesoin(QCMBesoinModel qcmBesoin)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO QCMBesoin (ID_Besoin, ID_Question) " +
                                          "VALUES (@ID_Besoin, @ID_Question)";

                        cmd.Parameters.AddWithValue("@ID_Besoin", qcmBesoin.ID_Besoin);
                        cmd.Parameters.AddWithValue("@ID_Question", qcmBesoin.ID_Question);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
