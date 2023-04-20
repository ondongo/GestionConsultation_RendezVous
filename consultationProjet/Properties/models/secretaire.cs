using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.models
{
    public class secretaire : User
    {
        public secretaire()
        {
        }

        public secretaire(string login, string password, RoleUsers role, string nom) : base(login, password, role, nom)
        {
        }

        public secretaire(int id, string login, string password, string nom) : base(id, login, password, nom)
        {
        }

        public secretaire(int id, string login, string password, RoleUsers role, string nom) : base(id, login, password, role, nom)
        {
        }

        public override string? ToString()

        {
            return base.ToString();
        }
    }
}
