using consultationProjet.Properties.models;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public class ConsultationServ : IConsultationServ
    {

        private IConsultationRepository consultationRepository;

        public ConsultationServ(IConsultationRepository consultationRepository)
        {
            this.consultationRepository = consultationRepository;
        }

        public Consultation AjouterConsultation(Consultation consult, int id)
        {
            return consultationRepository.addtest(consult,id);
        }

        public List<Consultation> filterConsultUnPatient(int idPatient, int idUtilisateur)
        {
            return consultationRepository.filtrerConsultationUnPatient(idPatient,idUtilisateur);
        }

        public List<Consultation> findAllconsultation()
        {
            return consultationRepository.findAll();
        }



        public List<Consultation> findAllconsultationByPt(int id)
        {
            return consultationRepository.filtrerConsultationByPatient(id);
        }

        public List<Consultation> findConsultationByDate(string date)
        {
            return consultationRepository.filtrerConsultationBydate(date);
        }

        public List<Consultation> ListConsultationByMed(int id)
        {
            return consultationRepository.ListerConsultationByMed(id);
        }

        public List<Consultation> ListConsultationByMedbyDate(string date, int id)
        {
            return consultationRepository.filtrerConsultationMedBydate(date, id);
        }
    }
}
