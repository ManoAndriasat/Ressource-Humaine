using Npgsql;
using System;

namespace RessourceHumaine
{
    public class CoefficientModel
    {
        public string ID_Besoin { get; set; }
        public string Titre { get; set; }
        public string ValueTitre { get; set; } // Nouvelle colonne
        public int Indice { get; set; }
        public int Coefficient { get; set; }

        public CoefficientModel(string idBesoin, string titre, string valueTitre, int indice, int coefficient)
        {
            ID_Besoin = idBesoin;
            Titre = titre;
            ValueTitre = valueTitre; // Initialisation de la nouvelle colonne
            Indice = indice;
            Coefficient = coefficient;
        }

        public CoefficientModel(){}

        public static void InsertCoefficient(CoefficientModel coefficient)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO Coefficient (ID_Besoin, Titre, ValueTitre, Indice, Coefficient) " +
                                          "VALUES (@ID_Besoin, @Titre, @ValueTitre, @Indice, @Coefficient)";

                        cmd.Parameters.AddWithValue("@ID_Besoin", coefficient.ID_Besoin);
                        cmd.Parameters.AddWithValue("@Titre", coefficient.Titre);
                        cmd.Parameters.AddWithValue("@ValueTitre", coefficient.ValueTitre); // Utilisation de la nouvelle colonne
                        cmd.Parameters.AddWithValue("@Indice", coefficient.Indice);
                        cmd.Parameters.AddWithValue("@Coefficient", coefficient.Coefficient);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static List<CoefficientModel> SelectCoefficientByID(string id)
        {
            List<CoefficientModel> coefficients = new List<CoefficientModel>();

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Coefficient WHERE ID_Besoin = @ID_Besoin", conn))
                {
                    cmd.Parameters.AddWithValue("@ID_Besoin", id);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CoefficientModel coefficient = new CoefficientModel
                            {
                                ID_Besoin = reader["ID_Besoin"].ToString(),
                                Titre = reader["Titre"].ToString(),
                                ValueTitre = reader["ValueTitre"].ToString(),
                                Indice = Convert.ToInt32(reader["Indice"]),
                                Coefficient = Convert.ToInt32(reader["Coefficient"])
                            };
                            coefficients.Add(coefficient);
                        }
                    }
                }
            }

            return coefficients;
        }


        public static int ScoreCV(List<CoefficientModel> coefficients, CandidatModel candidat)
        {
            int score = 0;

            // Comparer chaque coefficient avec les propriétés correspondantes du candidat
            foreach (CoefficientModel coefficient in coefficients)
            {
                if (coefficient.ValueTitre == candidat.Genre ||
                    coefficient.ValueTitre == candidat.Situation ||
                    coefficient.ValueTitre == candidat.Experience ||
                    coefficient.ValueTitre == candidat.Proximite ||
                    coefficient.ValueTitre == candidat.DiplomeNiveau ||
                    coefficient.ValueTitre == candidat.DiplomeFiliere)
                {
                    score += coefficient.Indice * coefficient.Coefficient;
                }
            }

            return score;
        }


    }
}
