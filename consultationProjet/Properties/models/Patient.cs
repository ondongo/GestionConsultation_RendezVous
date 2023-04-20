using consultationProjet.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.models
{
     public class Patient
    {
        private int idPatient;
        private string code;
        private string nom;
        private string prenom;
        private string antecedent;



        List<Consultation> consultationlists;

        public int IdPatient { get => idPatient; set => idPatient = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Antecedent { get => antecedent; set => antecedent = value; }
        public string Code { get => code; set => code = value; }

        public List<Consultation> Consultationlists { get => consultationlists; set => consultationlists = value; }

        public override string? ToString()
        {
            return nom ;
        }
    }
}
