using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public interface IMedServ
    {
        public List<Medecin> ListerMedDispo();

        public Medecin TrouverbyIdMd(int id);

        public bool modifDisponiliteAbsent(Medecin med);

        public bool modifDisponiliteDispo(Medecin med);

        List<Medecin> filtrerbyTypeMedecin(string type);

        public List<Patient> findTousLesPatientsMed(int id);

    }
}
