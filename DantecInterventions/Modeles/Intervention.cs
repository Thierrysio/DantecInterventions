using System;
using System.Collections.Generic;
using System.Text;

namespace DantecInterventions_.Modeles
{
    public class Intervention
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priorite { get; set; } = string.Empty;
        public string NomTechnicien { get; set; } = string.Empty;
        public bool EstTerminee { get; set; }
    }
}
