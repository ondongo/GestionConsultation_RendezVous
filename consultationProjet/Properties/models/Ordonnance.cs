using consultationProjet.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.models
{
    public class Ordonnance
    {

        private List<Medicament> medicament;
        private string posologie;
        private Consultation consultation;
        public List<Medicament> Medicament { get => medicament; set => medicament = value; }
        public string Posologie { get => posologie; set => posologie = value; }
   
    
    
    
    
    }
}




