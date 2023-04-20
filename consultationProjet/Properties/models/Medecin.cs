using consultationProjet.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.models
{
    public class Medecin: User
    {

        private TypeMedecin typeMedecin;
        
        private Etat etat;


        public TypeMedecin TypeMedecin { get => typeMedecin; set => typeMedecin = value; }

       
        public Etat Etat { get => etat; set => etat = value; }











        public override string ToString()
        {
            return base.ToString();
        }



    }
}



