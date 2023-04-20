using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.services
{
    public interface ISecureServ
    {
        User seConnecter(string login, string password);
       
    }

}
