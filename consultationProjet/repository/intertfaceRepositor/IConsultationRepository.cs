using consultationProjet.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository.intertfaceRepositor
{
    public interface IConsultationRepository : IRepo<Consultation>
    {

        List<Consultation> filtrerConsultationByPatient(int id);
        List<Consultation> filtrerConsultationBydate(string date);







        List<Consultation> ListerConsultationByMed(int id);
        List<Consultation> filtrerConsultationMedBydate(string date,int id);


        Consultation addtest(Consultation consultation,int id);    
        List<Consultation> filtrerConsultationUnPatient(int idPatient, int idUtilisateur);


    }
}
