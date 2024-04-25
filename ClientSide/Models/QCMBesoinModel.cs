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
public static List<QCMBesoinModel> SelectAll(string idBesoin)
{
    List<QCMBesoinModel> qcmBesoins = new List<QCMBesoinModel>();

    using (NpgsqlConnection conn = new Connection().GetConnection())
    {
        if (conn != null)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM QCMBesoin WHERE ID_Besoin = @ID_Besoin";
                
                // Définir le type de données du paramètre et sa valeur
                cmd.Parameters.Add(new NpgsqlParameter("@ID_Besoin", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters["@ID_Besoin"].Value = idBesoin;

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string idQuestion = reader.GetString(reader.GetOrdinal("ID_Question"));
                        QCMBesoinModel qcmBesoin = new QCMBesoinModel(idBesoin, idQuestion);
                        qcmBesoins.Add(qcmBesoin);
                    }
                }
            }
        }
    }

    return qcmBesoins;
}


    }
}
