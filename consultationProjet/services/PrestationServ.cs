using consultationProjet.Properties.models;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{


    public class PrestationServ:IPrestationServ
    {
        private IPrestationRepository prestationRepository;

        public PrestationServ(IPrestationRepository prestationRepository)
        {
            this.prestationRepository = prestationRepository;
        }

        public Prestation AjouterPrestation(Prestation prestation)
        {
           return prestationRepository.save(prestation);
        }

        public List<Prestation> FindAllprestations()
        {
            return prestationRepository.findAll();
        }

        public List<Prestation> FindAllprestationsByPt(int id)
        {
            return prestationRepository.filtrerPrestationByPatient(id);
        }
    }


}
