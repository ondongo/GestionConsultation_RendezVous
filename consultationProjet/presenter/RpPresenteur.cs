using consultationProjet.models;
using consultationProjet.Properties.models;
using consultationProjet.services;
using consultationProjet.views.Iviews;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.presenter
{
    public class RpPresenteur : IRpPresenteur
    {

            public IRendezVousServ rdvservice;
          //  public IservicePatient ptservice;
            public IPrestationServ preservice;
            public IRpView rpView;
            public ImenuView menu;


        public RpPresenteur(IRpView rpView, ImenuView menu)
            {
            this.rpView = rpView;
                rdvservice = Fabrique.getRendezVousService();
                preservice = Fabrique.getprestationServ();
            this.menu = menu; 
            

            //  ptservice = Fabrique.getptService();
            Initialization();
                callbackEvent();
                this.rpView.Show();


            }



        /************************************************************/
        /*                                                          */
        //                  charger  bindingsource
        //          IEnumerable ==>toutes les collections
        /*                                                          */
        /************************************************************/


        IEnumerable<RendezVous> listRdvPres = new List<RendezVous>();
        IEnumerable<Prestation> listPres = new List<Prestation>();
        


        private BindingSource bindingRdvPres = new BindingSource();
        private BindingSource bindingPres = new BindingSource();
        private BindingSource bindingTypePres = new BindingSource();


        private BindingSource bindingEtat = new BindingSource();






        /************************************************************/
        /*                                                          */
        //                   Initialization
        /*                                                          */
        /************************************************************/

        public void Initialization()
            {
                //-------------------------------------------------
                listRdvPres = rdvservice.ListerRdvRp(menu.UserConnect.Id);
                bindingRdvPres.DataSource = listRdvPres;
                this.rpView.setdtgRdvPres(bindingRdvPres);




                listPres = preservice.FindAllprestations();
                bindingPres.DataSource = listPres;
                this.rpView.setdtgprestation(bindingPres);




            //------TOP enum___list------
            //recuperer Enum en List
            List<TypePrestation> listglo = new List<TypePrestation>();
            foreach (TypePrestation value in Enum.GetValues(typeof(TypePrestation)))
            {
                listglo.Add(value);
            }
            bindingTypePres.DataSource = listglo;
            rpView.setdtgTypePres(bindingTypePres);





            List<Etatrdv> listeTat = new List<Etatrdv>();
            foreach (Etatrdv value in Enum.GetValues(typeof(Etatrdv)))
            {
                listeTat.Add(value);
            }

            bindingEtat.DataSource = listeTat;
            this.rpView.setdtgEtat(bindingEtat);
        }







        /************************************************************/
        /*                                                          */
        //           --------callbackEvent -------
        /*                                                          */
        /************************************************************/
        public void callbackEvent()
            {

            this.rpView.rechercherRdvParDatePres += rechercherRdvParDatePresHandle;
            this.rpView.AddPresEvent += AddPresEventHandle;
            this.rpView.ValiderPresEvent += ValiderPresEventHandle;
            this.rpView.AnnulerPresEvent += AnnulerPresEventHandle;
            this.rpView.etatRdvEvent += etatRdvEventHandle;
        }

        private void etatRdvEventHandle(object? sender, EventArgs e)
        {
            listRdvPres = rdvservice.ListerRdvbyEtat(rpView.etatrdvRecup.ToString(), TypeRdv.Prestation.ToString(), menu.UserConnect.Id);
            bindingRdvPres.DataSource = listRdvPres;
            rpView.setdtgRdvPres(bindingRdvPres);
        }





        private void AnnulerPresEventHandle(object? sender, EventArgs e)
        {
            try
            {

                //recupere rdv selectionnee
                RendezVous rdvSelect = bindingRdvPres.Current as RendezVous;
                rdvservice.modifetatRdv(rdvSelect);
                listRdvPres = rdvservice.ListerRdvRp(menu.UserConnect.Id);
                bindingRdvPres.DataSource = listRdvPres;
                this.rpView.setdtgRdvPres(bindingRdvPres);

            }
            catch (Exception ex)
            {

            }
        }

        private void ValiderPresEventHandle(object? sender, EventArgs e)
        {
            try
            {

                //recupere rdv selectionnee
                RendezVous rdvSelect = bindingRdvPres.Current as RendezVous;
                rdvservice.modifetatRdvValide(rdvSelect);
                listRdvPres = rdvservice.ListerRdvRp(menu.UserConnect.Id);
                bindingRdvPres.DataSource = listRdvPres;
                this.rpView.setdtgRdvPres(bindingRdvPres);

            }
            catch (Exception ex)
            {

            }
        }









        /************************************************************/
        /*                                                          */
        //           ------------HANDLE -------
        /*                                                          */
        /************************************************************/


        private void AddPresEventHandle(object? sender, EventArgs e)
        {

            string resultats = rpView.recupResultat;
            TypePrestation typePrestation = rpView.RecupTypePres;

            RendezVous recup = bindingRdvPres.Current as RendezVous;

               // if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom))
               ///{
               if (recup.Etatrdv == Etatrdv.Valide) {
                Prestation pr = new Prestation()
                {
                    //Code = "PAT0" + pt.IdPatient,
                    ResultatPrestation = resultats,
                    DatePrestation = recup.Date,
                    Patient= recup.Patient,
                    TypePrestation = typePrestation,
                    Rp=recup.Rp,

                };


            if (resultats == "")
            {

                pr.ResultatPrestation = "Aucun résultat";
            }



            preservice.AjouterPrestation(pr);

            }


            else
            {

                MessageBox.Show("Valider ce RendezVous avant de le commencer ");
            }
            listPres = preservice.FindAllprestations();
            bindingPres.DataSource = listPres;
        }





        /************************************************************/
        /*                                                          */
        //           ------------HANDLE -------
        /*                                                          */
        /************************************************************/

        private void rechercherRdvParDatePresHandle(object? sender, EventArgs e)
            {

               DateTime date = this.rpView.DaterecherchePres;

               
                string date1 = date.ToShortDateString();




                    listRdvPres = rdvservice.ListerRdvPrestationbydate(date1);
                 bindingRdvPres.DataSource = listRdvPres;


                //secretaireView.rechercherRdvParType



            }










        }
    }
