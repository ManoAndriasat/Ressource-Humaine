using Npgsql;
using System;

namespace RessourceHumaine
{
    public class CandidatNoteModel
    {
        public string ID_Candidat { get; set; }
        public int Note { get; set; }

        public CandidatNoteModel(string idCandidat, int note)
        {
            ID_Candidat = idCandidat;
            Note = note;
        }

        public static void InsertCandidatNote(CandidatNoteModel candidatNote)
        {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO CandidatNote (ID_Candidat, Note) " +
                                          "VALUES (@ID_Candidat, @Note)";

                        cmd.Parameters.AddWithValue("@ID_Candidat", candidatNote.ID_Candidat);
                        cmd.Parameters.AddWithValue("@Note", candidatNote.Note);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
