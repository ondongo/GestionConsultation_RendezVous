using consultationProjet.models;
using consultationProjet.repository;
using consultationProjet.repository.intertfaceRepositor;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public class Medserv : IMedServ
    {


        private IMedecinRepository medecinRepository;

        public Medserv(IMedecinRepository medecinRepository)
        {
            this.medecinRepository = medecinRepository;
        }

        public List<Medecin> ListerMedDispo()
        {
            return medecinRepository.findAll();
        }

      
        public Medecin TrouverbyIdMd(int id)
        {
            return medecinRepository.findById(id);
        }

        public bool modifDisponiliteAbsent(Medecin med)
        {
            string verif = med.Etat.ToString();
            if (verif == "Dispo")
            {

                medecinRepository.update(med);
                return true;
            };

            return false;
        }



        public bool modifDisponiliteDispo(Medecin med)
        {
            string verif = med.Etat.ToString();
            if (verif != "Dispo")
            {

                medecinRepository.updateEtatDispo(med);
                return true;
            };

            return false;
        }

        public List<Medecin> filtrerbyTypeMedecin(string type)
        {
            return medecinRepository.findbyTypeMedecin(type);
        }

        public List<Patient> findTousLesPatientsMed(int id)
        {
            return medecinRepository.listerTousLesPatientsMed(id);
        }
    }
}





