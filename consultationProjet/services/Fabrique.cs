using consultationProjet.presenter.repository.intertfaceRepositor;
using consultationProjet.repository;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace consultationProjet.services
{
    public class Fabrique
    {
        private static IRendezVousServ rdvserv;
        private static IRpserv rpserv;
        public static ISecureServ secure;
        public static IConsultationServ consult;
        public static IPrestationServ prest;

        //private static string chaine_connexion = " Data Source = GLOIRE_ODG_PC; Initial Catalog = RDV_database; Integrated Security = True";

        private static string chaine_connexion = " Data Source = GLOIRE_ODG_PC; Initial Catalog = gestin_rdv; Integrated Security = True";
        private static IUserRepository userRepository = new UserRepository(chaine_connexion);
        private static IPatientRepository patientRepository = new PatientRepository(chaine_connexion);
        private static IMedecinRepository medRepository= new MedecinRepository(chaine_connexion);
        private static IRpRepository rprepository = new RpRepository(chaine_connexion);


        private static IConsultationRepository consultRepository = new ConsultationRepository(chaine_connexion, patientRepository, medRepository);

        private static IPrestationRepository prestationRepository = new PrestationRepository(chaine_connexion, patientRepository, rprepository);



        

        private static IRendezVousRepository rdvRepo = new RendezVousRepository(chaine_connexion, patientRepository, medRepository, rprepository);

        private static IAntecedentRepo antRepo = new AntecedentRepository();
        private static IHeureRepo heureRepo = new HeureRepo();




        public static IConsultationServ getconsultServ()

        {
           return consult == null ? new ConsultationServ(consultRepository) : consult;

        }




        public static IPrestationServ getprestationServ()

        {
            return prest == null ? new PrestationServ(prestationRepository) : prest;

        }

        public static ISecureServ getSecureServ()

        {
            return secure == null ? new SecureServ(userRepository) : secure;

        }



        public static IRendezVousServ getRendezVousService()

        {
            if (rdvserv == null)
            {

                rdvserv = new RendezVousServ(rdvRepo, antRepo, heureRepo);

            }

            return rdvserv;

        }




        //------------------------ med-------------------------------------
        private static IMedServ medserv;
        private static IMedecinRepository medRepo = new MedecinRepository(chaine_connexion);

        public static IMedServ getMedService()

        {
            if (medserv == null)
            {

                medserv = new Medserv(medRepo);

            }

            return medserv;

        }


        private static IservicePatient ptserv;
        private static IPatientRepository ptRepo = new PatientRepository(chaine_connexion);

        public static IservicePatient getptService()

        {
            if (ptserv == null)
            {

                ptserv = new PatientServ(ptRepo);

            }

            return ptserv;

        }


        public static IRpserv getrpService()

        {
            if (rpserv == null)
            {

                rpserv = new RpServ(rprepository);

            }

            return rpserv;

        }

    }









    //------------------------ ssssss-------------------------------------
    //private static IMedServ medserv;
    //private static IMedecinRepository medRepo = new MedecinRepository(chaine_connexion);

    //public static IMedServ getMedService()

    //{
        //if (medserv == null)
        //{

           //medserv = new Medserv(medRepo);

        }

       // return medserv;

   // }

//}








    //-------connection

   




