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
    }
}
