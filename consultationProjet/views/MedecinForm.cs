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
    public partial class MedecinForm : Form, IMedView
    {
        public MedecinForm()
        {
            InitializeComponent();
            manipulationNumeric();


            btnDossier.Click += delegate
            {

                VoirDossier.Invoke(this, EventArgs.Empty);
            };

            btnDetails.Click += delegate
            {

                VoirDetailsConsult.Invoke(this, EventArgs.Empty);
            };



            //---------------------
            radioPres1.Click += delegate
            {

                comboBoxPres.Enabled = true;
            };

            radioBtnPres2.Click += delegate
            {

                comboBoxPres.Enabled = false;
            };



            

            //Posologi
            radioPM1.Checked = true;
            radiodispo.Checked = true;


            radioPM1.Click += delegate
            {

                textBoxPM1.Enabled = true;
                textBoxPM2.Enabled = true;
            };

            radioPM2.Click += delegate
            {

                textBoxPM1.Enabled = false;
                textBoxPM2.Enabled = false;
            };


            radioindispo.Click += delegate
            {
               
                var rslt = MessageBox.Show("La secretaire ne vous verra plus dans la liste dispo?", "Attention Voulez Vous vraiment Passé à absent",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (rslt == DialogResult.Yes)
                {

                    radioCheckIndispo.Invoke(this, EventArgs.Empty);


                }
            };




            radiodispo.Click += delegate
            {

                    radioCheckdispo.Invoke(this, EventArgs.Empty);

            };



            dateTimeConsult.ValueChanged += delegate
            {

                filtrerRdvConsult.Invoke(this, EventArgs.Empty);

            };

            

            consultDoc.Click += delegate
            {

                listConsult.Invoke(this, EventArgs.Empty);

            };


            consultDoc.Click += delegate
            {

                listConsult.Invoke(this, EventArgs.Empty);

            };


            patientDoc.Click += delegate
            {

                listpatient.Invoke(this, EventArgs.Empty);

            };


            btnV.Click += delegate
            {

                ValiderMedEvent.Invoke(this, EventArgs.Empty);

            };



            btnA.Click += delegate
            {

                AnnulerMedEvent.Invoke(this, EventArgs.Empty);

            };






            btnAdd.Click += delegate
            {

                AddConsult.Invoke(this, EventArgs.Empty);

            };


            comboxEtat.SelectionChangeCommitted += delegate
            {

                filtrerEtatRdvMedEvent.Invoke(this, EventArgs.Empty);
            };




        }



        string IMedView.numericTemperature { get => numericTemperature.Value.ToString(); set => throw new NotImplementedException(); }
        string IMedView.numericPoid { get => numericPoid.Value.ToString(); set => throw new NotImplementedException(); }
        public DateTime dateTimeConsultEvent { get => dateTimeConsult.Value; set => throw new NotImplementedException(); }
        public Etatrdv etatrdvRecup { get => (Etatrdv)comboxEtat.SelectedItem; set => throw new NotImplementedException(); }

        public void manipulationNumeric()
        {
            // Définition la plage de valeurs autorisées pour le NumericUpDown.
            numericTemperature.Minimum = 29;
            numericTemperature.Maximum = 45;

            // Définition l'intervalle de changement de valeur à 1 heure.
            numericTemperature.Increment = 1;
            //}


            numericPoid.Minimum = 4;
            numericPoid.Maximum = 315;
            // Affichez la valeur sélectionnée dans une boîte de message.
            //   MessageBox.Show("Heure sélectionnée : " + numericUpDown1.Value);
        }


        
































            public void setdtgRdvMed(BindingSource bindingSource)
        {
            dtgRdvMed.DataSource = bindingSource;
        }

        public void setTension(BindingSource bindingSource)
        {
            comboTension.DataSource=bindingSource;
        }


        public void setdtgConsultationMed(BindingSource bindingSource)
        {
           
            dtgconsMed.DataSource = bindingSource;
        }


        public void setdtgPatient(BindingSource bindingSource)
        {

            dtgconsMed.Rows.Clear();
            dtgconsMed.DataSource = bindingSource; ;
        }




        public event EventHandler VoirDossier;
        public event EventHandler VoirDetailsConsult;
        public event EventHandler radioCheckBtn;
        public event EventHandler radioCheckIndispo;
        public event EventHandler radioCheckdispo;
        public event EventHandler filtrerRdvConsult;
        public event EventHandler listConsult;
        public event EventHandler listpatient;
        public event EventHandler AnnulerMedEvent;
        public event EventHandler ValiderMedEvent;
        public event EventHandler AddConsult;
        public event EventHandler filtrerEtatRdvMedEvent;
        public event EventHandler Plannifier;



        //---------design pattern singleton

        private static MedecinForm instance = null;


        public static MedecinForm showForm(Form parent)
        {

            if (parent.ActiveMdiChild != null)
            {
               // parent.ActiveMdiChild.Close();
               // instance = null;
            }
            if (instance == null)
            {
                instance = new MedecinForm();
                instance.MdiParent = parent;
                //return instance;
            }
            return instance;
        }







        private void MedecinForm_Load(object sender, EventArgs e)
        {

        }

        private void radioPM1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioPM2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericTemperature_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioPres1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void setEtat(BindingSource bindingSource)
        {
            comboxEtat.DataSource=bindingSource;
        }
    }
}
