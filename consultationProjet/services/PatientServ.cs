using consultationProjet.models;
using consultationProjet.repository;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public class PatientServ : IservicePatient
    {

        private IPatientRepository ptRepository;

        public PatientServ(IPatientRepository ptRepository)
        {
            this.ptRepository = ptRepository;
        }




        public Patient ajouterPt(Patient pt)
        {
             return ptRepository.save(pt);
        }

        public List<Patient> selectPt()
        {
            return ptRepository.findAll();
        }

        public void SupprimerPt(int id)
        {
            throw new NotImplementedException();
        }

        public Patient TrouverbyIdPt(int id)
        {
            return ptRepository.findById(id);
        }

        public Patient TrouverbyRechercheBycode(string code)
        {
            return ptRepository.RechercheBycode(code) ;
        }
    }
}
