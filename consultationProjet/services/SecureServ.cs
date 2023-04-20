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
    public class SecureServ : ISecureServ
    {

        private IUserRepository userRepository;

        public SecureServ(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

       

        public User seConnecter(string login, string password)
        {
             User user=userRepository.findUserByLogin(login);


            //null user est null si exisste pwd # null
            return (user == null  || user.Password!= password) ? null : user;

        }





    }
}
