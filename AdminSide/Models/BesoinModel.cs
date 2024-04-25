using Npgsql;
using System;

namespace RessourceHumaine
{
    public class BesoinModel
    {
        public string ID_Besoin { get; set; }
        public string Titre { get; set; }
        public string Service { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public int HeureParJour { get; set; }
        public int JourParSemaine { get; set; }

        public void InsertBesoin(BesoinModel besoin)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO Besoin (ID_Besoin, Titre, Service, Description, Type, Region, HeureParJour, JourParSemaine) " +
                                            "VALUES (@ID_Besoin, @Titre, @Service, @Description, @Type, @Region, @HeureParJour, @JourParSemaine)";

                        cmd.Parameters.AddWithValue("@ID_Besoin", besoin.ID_Besoin);
                        cmd.Parameters.AddWithValue("@Titre", besoin.Titre);
                        cmd.Parameters.AddWithValue("@Service", besoin.Service);
                        cmd.Parameters.AddWithValue("@Description", besoin.Description);
                        cmd.Parameters.AddWithValue("@Type", besoin.Type);
                        cmd.Parameters.AddWithValue("@Region", besoin.Region);
                        cmd.Parameters.AddWithValue("@HeureParJour", besoin.HeureParJour);
                        cmd.Parameters.AddWithValue("@JourParSemaine", besoin.JourParSemaine);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

            public int GetNextID()
            {
                Connection connection = new Connection();

                using (NpgsqlConnection conn = connection.GetConnection())
                {
                    if (conn != null)
                    {
                        using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT nextval('IDBesoin')", conn))
                        {
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                return Convert.ToInt32(result);
                            }
                        }
                    }
                    return 0;
                }
            }


    }
}
