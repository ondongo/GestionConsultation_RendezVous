using consultationProjet.models;
using consultationProjet.Properties.models;
using consultationProjet.services;
using consultationProjet.views;
using consultationProjet.views.Iviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace consultationProjet.presenter
{
    public class menuPresenteur: ImenuPresenteur
    {

        private ImenuView view;
        // public IsecretaireView secretaireView;
        public IMedServ medservice;
        public IConsultationServ consultservice;
        
        public menuPresenteur(ImenuView view)



        {


            this.view = view;
           
            initialize();
            Callback();
            this.view.Show();

        }




        IEnumerable<Consultation> listCl_Med = new List<Consultation>();
        private BindingSource bindingConsult_Med = new BindingSource();

        public void initialize()
        {
            this.view.userLabel = this.view.UserConnect.Nom;
            this.view.userRole = this.view.UserConnect.Role.ToString();

           // MessageBox.Show(view.UserConnect.Id.ToString());


            //blo vu
            if (this.view.UserConnect.Role == RoleUsers.Medecin)
            {

                this.view.block();
            }

            if (this.view.UserConnect.Role == RoleUsers.Secretaire)
            {

                this.view.block1();
            }

            if (this.view.UserConnect.Role == RoleUsers.Rp)
            {

                this.view.block2();
            }

        }





        public void Callback()
        {

            this.view.showFormRp += showFormRpHandle;
            this.view.showFormSecretaire += showFormSecretaireHandle;
            this.view.showFormMedecin += showFormMedecinHandle;
            this.view.deconnexion1 += deconnexionHandle;
        }




            private void showFormMedecinHandle(object? sender, EventArgs e)
        {
            IMedView medView = MedecinForm.showForm(view as Form);

            new MedecinPresenteur(medView, view);

        }





        private void showFormSecretaireHandle(object? sender, EventArgs e)
        {
            IsecretaireView secretaireView = SecretaireForm.showForm(view as Form);

            new SecretairePresenteur(secretaireView);


        }

        private void showFormRpHandle(object? sender, EventArgs e)
        {
            IRpView rpView = RpForm.showForm(view as Form);

            new RpPresenteur(rpView, view);

        }


        // test deconnexion
        private void deconnexionHandle(object? sender, EventArgs e)
        {

            IconnexionView conn = new ConnexionForm();
            IconnexionPresenteur connPresenteur = new connexionPresenteur(conn);


            //view.Close();
            view.Hide();
            conn.Show();


        }





    }
}
