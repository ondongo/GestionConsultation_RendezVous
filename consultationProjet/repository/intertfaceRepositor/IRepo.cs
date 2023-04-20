using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository.intertfaceRepositor
{
    public interface IRepo<T>
        {
            //methode commune le T sera remplacer


        List<T> findAll();

        T findById(int id);

        T save(T obj);
        void update(T obj);
        void delete(int id);


    }
}
