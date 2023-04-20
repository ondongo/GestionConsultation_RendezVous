using consultationProjet.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public interface IPrestationServ
    {
        public List<Prestation> FindAllprestations();
        public List<Prestation> FindAllprestationsByPt(int id);

        Prestation AjouterPrestation(Prestation prestation);
    }
}
