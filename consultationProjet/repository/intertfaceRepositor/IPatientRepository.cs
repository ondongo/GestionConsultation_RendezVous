using consultationProjet.models;
using consultationProjet.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository.intertfaceRepositor
{
    public interface IPatientRepository: IRepo<Patient>
    {
    
     
        Patient RechercheBycode(string code);


        //jointure
        List<Consultation> TrouverconsultationsPt(Patient patient);
    }
}
