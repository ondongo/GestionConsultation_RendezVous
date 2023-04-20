using consultationProjet.Core;
using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.views.Iviews
{
    public interface IsecretaireView
    {

        
        void Show();



        /************************************************************/ //-----------------------------------------------------
        /*                                                          */
        //    //---------BINDINDSource -------
        /*                                                          */
        /************************************************************/ //-----------------------------------------------------
        void setRdvBindingSource(BindingSource antecedentList);

        void setdtgMed(BindingSource bindingSource);

        void setTrdvP(BindingSource bindingSource);

        void setHeureBindingSource(BindingSource bindingSource);

        void seteldyBoxBindingSource(BindingSource bindingSource);  



        void setdtgRdv(BindingSource bindingSource);

        //--------PR/PT/CL
        void setdtgTriple(BindingSource bindingSource);

        void setdtgR(BindingSource bindingSource);

        void setRecupAjout(BindingSource bindingSource);



        void setrecupsoignant(BindingSource bindingSource);


        TypeSoignant recupsoignant { get; set; }
      











        /************************************************************/
        /*                                                          */
        //             -------- PROPIETES ---
        /*                                                          */
        /************************************************************/


        DateTime Daterecherche { get; set; }

        DateTime DateAjout { get; set; }

        DateTime DaterechercheConsult { get; set; }

        //string CodeRecherche { set; get; }
        // string PatientRecherche { get; set; }

        //string TypeRecherche { get; set; }


        TypeRdv testP
        { 
            get ;
            set ;
        }


        TypeRdv RecupType
        {
            get;
            set;
        }

        TypeRdv eldyBoxRecup
        {
            get;
            set;
        }
        //pt --------------------------------recup
        string nomP { get; set; }
        string anteP { get; set; }
        Heure heureP { get; set; }
        string prenomP { get; set; }
       // string codeP { get; set; }


       string recupPt  { get; set; }

       string numeric { get; set; }










        /************************************************************/ //-----------------------------------------------------
        /*                                                          */
        //    //---------Event--callback -------
        /*                                                          */
        /************************************************************/ //-----------------------------------------------------


        ///--rdv
        event EventHandler ajouterRdv;

        event EventHandler modifierRdv;

        event EventHandler rechercherRdvParPatient;

        event EventHandler rechercherRdvParDate;

        event EventHandler supprimerRdv;
        event EventHandler rechercherRdvParType;

        event EventHandler SelectLigneDtgv;

        event EventHandler ChangeRp_M;



        //-------Patient
        event EventHandler addPatient;
        event EventHandler eventNouveauPt;



        //---------------------- Triple dtgv--------------
        event EventHandler findconsultation;
        event EventHandler findPatient;
        event EventHandler findprestationConsult;



        //----------filtreconsultation----------
        event EventHandler findconsultationByPt;
        event EventHandler filtrerconsultation;   
        
        //Methodes



    }
}
