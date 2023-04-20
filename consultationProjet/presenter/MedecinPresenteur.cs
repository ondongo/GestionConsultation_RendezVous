using consultationProjet.models;
using consultationProjet.Properties.models;
using consultationProjet.services;
using consultationProjet.views;
using consultationProjet.views.Iviews;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using User = consultationProjet.models.User;

namespace consultationProjet.presenter
{
    public class MedecinPresenteur: IMedecinPresenteur
    {
        public IRendezVousServ rdvservice;
        public IservicePatient patientservice;
        public IMedServ medservice;
        public IConsultationServ consultservice;
        public IMedView medView;
        public ImenuView menu;
        


        // -------------public IPrestationServ prservice;

        public MedecinPresenteur(IMedView medView, ImenuView menu)
                {
                    this.medView = medView;
                    this.menu = menu;
                   

                   
                    rdvservice = Fabrique.getRendezVousService();
                    medservice = Fabrique.getMedService();
                    patientservice = Fabrique.getptService();
                    consultservice = Fabrique.getconsultServ();
                    //prservice = Fabrique.getprestationServ();
                    Initialization();
                    CallBackEvent();






                     this.medView.Show();
                }

        //----------------------------------charger  bindingsource-----------------------------------
        //----------------------------------IEnumerable ==>toutes les collections--------------------

        IEnumerable<RendezVous> listRdv_Med = new List<RendezVous>();
        IEnumerable<Consultation> listCl_Med = new List<Consultation>();
        IEnumerable<Patient> listPt= new List<Patient>();
       
        private BindingSource bindingConsult_Med = new BindingSource();
       

        private BindingSource bindingRdv_Med = new BindingSource();
        private BindingSource bindingTension = new BindingSource();
        private BindingSource bindingPatient = new BindingSource();
        private BindingSource bindingEtat = new BindingSource();



        public void Initialization()
        {


            //string test = medView.numericTemperature + " °c";
            //MessageBox.Show(test);

            listRdv_Med = rdvservice.ListerRdv();
            bindingRdv_Med.DataSource = listRdv_Med;
            this.medView.setdtgRdvMed(bindingRdv_Med);





            //-------------------------obligé de passer par là

            
            

           // MessageBox.Show(menu.UserConnect.Id.ToString());
            listCl_Med = consultservice.ListConsultationByMed(menu.UserConnect.Id);
            bindingConsult_Med.DataSource = listCl_Med;
            this.medView.setdtgConsultationMed(bindingConsult_Med);





            //------TOP enum___list------
            //recuperer Enum en List
            List<Tension> listgloire = new List<Tension>();
            foreach (Tension value in Enum.GetValues(typeof(Tension)))
            {
                listgloire.Add(value);
            }

            bindingTension.DataSource = listgloire;
            this.medView.setTension(bindingTension);





            //------TOP enum___list------
            //recuperer Enum en List
            List<Etatrdv> listeTat = new List<Etatrdv>();
            foreach (Etatrdv value in Enum.GetValues(typeof(Etatrdv)))
            {
                listeTat.Add(value);
            }

            bindingEtat.DataSource = listeTat;
            this.medView.setEtat(bindingEtat);



        }






        //------------------------------------CallBackEvent----------------------------------------------
        public void CallBackEvent()
        {
            this.medView.VoirDossier += VoirDossierHandle;
            this.medView.VoirDetailsConsult += VoirDetailsConsultHandle;
            this.medView.radioCheckIndispo += radioCheckIndispoHandle;
            this.medView.radioCheckdispo += radioCheckdispoHandle;
            this.medView.filtrerRdvConsult += filtrerRdvConsultHandle;
            this.medView.listConsult += listConsultHandle;
            this.medView.listpatient += listpatientHandle;
            this.medView.ValiderMedEvent += ValiderMedEventHandle;
            this.medView.AnnulerMedEvent += AnnulerMedEventHandle;
            this.medView.AddConsult += AddConsultHandle;
            this.medView.filtrerEtatRdvMedEvent += FiltrerParEtathandle;
        }




        private void FiltrerParEtathandle(object? sender, EventArgs e)
        {
            listRdv_Med = rdvservice.ListerRdvbyEtat(medView.etatrdvRecup.ToString(), TypeRdv.Consultation.ToString(), menu.UserConnect.Id);
            bindingRdv_Med.DataSource = listRdv_Med;
            medView.setdtgRdvMed(bindingRdv_Med);
        }












        private void AddConsultHandle(object? sender, EventArgs e)
        {
            string t = medView.numericTemperature.ToString();

            string p = medView.numericPoid.ToString();
            RendezVous recup = bindingRdv_Med.Current as RendezVous;


            // if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom))
            ///{
            if (recup.Etatrdv == Etatrdv.Valide)
            {
                Consultation pr = new Consultation()
                {
                    //Code = "PAT0" + pt.IdPatient,

                    Temperature = t,
                    Patient = recup.Patient,
                    //Medecin= menu.UserConnect as Medecin ,
                    Poid =p,

                    Date = recup.Date,  



                };





                consultservice.AjouterConsultation(pr, menu.UserConnect.Id);
                MessageBox.Show("OK c'est ennregisté ");

            }


            else
            {

                MessageBox.Show("Valider ce RendezVous avant de le commencer ");
            }
            listCl_Med = consultservice.ListConsultationByMed(menu.UserConnect.Id);
            bindingConsult_Med.DataSource = listCl_Med;
        }









        /************************************************************/
        /*                                                          */
        //           --------Dingue disponibilté-------
        /*                                                          */
        /************************************************************/


        private void listConsultHandle(object? sender, EventArgs e)
        {
                listCl_Med = consultservice.ListConsultationByMed(menu.UserConnect.Id);
                bindingConsult_Med.DataSource = listCl_Med;
                this.medView.setdtgConsultationMed(bindingConsult_Med);
        }
        




        private void listpatientHandle(object? sender, EventArgs e)
        
        {
            listPt = medservice.findTousLesPatientsMed(menu.UserConnect.Id);
            bindingPatient.DataSource = listPt;
            this.medView.setdtgPatient(bindingPatient);
        }




        private void radioCheckIndispoHandle(object? sender, EventArgs e)
        {

            Medecin med = medservice.TrouverbyIdMd(menu.UserConnect.Id);
            
                medservice.modifDisponiliteAbsent(med);
            MessageBox.Show("disponnibilité est passé à Absent");


           

            //listRdv = rdvservice.ListerRdvAnnule();
            //bindingRdv.DataSource = listRdv;
            //secretaireView.setdtgRdv(bindingRdv);
        }



        private void radioCheckdispoHandle(object? sender, EventArgs e)
        {
          
            Medecin med = medservice.TrouverbyIdMd(menu.UserConnect.Id);
            // Medecin med = menu.UserConnect as Medecin;


            medservice.modifDisponiliteDispo(med);
            MessageBox.Show("disponnibilité est passé à Dispo");

            

          
            //listRdv = rdvservice.ListerRdvAnnule();
            //bindingRdv.DataSource = listRdv;
            //secretaireView.setdtgRdv(bindingRdv);
        }




        //Dingue-------------------------Handle()
        private void VoirDetailsConsultHandle(object? sender, EventArgs e)
        {


            Consultation cl = bindingConsult_Med.Current as Consultation;
            new DetailsConsultationPresenteur(cl, new detailsConsultation());



        }




        //Dingue-------------------------Handle()
        DossierMedicalePresenteur dossierMedicalePresenteur=null;
        private void VoirDossierHandle(object? sender, EventArgs e)
        {
            if (dossierMedicalePresenteur == null)
            {
                Patient pt = bindingPatient.Current as Patient;

                new DossierMedicalePresenteur(pt, new DossierMedical(), menu);
            }
        }



        private void filtrerRdvConsultHandle(object? sender, EventArgs e)
        {

            DateTime date = medView.dateTimeConsultEvent;

            //
            string date1 = date.ToShortDateString();
            listCl_Med = consultservice.ListConsultationByMedbyDate(date1,menu.UserConnect.Id);
            bindingConsult_Med.DataSource = listCl_Med;
            this.medView.setdtgConsultationMed(bindingConsult_Med);
        }







        private void AnnulerMedEventHandle(object? sender, EventArgs e)
        {
            try
            {

                //recupere rdv selectionnee
                RendezVous rdvSelect = bindingRdv_Med.Current as RendezVous;
                rdvservice.modifetatRdv(rdvSelect);
                listRdv_Med = rdvservice.ListerRdv();
                bindingRdv_Med.DataSource = listRdv_Med;
                medView.setdtgRdvMed(bindingRdv_Med);

            }
            catch (Exception ex)
            {

            }
        }

        private void ValiderMedEventHandle(object? sender, EventArgs e)
        {
            try
            {


                //recupere rdv selectionnee
                RendezVous rdvSelect = bindingRdv_Med.Current as RendezVous;
                rdvservice.modifetatRdvValide(rdvSelect);
                listRdv_Med = rdvservice.ListerRdv();
                bindingRdv_Med.DataSource = listRdv_Med;
                medView.setdtgRdvMed(bindingRdv_Med);

            }
            catch (Exception ex)
            {

            }
        }





        

















    }
    }
