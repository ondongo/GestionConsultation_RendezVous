using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.models
{
    public class Rp: User
    {
        private Etat etat;



        public Etat Etat { get => etat; set => etat = value;
        
        
      }




        public override string ToString()
        {
            return base.ToString();
        }

    }
}
