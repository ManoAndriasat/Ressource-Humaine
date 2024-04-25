using Npgsql;
using System;
using RessourceHumaine;


namespace RessourceHumaine
{
    public class FicheDePaie
    {
        public List<EmployerModel> employers { get; set;}
        public FicheDePaieDetails ficheDePaixDetail {get; set;}
        
    }
}