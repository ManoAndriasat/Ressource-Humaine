using Npgsql;
using System;
using System.Data;
using System.Collections.Generic;

namespace RessourceHumaine
{
    public class DemandeCongeModel
    {
        public string ID_Conge { get; set; }
        public string Matricule { get; set; }
        public DateTime DateDepart { get; set; }
        public DateTime DateRetour { get; set; }
        public string ID_TypeConge { get; set; }
        public string Motif { get; set; }
        public int Etat { get; set; }

        public static void InsertDemandeConge(DemandeCongeModel demande)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO DemandeConge VALUES (@IDConge , @Matricule, @DateDepart, @DateRetour, @ID_TypeConge, @Motif, @Etat)";
                    cmd.Parameters.AddWithValue("@IDConge", demande.ID_Conge);
                    cmd.Parameters.AddWithValue("@Matricule", demande.Matricule);
                    cmd.Parameters.AddWithValue("@DateDepart", demande.DateDepart);
                    cmd.Parameters.AddWithValue("@DateRetour", demande.DateRetour);
                    cmd.Parameters.AddWithValue("@ID_TypeConge", demande.ID_TypeConge);
                    cmd.Parameters.AddWithValue("@Motif", demande.Motif);
                    cmd.Parameters.AddWithValue("@Etat", demande.Etat);

                        cmd.ExecuteNonQuery();

                }
            }
        }

        public static List<DemandeCongeModel> SelectDemandeConge(int etat, string matricule)
        {
            List<DemandeCongeModel> demandes = new List<DemandeCongeModel>();

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT ID_Conge, Matricule, DateDepart, DateRetour, ID_TypeConge, Motif, Etat " +
                                    "FROM DemandeConge WHERE Etat = @Etat AND Matricule = @Matricule";
                    cmd.Parameters.AddWithValue("@Etat", etat);
                    cmd.Parameters.AddWithValue("@Matricule", matricule);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DemandeCongeModel demande = new DemandeCongeModel();
                            demande.ID_Conge = reader["ID_Conge"].ToString();;
                            demande.Matricule = reader["Matricule"].ToString();
                            demande.DateDepart = (DateTime)reader["DateDepart"];
                            demande.DateRetour = (DateTime)reader["DateRetour"];
                            demande.ID_TypeConge = reader["ID_TypeConge"].ToString();
                            demande.Motif = reader["Motif"].ToString();
                            demande.Etat = (int)reader["Etat"];

                            demandes.Add(demande);
                        }
                    }
                }
            }

            return demandes;
        }

        public static void UpdateEtatDemandeConge(string matricule, int nouvelEtat)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE DemandeConge SET Etat = @NouvelEtat WHERE Matricule = @Matricule";
                    cmd.Parameters.AddWithValue("@NouvelEtat", nouvelEtat);
                    cmd.Parameters.AddWithValue("@Matricule", matricule);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<DemandeCongeModel> AllDemande(int etat)
        {
            List<DemandeCongeModel> demandes = new List<DemandeCongeModel>();

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM CongeAffichage WHERE Etat = @Etat";
                    cmd.Parameters.AddWithValue("@Etat", etat);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DemandeCongeModel demande = new DemandeCongeModel();
                            demande.ID_Conge = reader["ID_Conge"].ToString();
                            demande.Matricule = reader["Matricule"].ToString();
                            demande.DateDepart = (DateTime)reader["DateDepart"];
                            demande.DateRetour = (DateTime)reader["DateRetour"];
                            demande.ID_TypeConge = reader["TypeConge"].ToString();
                            demande.Motif = reader["Motif"].ToString();
                            demande.Etat = (int)reader["Etat"];

                            demandes.Add(demande);
                        }
                    }
                }
            }

            return demandes;
        }

public static List<DemandeCongeModel> PrevisionConge(int etat)
        {
            List<DemandeCongeModel> demandes = new List<DemandeCongeModel>();

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM PrevisionConge WHERE Etat = @Etat AND DateDepart > NOW()";
                    cmd.Parameters.AddWithValue("@Etat", etat);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DemandeCongeModel demande = new DemandeCongeModel();
                            demande.ID_Conge = reader["direction"].ToString();
                            demande.Matricule = reader["Matricule"].ToString();
                            demande.DateDepart = (DateTime)reader["DateDepart"];
                            demande.DateRetour = (DateTime)reader["DateRetour"];
                            demande.ID_TypeConge = reader["Titre"].ToString();
                            demande.Motif = reader["Motif"].ToString();
                            demande.Etat = (int)reader["Etat"];

                            demandes.Add(demande);
                        }
                    }
                }
            }

            return demandes;
        }

        public static void UpdateEtatByCongeID(string idConge, int nouvelEtat)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE DemandeConge SET Etat = @NouvelEtat WHERE ID_Conge = @ID_Conge";
                    cmd.Parameters.AddWithValue("@NouvelEtat", nouvelEtat);
                    cmd.Parameters.AddWithValue("@ID_Conge", idConge);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GetID()
        {
            Connection connection = new Connection();

            using (NpgsqlConnection conn = connection.GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT nextval('IDConge')", conn))
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
        

        public static int GetTotalCongeDepense(string matricule, NpgsqlConnection connection)
        {
            int totalCongeDepense = 0;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "SELECT SUM(DateRetour - DateDepart) FROM DemandeConge WHERE  CAST(ID_TypeConge AS INTEGER) < 5";
                cmd.Parameters.AddWithValue("@Matricule", matricule);

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    totalCongeDepense = Convert.ToInt32(result);
                }
            }

            return totalCongeDepense;
        }

        public static int GetTotalCongeObtenu(string matricule, NpgsqlConnection connection)
        {
            int totalCongeObtenu = 0;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "SELECT EXTRACT(YEAR FROM age(CURRENT_DATE, date_embauche)) * 12 + EXTRACT(MONTH FROM age(CURRENT_DATE, date_embauche)) AS totalCongeObtenu FROM Candidat_Embauche WHERE Matricule = @Matricule";
                cmd.Parameters.AddWithValue("@Matricule", matricule);

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    totalCongeObtenu = Convert.ToInt32(result);
                }
            }

            return totalCongeObtenu;
        }

        public static double ResteConge(string matricule)
        {
            Connection connection = new Connection();
            using (NpgsqlConnection conn = connection.GetConnection())
            {
                int totalCongeObtenu = GetTotalCongeObtenu(matricule, conn);
                int totalCongeDepense = GetTotalCongeDepense(matricule, conn);
                double difference = (totalCongeObtenu * 2.5) - totalCongeDepense;
                return difference;
            }
        }



    }
}
