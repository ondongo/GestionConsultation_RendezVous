using consultationProjet.Core;
using consultationProjet.models;
using consultationProjet.Properties.models;
using consultationProjet.services;
using consultationProjet.views.Iviews;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace consultationProjet.presenter
{
    public class SecretairePresenteur : ISecretairePresenteur
    {

        //-------Dependance + Couplage faible
        public IRendezVousServ rdvservice;
        public IservicePatient ptservice;
        public IMedServ medservice;
        public IConsultationServ consultservice;
        public IsecretaireView secretaireView;
        public IPrestationServ prservice;
        public IRpserv rpservice;

        /************************************************************/
        /*                                                          */
        //         inversion de controle objet crée à l'exterieur 
        //                 injection de dependance
        /*                                                          */
        /************************************************************/

        public SecretairePresenteur(IsecretaireView secretaireView)
        {
            this.secretaireView = secretaireView;
            rdvservice = Fabrique.getRendezVousService();
            medservice = Fabrique.getMedService();
            ptservice = Fabrique.getptService();
            consultservice = Fabrique.getconsultServ();
            prservice = Fabrique.getprestationServ();
            rpservice = Fabrique.getrpService();
            Initialization();
            callbackEvent();
            this.secretaireView.Show();

        }






        /************************************************************/
        /*                                                          */
        //            //charger  bindingsource
        //            IEnumerable ==>toutes les collections
        /*                                                          */
        /************************************************************/

        IEnumerable<RendezVous> listRdv = new List<RendezVous>();
        IEnumerable<Medecin> listMed = new List<Medecin>();
        IEnumerable<Antecedent> anteced = new List<Antecedent>();
        IEnumerable<Heure> heur = new List<Heure>();
        IEnumerable<Patient> listPt = new List<Patient>();
        IEnumerable<Consultation> listCl = new List<Consultation>();
        IEnumerable<Prestation> listPr = new List<Prestation>();
        IEnumerable<Rp> listRp = new List<Rp>();








        /************************************************************/
        /*                                                          */
        //           ---------------Binding------------
        /*                                                          */
        /************************************************************/

        RendezVous rdvSelect;

        private BindingSource bindingRdv = new BindingSource();
        private BindingSource bindingMed = new BindingSource();
        private BindingSource Listant = new BindingSource();
        private BindingSource Listenum = new BindingSource();
        private BindingSource ListHeure = new BindingSource();
        private BindingSource bindingPatient = new BindingSource();
        private BindingSource bindingConsult = new BindingSource();
        private BindingSource bindingPrest = new BindingSource();
        private BindingSource Listeldyenum = new BindingSource();
        private BindingSource bindingRP_MED = new BindingSource();
        private BindingSource bindingRP = new BindingSource();





        public void Initialization()


        {


            listPt = ptservice.selectPt();
            bindingPatient.DataSource = listPt;
            secretaireView.setdtgTriple(bindingPatient);
            ;



            //----------------------------------------------------------
            listRdv = rdvservice.ListerRdv();
            bindingRdv.DataSource = listRdv;
            secretaireView.setdtgRdv(bindingRdv);

            //------------------------------------------------
            listMed = medservice.ListerMedDispo();
            bindingMed.DataSource = listMed;
            secretaireView.setdtgMed(bindingMed);


            //-------------------------------------
            anteced = rdvservice.listAnte();
            Listant.DataSource = anteced;



            //-----------------------------------
            heur = rdvservice.listHeure();
            ListHeure.DataSource = heur;
            secretaireView.setHeureBindingSource(ListHeure);

            //------------------






            //------TOP enum___list------
            //recuperer Enum en List
            List<TypeRdv> listglo = new List<TypeRdv>();
            foreach (TypeRdv value in Enum.GetValues(typeof(TypeRdv)))
            {
                listglo.Add(value);
            }
            Listenum.DataSource = listglo;
            secretaireView.setTrdvP(Listenum);




            List<TypeRdv> listeldy = new List<TypeRdv>();
            foreach (TypeRdv value in Enum.GetValues(typeof(TypeRdv)))
            {
                listeldy.Add(value);
            }
            Listeldyenum.DataSource = listeldy;
            secretaireView.seteldyBoxBindingSource(Listeldyenum);



            List<TypeSoignant> listrp_med = new List<TypeSoignant>();
            foreach (TypeSoignant value in Enum.GetValues(typeof(TypeSoignant)))
            {
                listrp_med.Add(value);
            }
            bindingRP_MED.DataSource = listrp_med;
            secretaireView.setrecupsoignant(bindingRP_MED);









            secretaireView.setRecupAjout(Listenum);
            secretaireView.setRdvBindingSource(Listant);


        }


        /************************************************************/
        /*                                                          */
        //           -----------fontion de rappel -------
        /*                                                          */
        /************************************************************/



        public void callbackEvent()
        {
            secretaireView.ajouterRdv += ajouterRdvHandle;
            secretaireView.modifierRdv += modifierRdvHandle;
            secretaireView.supprimerRdv += supprimerRdvHandle;
            secretaireView.rechercherRdvParPatient += rechercherRdvParPatientHandle;

            secretaireView.rechercherRdvParDate += rechercherRdvParDateHandle;
            secretaireView.rechercherRdvParType += rechercherRdvParTypeHandle;
            secretaireView.SelectLigneDtgv += SelectLigneDtgvHandle;



            secretaireView.findPatient += findPatientHandle;
            secretaireView.addPatient += addPatientHandle;



            // secretaireView.findconsultation += findconsultationHandle;
            secretaireView.findconsultationByPt += findconsultationByPtHandle;
            secretaireView.findprestationConsult += findprestationConsultHandle;




            secretaireView.filtrerconsultation += filtrerconsultationHandle;


            secretaireView.ChangeRp_M += ChangeRp_MHandle;
        }





        //----------------------------------------Handle DEBUT--------------------------------------

        private void ChangeRp_MHandle(object? sender, EventArgs e)
        {
            if (secretaireView.recupsoignant.ToString() == "Rp")
            {
                listRp = rpservice.SelectAllRpDispo();
                bindingRP.DataSource = listRp;
                secretaireView.setdtgMed(bindingRP);
            }

            if (secretaireView.recupsoignant.ToString() == "Generaliste")
            {

                listMed = medservice.filtrerbyTypeMedecin("Generaliste");

                bindingMed.DataSource = listMed;
                secretaireView.setdtgMed(bindingMed);



            }






            if (secretaireView.recupsoignant.ToString() == "Specialiste")
            {

                listMed = medservice.filtrerbyTypeMedecin("Specialiste");
                bindingMed.DataSource = listMed;
                secretaireView.setdtgMed(bindingMed);


            }
        }




        private void filtrerconsultationHandle(object? sender, EventArgs e)
        {
            DateTime date = secretaireView.DaterechercheConsult;

            //
            string date1 = date.ToShortDateString();


            listCl = consultservice.findConsultationByDate(date1);
            bindingConsult.DataSource = listCl;
            //secretaireView.rechercherRdvParType
        }

        

        /************************************************************/
        /*                                                          */
        //           --------Algorithme de Search -------
        /*                                                          */
        /************************************************************/


        private void findconsultationByPtHandle(object? sender, EventArgs e)
        {
            // if (!string.IsNullOrWhiteSpace(secretaireView.recupPt))
            //
            Patient recupPt = ptservice.TrouverbyRechercheBycode(secretaireView.recupPt);
            //string test = recupPt.IdPatient.ToString();

            //---Voir mon Id recupéré-------------
            // MessageBox.Show(test);

            if (recupPt != null)
            {
                int recupIdPt = recupPt.IdPatient;


                if (secretaireView.eldyBoxRecup.ToString() == "Consultation")
                {
                    listCl = consultservice.findAllconsultationByPt(recupIdPt);
                    bindingConsult.DataSource = listCl;
                    secretaireView.setdtgTriple(bindingConsult);

                    //------------------------------
                    int compteur = listCl.Count();

                    if (compteur == 0)
                    {
                        MessageBox.Show("Le patient " + recupPt.Nom + " n'a pas de consultation");
                    }


                    else
                    {
                        MessageBox.Show("Le patient " + recupPt.Nom + " a " + listCl.Count() + " consultation");
                    }



                }

                //----------------------------J'entre dans la Prestaion
                else
                {
                    listPr = prservice.FindAllprestationsByPt(recupIdPt);
                    bindingPrest.DataSource = listPr;
                    secretaireView.setdtgTriple(bindingPrest);

                    //------------------------------
                    int compteur = listPr.Count();

                    if (compteur == 0)
                    {
                        MessageBox.Show("Le patient " + recupPt.Nom + " n'a pas de Prestation");
                    }


                    else
                    {
                        MessageBox.Show("Le patient " + recupPt.Nom + " a " + listPr.Count() + " prestation");
                    }
                }



            }

            else


            {
                MessageBox.Show("Le patient " + secretaireView.recupPt + " n'existe");
            }

            // }
        }

        /************************************************************/
        /*                                                          */
        //           --------FIN  Algorithme de Search -------
        /*                                                          */
        /************************************************************/













        //---------------------HANDLE---RDVBYDATE
        private void rechercherRdvParDateHandle(object? sender, EventArgs e)
        {

            DateTime date = secretaireView.Daterecherche;

            //
            string date1 = date.ToShortDateString();


            listRdv = rdvservice.ListerRdvbydate(date1);
            bindingRdv.DataSource = listRdv;
            //secretaireView.rechercherRdvParType

            //Comme les Concatenations
             StringBuilder sb = new StringBuilder();
             sb.Append("Rdv").Append(" ").Append("ok");

            MessageBox.Show(sb.ToString());


        }

        //-------------------HandleSEARCHBYPT-------------------


        private void rechercherRdvParPatientHandle(object? sender, EventArgs e)
        {
            throw new NotImplementedException();




        }


        //-------------------HandleRDVSELECT-------------------

        private void SelectLigneDtgvHandle(object? sender, EventArgs e)
        {
            //recupere rdv selectionnee
            rdvSelect = bindingRdv.Current as RendezVous;
        }



        //-------------------HandleSEARCHBYTYPE-------------------

        private void rechercherRdvParTypeHandle(object? sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(secretaireView.TypeRecherche))
            //{
            listRdv = rdvservice.ListerRdv(secretaireView.RecupType.ToString());
            bindingRdv.DataSource = listRdv;
            secretaireView.setRdvBindingSource(bindingRdv);
            //}
        }


        //-------------------HandleDELETE-------------------

        private void supprimerRdvHandle(object? sender, EventArgs e)
        {
            try
            {
                if (rdvSelect.Etatrdv.ToString() != "Annule")
                {
                    MessageBox.Show("suppression impossible");
                }
                else
                {
                    rdvservice.SupprimerRdv(rdvSelect.Id);
                    MessageBox.Show("supprimé", "Ges_Rdv", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listRdv = rdvservice.ListerRdv();
                    bindingRdv.DataSource = listRdv;
                }


            }
            catch (Exception ex)
            {

            }

        }

        //-------------------HandleModif-------------------

        private void modifierRdvHandle(object? sender, EventArgs e)
        {
            try
            {


                rdvservice.modifetatRdv(rdvSelect);
                listRdv = rdvservice.ListerRdvAnnule();
                bindingRdv.DataSource = listRdv;
                secretaireView.setdtgRdv(bindingRdv);

            }
            catch (Exception ex)
            {

            }







        }


        /************************************************************/
        /*                                                          */
        //           --------DTGV TRIPLE -------
        /*                                                          */
        /************************************************************/




        private void findprestationConsultHandle(object? sender, EventArgs e)
        {
            if (secretaireView.eldyBoxRecup.ToString() == "Consultation")
            {
                listCl = consultservice.findAllconsultation();
                bindingConsult.DataSource = listCl;
                secretaireView.setdtgTriple(bindingConsult);
            }

            else
            {
                listPr = prservice.FindAllprestations();
                bindingPrest.DataSource = listPr;
                secretaireView.setdtgTriple(bindingPrest);

            }
        }


        private void findPatientHandle(object? sender, EventArgs e)
        {
            listPt = ptservice.selectPt();
            bindingPatient.DataSource = listPt;
            secretaireView.setdtgTriple(bindingPatient);

        }







        private void ajouterRdvHandle(object? sender, EventArgs e)
        {




            Patient patient = bindingPatient.Current as Patient;

            //if (patient == null)
           // {
                //patient = CreatePatient();
                //ptservice.ajouterPt(patient);


           // }


           // listPt = ptservice.selectPt();

            //bindingPatient.DataSource = listPt;



            DateTime date = secretaireView.DateAjout;


          

            TypeRdv valeurSelectionne = secretaireView.testP;

            Medecin med = bindingMed.Current as Medecin;




            Rp rp = bindingRP.Current as Rp;


            if (string.IsNullOrEmpty(secretaireView.numeric))

            {
                MessageBox.Show("Remplir toutes les infos");

            }
            string heure = secretaireView.numeric + " heure";




            /************************************************************/
            /*                                                          */
            //           --------Cas Du RP -------
            /*                                                          */
            /************************************************************/

            if (valeurSelectionne.ToString() == "Prestation" && rp != null)


            {
                RendezVous rdv = new RendezVous()
                {
                    TypeRdv = valeurSelectionne,
                    Patient = patient,

                    Date = date,
                    Heure = heure,
                    Rp = rp

                };

                if (date.CompareTo(DateTime.Now) > 0)
                {
                    rdvservice.ajouterRdv(rdv);
                    MessageBox.Show("RendezVous Ajouté avec succès");

                }

                else
                {
                    MessageBox.Show("Impossible selectionné une date superieur a celle d'aujourd'hui");
                }
               
            }





            /************************************************************/
            /*                                                          */
            //           --------Cas Du Med -------
            /*                                                          */
            /************************************************************/

            if (valeurSelectionne.ToString() == "Consultation" && med != null)
            {

                RendezVous rdv1 = new RendezVous()
                {
                    TypeRdv = valeurSelectionne,
                    Patient = patient,

                    Date = date,
                    Heure = heure,
                    Medecin = med
                };








                if (date.CompareTo(DateTime.Now) > 0)
                {
                    rdvservice.ajouterRdv(rdv1);

                    MessageBox.Show("RendezVous Ajouté avec succès");


                }


                else
                {
                    MessageBox.Show("Impossible selectionné une date superieur a celle d'aujourd'hui");
               
                }


            }







            if (valeurSelectionne.ToString() == "Prestation" && med != null)
            {

                MessageBox.Show("IMPOSSIBLE 1");

            }


            if (valeurSelectionne.ToString() == "Consultation" && rp!=null)
            {

                MessageBox.Show("IMPOSSIBLE 2");
            }


           

           
            listRdv = rdvservice.ListerRdv();
            bindingRdv.DataSource = listRdv;
        }


        /************************************************************/
        /*                                                          */
        //           --------Patient  -------
        /*                                                          */
        /************************************************************/
        //-------------------Handle-----Pt-------------------



        private void addPatientHandle(object? sender, EventArgs e)
        {

            //string code = secretaireView.codeP;
            string nom = secretaireView.nomP;
            string prenom = secretaireView.prenomP;
            string ante = secretaireView.anteP;


         
            MessageBox.Show(ante);
           // if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom))
            ///{
               if (nom != "" && prenom != "")
               {
                    Patient pt = new Patient()
                    {
                        //Code = "PAT0" + pt.IdPatient,
                        Nom = nom,
                        Prenom = prenom,
                        Antecedent = ante,
                        
               };
                /************************************************************/
                //        --------  codegeneration-------
                /************************************************************/


               Guid codegenr = Guid.NewGuid();
               pt.Code= "PAT//" + codegenr.ToString()+"//";




               MessageBox.Show(pt.Code);


                listPt = ptservice.selectPt();
                //int compteur = 0;
                foreach (Patient value in listPt)
                {
                    if (pt.Code != value.Code)
                    {
                       // compteur++; 

                        //if(compteur == 1)
                        //{
                            ptservice.ajouterPt(pt);
                          
                        }

                        else
                        {
                        MessageBox.Show("Impossible Code");
                        break;
                        }
                        

                    }
                   
                  
                
    

                }

                else
                {
           
                    MessageBox.Show("Remplir toutes les infos");

                }
                listPt = ptservice.selectPt();
                    bindingPatient.DataSource = listPt;
                }






            /*private Patient CreatePatient()
            {
                string nom = secretaireView.nomP;

                string prenom = secretaireView.prenomP;

                string ante = secretaireView.anteP;

                if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom))
                {
                    return null;
                }
                Patient patient = new Patient()
                {
                    Nom = nom,
                    Prenom = prenom,
                    Antecedent = ante,

                };

                //Comme les Concatenations
                // StringBuilder sb = new StringBuilder();
                //sb.Append("ISM").Append(" ").Append(patient.IdPatient);
                //patient.Code = sb.ToString();
                patient.Code = "ISM" + patient.IdPatient;
                return patient;
            }
            */




            //---------------------------------------Handle_______________________FIN______________________RDV_______________________________


































            //-------------------Handle---ADD----RDV-------------------

            /* private void ajouterRdvHandle(object? sender, EventArgs e)
              {
                  //string code = secretaireView.codeP;
                  string nom    = secretaireView.nomP;
                  string prenom = secretaireView.prenomP;
                  string ante = secretaireView.anteP;

                  Patient patient = null;

                  patient = bindingPatient.Current as Patient;






                  if (patient != null)
                  {


                      if (nom != "" && prenom != "")
                      {


                          patient = new Patient()
                          {

                              Nom = nom,
                              Prenom = prenom,
                              Antecedent = ante,

                          };


                          patient.Code = "ISM" + " " + patient.IdPatient;

                          ptservice.ajouterPt(patient);
                          listPt = ptservice.selectPt();
                          bindingPatient.DataSource = listPt;
                      }

                  }







                  //Patient pt = servicePatient.selectbycode(code);
                  Medecin med = bindingMed.Current as Medecin;


                      // Medecin med = bindingMed.Current as Use;


                      DateTime date = secretaireView.DateAjout;


                      //  String H = secretaireView.anteP.Libelle;
                      TypeRdv valeurSelectionne = secretaireView.testP;



                      string heure = secretaireView.numeric + " heure";


                  if(heure != "") {


                      string testfinal = valeurSelectionne.ToString();
                      RendezVous rdv = new RendezVous()
                      {
                          TypeRdv = valeurSelectionne,
                          Patient = patient,
                          Medecin = med,
                          Date = date,
                          Heure = heure,  



                      };

                      // Patient 
                      rdvservice.ajouterRdv(rdv);
                      MessageBox.Show("RendezVous Ajouté avec succès");
                      listRdv = rdvservice.ListerRdv();
                      bindingRdv.DataSource = listRdv;


                  }

                  else
                  {
                      MessageBox.Show("Remplir toutes les infos");
                  }

              }
              */
































        


    }
}