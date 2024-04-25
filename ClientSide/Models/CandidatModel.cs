using Npgsql;
using System;

namespace RessourceHumaine
{
    public class CandidatModel
    {
        public string ID_Besoin { get; set; }
        public string ID_Candidat { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genre { get; set; }
        public string Email { get; set; }
        public string Situation { get; set; }
        public string Experience { get; set; }
        public string Proximite { get; set; }
        public string DiplomeNiveau { get; set; }
        public string DiplomeFiliere { get; set; }

        public static void InsertCandidat(CandidatModel candidat)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO Candidat (ID_Besoin, ID_Candidat, FirstName, LastName, Genre, Email, Situation, Experience, Proximite, DiplomeNiveau, DiplomeFiliere) " +
                                          "VALUES (@ID_Besoin, @ID_Candidat, @FirstName, @LastName, @Genre, @Email, @Situation, @Experience, @Proximite, @DiplomeNiveau, @DiplomeFiliere)";

                        cmd.Parameters.AddWithValue("@ID_Besoin", candidat.ID_Besoin);
                        cmd.Parameters.AddWithValue("@ID_Candidat", candidat.ID_Candidat);
                        cmd.Parameters.AddWithValue("@FirstName", candidat.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", candidat.LastName);
                        cmd.Parameters.AddWithValue("@Genre", candidat.Genre);
                        cmd.Parameters.AddWithValue("@Email", candidat.Email);
                        cmd.Parameters.AddWithValue("@Situation", candidat.Situation);
                        cmd.Parameters.AddWithValue("@Experience", candidat.Experience);
                        cmd.Parameters.AddWithValue("@Proximite", candidat.Proximite);
                        cmd.Parameters.AddWithValue("@DiplomeNiveau", candidat.DiplomeNiveau);
                        cmd.Parameters.AddWithValue("@DiplomeFiliere", candidat.DiplomeFiliere);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static int GetNextID()
        {
            Connection connection = new Connection();

            using (NpgsqlConnection conn = connection.GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT nextval('IDCandidat')", conn))
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


        public static CandidatModel SelectCandidatByID(string ID_Candidat)
        {
            CandidatModel candidat = null;

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Candidat WHERE ID_Candidat = @ID_Candidat", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_Candidat", ID_Candidat);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                candidat = new CandidatModel
                                {
                                    ID_Besoin = reader["ID_Besoin"].ToString(),
                                    ID_Candidat = reader["ID_Candidat"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Genre = reader["Genre"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Situation = reader["Situation"].ToString(),
                                    Experience = reader["Experience"].ToString(),
                                    Proximite = reader["Proximite"].ToString(),
                                    DiplomeNiveau = reader["DiplomeNiveau"].ToString(),
                                    DiplomeFiliere = reader["DiplomeFiliere"].ToString()
                                };
                            }
                        }
                    }
                }
            }

            return candidat;
        }


        
    }
}
