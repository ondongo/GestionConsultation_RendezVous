using consultationProjet.models;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public class RpServ : IRpserv
    {

        private IRpRepository rpRepository;

        public RpServ(IRpRepository rpRepository)
        {
            this.rpRepository = rpRepository;
        }

        public List<Rp> SelectAllRpDispo()
        {
            return rpRepository.listRpdipo();
        }







        public Rp TrouverbyIdrp(int id)
        {
            return rpRepository.findbyId(id);
        }
    }
}
