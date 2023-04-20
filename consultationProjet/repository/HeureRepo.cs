using consultationProjet.models;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository
{
   public class HeureRepo: IHeureRepo
    {

        public List<Heure> listheure = new List<Heure>()
        {



            new Heure()
            {
                Id = 1,Libelle ="8H"
            },


             new Heure()
            {
                Id = 3,Libelle ="9H"
            },


              new Heure()
            {
                Id = 4,Libelle ="10H"
            },

               new Heure()
            {
                Id = 5,Libelle ="11H"
            },

                 new Heure()
            {
                Id = 6,Libelle ="12H"
            },


                   new Heure()
            {
                Id = 7,Libelle ="13H"
            },



                   new Heure()
            {
                Id = 8,Libelle ="14H"
            },

                new Heure()
            {
                Id = 9,Libelle ="15H"
            },

                new Heure()
            {
                Id = 10,Libelle ="16H"
            },

                    new Heure()
            {
                Id = 11,Libelle ="17H"
            },
        };

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Heure> findAll()
        {
            return listheure;
        }

        public Heure findById(int id)
        {
            throw new NotImplementedException();
        }

        public Heure save(Heure obj)
        {
            throw new NotImplementedException();
        }

        public void update(Heure obj)
        {
            throw new NotImplementedException();
        }
    }
}
