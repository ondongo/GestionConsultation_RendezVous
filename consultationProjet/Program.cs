using consultationProjet.models;
using consultationProjet.presenter;
using consultationProjet.views;
using consultationProjet.views.Iviews;
using System.Windows.Forms;

namespace consultationProjet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // IsecretaireView secretaireV = new SecretaireForm();
           //ISecretairePresenteur secretaireP = new SecretairePresenteur(secretaireV);

            //Application.Run(secretaireV as Form);




           // IMedView V = new MedecinForm();
          // IMedecinPresenteur P = new MedecinPresenteur(V);

           // Application.Run(V as Form);

          //  Application.Run(new MedecinForm());





            IconnexionView view = new ConnexionForm();
            IconnexionPresenteur conn = new connexionPresenteur(view);
            Application.Run(view as ConnexionForm);


            // Application.Run(new DashboardForm());





            //IRpView rpV = new RpForm();
            // IRpPresenteur rpP = new RpPresenteur(rpV);
            // ApplicationConfiguration.Initialize();
            //Application.Run(rpV as Form);


        }
    }
}