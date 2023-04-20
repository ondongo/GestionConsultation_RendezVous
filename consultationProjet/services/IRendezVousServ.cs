using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public interface IRendezVousServ
    {
        public List<RendezVous> ListerRdv();







        public List<RendezVous> ListerRdv(string typeRdv);

        public void SupprimerRdv(int id);




        public void ajouterRdv(RendezVous rdv);

        public List<Antecedent> listAnte();

        public List<Heure> listHeure();








        public bool modifetatRdv(RendezVous rdv);

        public bool modifetatRdvValide(RendezVous rdv);




        




        public List<RendezVous> ListerRdvbydate(string date);






        public List<RendezVous> ListerRdvbyEtat(string etatRdv, string type, int id);




        public List<RendezVous> ListerRdvPrestationbydate(string date);




        public List<RendezVous> ListerRdvPres();
        public List<RendezVous> ListerRdvAnnule();




        public List<RendezVous> ListerRdvMed(int id);
        public List<RendezVous> ListerRdvRp(int id);






    }
}



