using Npgsql;
using System;

namespace RessourceHumaine
{
    public class QuestionModel
    {
        public string ID_Question { get; set; }
        public string Question { get; set; }
        public string BonneReponse { get; set; }

        // Default constructor
        public QuestionModel()
        {
        }

        // Parameterized constructor
        public QuestionModel(string idQuestion, string question, string bonneReponse)
        {
            ID_Question = idQuestion;
            Question = question;
            BonneReponse = bonneReponse;
        }

        public static void InsertQuestion(QuestionModel question)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO Question (ID_Question, question, bonneReponse) " +
                                          "VALUES (@ID_Question, @Question, @BonneReponse)";

                        cmd.Parameters.AddWithValue("@ID_Question", question.ID_Question);
                        cmd.Parameters.AddWithValue("@Question", question.Question);
                        cmd.Parameters.AddWithValue("@BonneReponse", question.BonneReponse);
                        
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
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT nextval('IDQuestion')", conn))
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

        public static List<QuestionModel> GetAllQuestions()
        {
            List<QuestionModel> questions = new List<QuestionModel>();

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Question", conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                QuestionModel question = new QuestionModel
                                {
                                    ID_Question = reader["ID_Question"].ToString(),
                                    Question = reader["question"].ToString(),
                                    BonneReponse = reader["bonneReponse"].ToString()
                                };
                                questions.Add(question);
                            }
                        }
                    }
                }
            }

            return questions;
        }
    }
}
