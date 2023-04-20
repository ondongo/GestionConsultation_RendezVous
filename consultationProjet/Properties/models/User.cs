using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.models
{
    public class User
    {
        private int id;
        private string login;
        private string password;
        private RoleUsers role;
        private string nom;

        public User()
        {
        }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public User(int id, string login, string password, string nom)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.nom = nom;
        }

        public User(string login, string password, RoleUsers role, string nom)
        {
            this.login = login;
            this.password = password;
            this.role = role;
            this.nom = nom;
        }

        public User(int id, string login, string password, RoleUsers role, string nom)
        {
            
           this.role = role;
           
        }

        [Required(ErrorMessage = "Login obligatoire")]
        public string Login { get => login; set => login = value; }

        [Required(ErrorMessage ="Mot de passe obligatoire")]
        [StringLength(10,MinimumLength =2,ErrorMessage ="Doit contenir entre 2 et 10 caracteres")]
        public string Password { get => password; set => password = value; }


        public RoleUsers Role { get => role; set => role = value; }
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }





        public override string? ToString()
        {

            return  nom;
        }
    }
}
