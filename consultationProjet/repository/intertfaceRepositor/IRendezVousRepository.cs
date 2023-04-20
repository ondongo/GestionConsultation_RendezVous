using consultationProjet.models;
using consultationProjet.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository.intertfaceRepositor
{
    public interface IRendezVousRepository  : IRepo<RendezVous>
    {
        
        
        public List<RendezVous> findByType(string typeRdv);
        public List<RendezVous> findByEtat(string etatRdv,string type,int id);
        public List<RendezVous> findBydate(string date);








        public List<RendezVous> findByPrestation();
        //faire ajout --- modif
        void persit (RendezVous rdv);


        public List<RendezVous> findByAllAnnule();

        public List<RendezVous> findPrestationBydate(string date);


        public List<RendezVous> findRDVMED(int id);
        public List<RendezVous> findRDVRp(int id);


        public void Validation(RendezVous rdv);











    }












}
