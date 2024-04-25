
using Npgsql;
using System;
using RessourceHumaine;


namespace RessourceHumaine
{
    public class DateFicheDePaieModel{
        
        // listDate.Add(element)

        // select * from fiche_de_paie_details where matricule='3428' and date_debut='2023-10-20'
        

    public static List<string> getDateBymatricule(string matricule)
    {
        List<string> listDate = new List<string>();

            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT date_debut FROM fiche_de_paie_details where matricule='"+matricule+"'", conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listDate.Add(reader["date_debut"].ToString());
                            }
                        }
                    }
                }
            }
            return listDate;
        }
    }
}