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
    public class RendezVousServ : IRendezVousServ
    {

        private IRendezVousRepository rendezVousRepository;








        private IAntecedentRepo antecedentRepository;
        private IHeureRepo heureRepository;


        public RendezVousServ(IRendezVousRepository rendezVousRepository, IAntecedentRepo antecedentRepository, IHeureRepo heureRepository)
        {
            this.rendezVousRepository = rendezVousRepository;
            this.antecedentRepository = antecedentRepository;
            this.heureRepository = heureRepository;
        }

        





        public List<RendezVous> ListerRdv()
        {
            return rendezVousRepository.findAll();
        }






        public List<Antecedent> listAnte()
        {
            return antecedentRepository.findAll();
        }







        public List<RendezVous> ListerRdv(string typeRdv)
        {
            return rendezVousRepository.findByType(typeRdv);



        }

        public void SupprimerRdv(int id)
        {
           rendezVousRepository.delete(id);
        }



        public void ajouterRdv(RendezVous rdv)
        {
            //var rendV = ListerRdv(rdv.typeRdv);
            //if (rendV.Count()==0)


            rendezVousRepository.save(rdv);
            //return true;
            //instr
        }

        public bool modifetatRdv(RendezVous rdv)
        {

            string verif = rdv.Etatrdv.ToString();


            //------------il manque la verification des 48h rendez peut etre annulé qu'après 48h

            //&& rdv.Date

            try { 
            if (verif == Etatrdv.Encours.ToString() )

            {
                rendezVousRepository.update(rdv);
                return true;

            };

            }


            catch { 
            MessageBox.Show("Aucun");

            }
            MessageBox.Show("Le Rdv est deja validé");
            return false;
        }




        public bool modifetatRdvValide(RendezVous rdv)
        {
            string verif = rdv.Etatrdv.ToString();


            //------------il manque la verification des 48h rendez peut etre annulé qu'après 48h

            //&& rdv.Date

            try
            {
                if (verif == Etatrdv.Encours.ToString())

            {
                rendezVousRepository.Validation(rdv);
                    MessageBox.Show("Le Rdv est validé");
                    return true;

            };


                MessageBox.Show("Le Rdv est annulé");
  
            }


            catch
            {
                MessageBox.Show("Aucun");

            }

            return false;

        }











        public List<RendezVous> ListerRdvbydate(string date)
        {
            return rendezVousRepository.findBydate(date);
        }

        public List<Heure> listHeure()
        {
            return heureRepository.findAll();
        }

        public List<RendezVous> ListerRdvPres()
        {
            return rendezVousRepository.findByPrestation();
        }

        public List<RendezVous> ListerRdvAnnule()
        {
            return rendezVousRepository.findByAllAnnule();
        }

        public List<RendezVous> ListerRdvPrestationbydate(string date)
        {
            return rendezVousRepository.findPrestationBydate(date);
        }



        public List<RendezVous> ListerRdvbyEtat(string etatRdv,string type, int id)
        {
            return rendezVousRepository.findByEtat(etatRdv,type,id);
        }



        public List<RendezVous> ListerRdvMed(int id)
        {
            return rendezVousRepository.findRDVMED(id);
        }

        public List<RendezVous> ListerRdvRp(int id)
        {
            return rendezVousRepository.findRDVRp(id);
        }
    }
    }

    

