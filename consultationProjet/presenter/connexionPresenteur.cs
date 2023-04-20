using consultationProjet.dto;
using consultationProjet.models;
using consultationProjet.services;
using consultationProjet.views;
using consultationProjet.views.Iviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.presenter
{
    public class connexionPresenteur : IconnexionPresenteur
    {
        private IconnexionView conn=null;
        private ISecureServ SecureServ=null;

        public connexionPresenteur(IconnexionView conn)
        {
            this.conn = conn;
            SecureServ = Fabrique.getSecureServ();
            this.conn.ConnexionEvent += ConnexionEventHandler;
        }

        private void ConnexionEventHandler(object? sender, EventArgs e)
        {




            string login=this.conn.Login;
            string password=this.conn.Password;

            


            try
            {
                //validator 
                ModelValidator.validate(new User() { Login = login, Password = password });
                //MessageBox.Show("ok");
                User user = SecureServ.seConnecter(login, password);
                if (user != null)
                {
                    this.conn.IsLoggedIn = true;



                    //chonn.Userargement form======> apres login



                    ImenuView menu = new DashboardForm();
                    menu.UserConnect = user;
                    ImenuPresenteur menuPresenteur = new menuPresenteur(menu);
                    //mask

                    conn.Hide();
                    // }




                }

                else
                {

                    this.conn.IsLoggedIn = false;
                    this.conn.Message = "Login ou mdp oublié";

                }



            }

            catch (Exception ex)
            {
                this.conn.IsLoggedIn = false;
                this.conn.Message = ex.Message;

            }

           

           
        }
    }
}
