using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.dto
{
    public class MedecinDto { 


        private int id;
        private string login;

        private RoleUsers role;
        private string nom;
        private TypeMedecin typeMedecin;

        private Etat etat;

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public RoleUsers Role { get => role; set => role = value; }
        public string Nom { get => nom; set => nom = value; }
        public TypeMedecin TypeMedecin { get => typeMedecin; set => typeMedecin = value; }
        public Etat Etat { get => etat; set => etat = value; }
    }
}
