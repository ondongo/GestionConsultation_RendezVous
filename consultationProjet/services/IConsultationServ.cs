using consultationProjet.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public interface IConsultationServ
    {
      public List<Consultation> findAllconsultation();
      public List<Consultation> findAllconsultationByPt(int id);
      public List<Consultation> findConsultationByDate(string date);


      public List<Consultation> ListConsultationByMed( int id);


      public List<Consultation> ListConsultationByMedbyDate(string date, int id);




      public List<Consultation> filterConsultUnPatient(int idPatient, int idUtilisateur);



      Consultation AjouterConsultation(Consultation consult,int id);





    }
}
