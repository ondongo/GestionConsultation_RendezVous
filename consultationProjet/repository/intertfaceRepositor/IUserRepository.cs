﻿using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository.intertfaceRepositor
{
    public interface IUserRepository
    {

        public User findUserByLogin(string login);


    }
}
