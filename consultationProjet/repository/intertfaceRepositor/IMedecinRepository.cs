using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository.intertfaceRepositor
{
    public interface IMedecinRepository : IRepo<Medecin>
    {

        void updateEtatDispo(Medecin med);

        List<Medecin> findbyTypeMedecin(string type);

        List<Patient> listerTousLesPatientsMed(int id);

    }
}
