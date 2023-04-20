using consultationProjet.Core;
using consultationProjet.models;
using consultationProjet.views.Iviews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace consultationProjet.views
{
    public partial class SecretaireForm : Form, IsecretaireView
    {
        public SecretaireForm()
        {
            InitializeComponent();
            //Mappage ecouteur et objet
            //delegate faire un link
            //methode appeler Invoke
            // txtNom.Visible = false;
            //desactivation();
            activeLesEventRdv();
            manipulationNumeric();
            //---------------------------clavier ==> keypress:appuyer keyup:laisser Keydown:enfonce 

        }

     

        /************************************************************/ //-----------------------------------------------------
        /*                                                          */
        //    //---------METHODES & DELEGATE -------
        /*                                                          */
        /************************************************************/ //-----------------------------------------------------

        public void desactivation()
        {
            txtNom.Enabled = false;
            txtPrenom.Enabled = false;
            richTextBox1.Enabled = false;
            //comboBox1.Enabled = false;
            dtgTriple.Enabled = true;

        }

       

        public void manipulationNumeric()
        {
            // Définition la plage de valeurs autorisées pour le NumericUpDown.
            numericUpDown1.Minimum = 8;
            numericUpDown1.Maximum = 18;

            // Définissez l'intervalle de changement de valeur à 1 heure.
            numericUpDown1.Increment = 1;
            //}



            // Affichez la valeur sélectionnée dans une boîte de message.
            //   MessageBox.Show("Heure sélectionnée : " + numericUpDown1.Value);
        }




        //----------------------------------DEBUT_DELEGATE_EVENT------------------------
        public void activeLesEventRdv()
        {



            modetat.Click += delegate
            {
                var rslt1 = MessageBox.Show("Confirmer annulation?", "Annuler Rdv",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);



                if (rslt1 == DialogResult.Yes)
                {
                    modifierRdv.Invoke(this, EventArgs.Empty);
                }
            };



            btnAnnuler.Click += delegate
            {
                var rslt = MessageBox.Show("Confirmer la suppression?", "Attention",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(rslt == DialogResult.Yes) {

                    supprimerRdv.Invoke(this, EventArgs.Empty);

                   
                }
               
            };





            btnAjouter.Click += delegate
            {
                var rslt = MessageBox.Show("Confirmer la prise du Rdv", "Attention",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rslt == DialogResult.Yes)
                {
                    ajouterRdv.Invoke(this, EventArgs.Empty);
                    txtNom.Clear();
                    txtPrenom.Clear();
                    richTextBox1.Clear();   

                }
            };


           // btnRpatient.Click += delegate
           // {
           //     rechercherRdvParPatient.Invoke(this, EventArgs.Empty);
           // };
           
            btnRdate.Click += delegate
            {
                rechercherRdvParDate.Invoke(this, EventArgs.Empty);
            };

            btnTrdv.Click += delegate
            {
                rechercherRdvParType.Invoke(this, EventArgs.Empty);
            };




            //appuyer
            //fonction anonyme
            //txtFiltreP.KeyDown += (s, e) =>
           /// {
                //s ==>source
                //e ==> argument

               // if (e.KeyCode == Keys.Enter)
               // {

                   // rechercherRdvParPatient.Invoke(this, EventArgs.Empty);
                    //chaque caractère est associe à un nbre
               // }
            //};


         //   txtFiltreT.KeyDown += (s, e) =>
           // {
                //s ==>source
                //e ==> argument

               // if (e.KeyCode == Keys.Enter)
               // {
                   // rechercherRdvParType.Invoke(this, EventArgs.Empty);
                    //chaque caractère est associe à un nbre
                //}
           // };

            //


            dtgRdv.SelectionChanged += delegate 
            {
                SelectLigneDtgv.Invoke(this, EventArgs.Empty);
            };




            nouveau.Click += delegate
            {


                addPatient.Invoke(this, EventArgs.Empty);


            };

            /*
            btnConsult.Click += delegate
            {
                findconsultation.Invoke(this, EventArgs.Empty);

                txtNom.Enabled = false;
                txtPrenom.Enabled = false;
                //txtcodeP.Enabled = false;
                richTextBox1.Enabled = false;
                dtgTriple.Enabled = true;
            };
            */

            eldyBox.SelectionChangeCommitted += delegate
            {
                findprestationConsult.Invoke(this, EventArgs.Empty);

                txtNom.Enabled = false;
                txtPrenom.Enabled = false;
                //txtcodeP.Enabled = false;
                richTextBox1.Enabled = false;
                dtgTriple.Enabled = true;
            };

            buttonPtFil.Click += delegate
            {
                findconsultationByPt.Invoke(this, EventArgs.Empty);
            };

            btnPatient.Click += delegate
            {
                findPatient.Invoke(this, EventArgs.Empty);
                txtNom.Enabled = true;
                txtPrenom.Enabled = true;
                //txtcodeP.Enabled = false;
                richTextBox1.Enabled = true;
            };






            dateTimeConsult.ValueChanged += delegate
            {
                filtrerconsultation.Invoke(this, EventArgs.Empty);
            };



            


            recupSoignant.SelectionChangeCommitted +=delegate
           // btnChangeSoignant.Click += delegate
            {


                dtgMed.Rows.Clear();
                ChangeRp_M.Invoke(this, EventArgs.Empty);
            };







        }
        //----------------------------------FIN------------------------



        /************************************************************/
        /*                                                          */
        //                --------SET & GET -------
        /*                                                          */
        /************************************************************/




        public string TypeRecherche {
            get => txtFiltreT.Text;
            set => txtFiltreT.Text = value;
        }
        


       public TypeRdv testP
        {
           get => (TypeRdv)cbxtypeRdv.SelectedItem;
           set => throw new NotImplementedException();
       }

        public TypeRdv RecupType { get => (TypeRdv)cbxtypeRdv.SelectedItem;
            set => throw new NotImplementedException(); }



        //----------------------------------DEBUT pt------------------------
        // public string codeP { get => txtcodeP.Text; set => txtcodeP.Text=value; }


        public string nomP { get => txtNom.Text; set => txtNom.Text = value; }
        public string prenomP { get => txtPrenom.Text; set => txtPrenom.Text = value; }
        public string anteP
        {
            get => richTextBox1.Text;
            set => richTextBox1.Text = value;
        }

        //---------FIN pt



        public string CodeRecherche { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        public Heure heureP
        {
            get => cbxheureP.SelectedItem as Heure;
            set => throw new NotImplementedException();
        }


        public string recupPt { get => PtRConsult.Text; set => PtRConsult.Text = value; }
        public DateTime DaterechercheConsult { get => dateTimeConsult.Value; set => throw new NotImplementedException(); }





        public DateTime Daterecherche
        {
            get => dateTimeFiltre.Value;
            set => throw new NotImplementedException();
        }





        public DateTime DateAjout
        {
            get => dateTimePickerAjout.Value;
            set => throw new NotImplementedException();
        }

        public string numeric { get => numericUpDown1.Value.ToString(); set => throw new NotImplementedException(); }
        public TypeRdv eldyBoxRecup { get => (TypeRdv)eldyBox.SelectedItem; set => throw new NotImplementedException(); }



        public TypeSoignant recupsoignant { get => (TypeSoignant)recupSoignant.SelectedItem; set => throw new NotImplementedException(); }







        //----------------------------------FIN_REMPLISSAGE------------------------










        /************************************************************/
        /*                                                          */
        //             ---------BINDINDS -------
        /*                                                          */
        /************************************************************/



        public void setrecupsoignant(BindingSource bindingSource)
        {
            recupSoignant.DataSource = bindingSource;
        }


        public void seteldyBoxBindingSource(BindingSource bindingSource)
        {
            eldyBox.DataSource=bindingSource;
        }





        public void setdtgRdv(BindingSource bindingSource)
        {
            dtgRdv.DataSource = bindingSource;
        }



        //-----------typ rdv
        public void setTrdvP(BindingSource Listenum)
        {


            cbxtypeRdv.DataSource= Listenum;
            //cbxtypeRdv.DisplayMember="id"
            //cbxtypeRdv.ValueMember="id" ===>retourne id

            //test avec combobox
            // cbxtypeRdv.DataSource = Enum.GetValues(typeof(TypeRdv));
            //cbxtypeRdv.SelectedItem = TypeRdv.Prestation;
        }



      

        public void setRecupAjout(BindingSource bindingSource)

        {
            comboBoxType.DataSource = bindingSource; 
        }





        //----------------------

        public void setdtgMed(BindingSource bindingSource)
        {
            dtgMed.DataSource = bindingSource;


        }



        //-----------  
        public void setRdvBindingSource(BindingSource Listant)
        {
            //cbxantP.DataSource = Listant;
        }


        public void setHeureBindingSource(BindingSource ListHeure)
        {
            cbxheureP.DataSource = ListHeure;
        }


        public void setdtgTriple(BindingSource bindingSource)
        {
           // dtgTriple.Rows.Clear();
            dtgTriple.DataSource=bindingSource;
        }



       


        public void setdtgR(BindingSource bindingSource)
        {
            dtgTriple.Rows.Clear();
            dtgTriple.DataSource = bindingSource;
        }



        


        //---------------------------------------------------------------------FIN_BINDING------------------------






    

        //----------------------------------FIN------------------------



        /************************************************************/
        /*                                                          */
        //             ---------MES_EVENTS -------
        /*                                                          */
        /************************************************************/

       
        public event EventHandler ajouterRdv;
        public event EventHandler modifierRdv;
        public event EventHandler supprimerRdv;
        public event EventHandler rechercherRdvParPatient;
        public event EventHandler rechercherRdvParDate;
        public event EventHandler rechercherRdvParType;
        public event EventHandler SelectLigneDtgv;

        //---Pt
        public event EventHandler addPatient;
        public event EventHandler findPatient;
        public event EventHandler findconsultation;
        public event EventHandler findprestationConsult;
        public event EventHandler findconsultationByPt;
        public event EventHandler eventNouveauPt;
        public event EventHandler filtrerconsultation;
        public event EventHandler ChangeRp_M;







        /************************************************************/
        /*                                                          */
        //             ---------design pattern singleton -------
        /*                                                          */
        /************************************************************/





        private static SecretaireForm instance = null;


        public static SecretaireForm showForm(Form parent)
        {

            if (parent.ActiveMdiChild != null)
            {
                parent.ActiveMdiChild.Close();
                instance = null;
            }





           if (instance == null)
 {
              instance = new SecretaireForm();
              instance.MdiParent = parent;
             
            }
            return instance;


        }



       








        //public void setRdvBindingSource(BindingSource typeRdvList, BindingSource antecedentList)
        //{
        // throw new NotImplementedException();
        //}



        /*  public DateTime Daterecherche { get => dateTimeFiltre;  set =>; }

          public string PatientRecherche { get => txtanteP; set => ; }

          //option selet
          public Antecedent anteP { get => cbxantP.SelectedItem as Antecedent; set => ; }

          public string nomP { get => txtnomP ; set =>; }

          public string prenomP { get => txtprenomP; set =>; }


          public TypeRdv trdvP { get => cbxtypeRdv.SelectedItem as TypeRdv; set =>; }

          public string codeP { get => txtcodeP; set => ; }

          public event EventHandler ajouterRdv;
          public event EventHandler modifierRdv;
          public event EventHandler rechercherRdvParPatient;
          public event EventHandler rechercherRdvParDate;

      }*/
















        private void SecretaireForm_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonPtFil_Click(object sender, EventArgs e)
        {

        }

        private void BtnDConsult_Click(object sender, EventArgs e)
        {

        }

        private void dtgTriple_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}