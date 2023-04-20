using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public interface IservicePatient
    {
       // public  filtre_by_id (int id);

        public void SupprimerPt(int id);

        public Patient ajouterPt(Patient pt);

        public Patient TrouverbyIdPt(int id);



        public List<Patient> selectPt();

        public Patient TrouverbyRechercheBycode(string code);

    }
}
