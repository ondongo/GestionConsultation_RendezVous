using consultationProjet.models;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository
{
    public class AntecedentRepository : IAntecedentRepo
    {
        //list

        public List<Antecedent> listAntecedents = new List<Antecedent>()
        {



            new Antecedent()
            {
                Id = 1,Libelle ="Corona-virus"
            },


             new Antecedent()
            {
                Id = 2,Libelle ="VirusProgrammation-Baila"
            },
        };
        
        
        
        
        
        
        
        
        
        
        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Antecedent> findAll()
        {
           return listAntecedents;
        }

        public Antecedent findById(int id)
        {
            throw new NotImplementedException();
        }

        public Antecedent save(Antecedent obj)
        {
            throw new NotImplementedException();
        }

        public void update(Antecedent obj)
        {
            throw new NotImplementedException();
        }
    }
}
