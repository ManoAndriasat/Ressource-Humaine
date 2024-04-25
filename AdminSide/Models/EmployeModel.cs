using Npgsql;

namespace RessourceHumaine {
    public class EmployeModel {
        public string matricule { get; set; }
        public string idCandidat { get; set; }
        public DateTime dateNaissance { get; set; }
        public string numeroCin { get; set; }
        public string contact { get; set; }
        public string direction { get; set; }
        public string fonction { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string genre { get; set; }
        public string email { get; set; }

        public EmployeModel(string matricule, string idCandidat, DateTime dateNaissance, string numeroCin, string contact, string direction, string fonction, string firstName, string lastName, string genre, string email) {
            this.matricule = matricule;
            this.idCandidat = idCandidat;
            this.dateNaissance = dateNaissance;
            this.numeroCin = numeroCin;
            this.contact = contact;
            this.direction = direction;
            this.fonction = fonction;
            this.firstName = firstName;
            this.lastName = lastName;
            this.genre = genre;
            this.email = email;
        }

        // get all employe
        public static List<EmployeModel> getAllEmploye() {
            EmployeModel employe = null;
            List<EmployeModel> employeModels = new List<EmployeModel>();
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM employe", conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employe = new EmployeModel((string) reader["matricule"], (string) reader["id_candidat"], (DateTime) reader["date_naissance"], (string) reader["numero_cin"], (string) reader["contact"], (string) reader["direction"], (string) reader["fonction"], (string) reader["firstname"], (string) reader["lastname"], (string) reader["genre"], (string) reader["email"]);
                                employeModels.Add(employe);
                            }
                        }
                    }
                }

            }
            
            return employeModels;
        }

        // insertion employe salaire
        public static void insertSalaireBase(string matricule, double salaireBase) {
            using (NpgsqlConnection conn = new Connection().GetConnection())
            {
                if (conn != null)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO emp_salaire_de_base VALUES('" + matricule + "', " + salaireBase + ", '" + DateTime.Now.ToString("dd-MM-yyy") + "')";

                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }
    }
}