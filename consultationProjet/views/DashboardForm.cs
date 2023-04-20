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

namespace consultationProjet.views
{
    public partial class DashboardForm : Form,ImenuView
    {
        public DashboardForm()
        {
            InitializeComponent();

           // block();

            //


            ss.Click += delegate
            {
                showFormSecretaire.Invoke(this, EventArgs.Empty);
            };



            btnr.Click += delegate
            {
                showFormRp.Invoke(this, EventArgs.Empty);
            };


            btnShowMed.Click += delegate
            {
                showFormMedecin.Invoke(this, EventArgs.Empty);
            };



            deconnexion.Click += delegate
            {
               deconnexion1.Invoke(this, EventArgs.Empty);
            };



        }

        public string userLabel { 
            get => lblUser.Text; 
            set => lblUser.Text=value; }

        public User UserConnect {
            get;
            set; }


        public string userRole 
        { 
         get => lblRole.Text; 
         set => lblRole.Text=value;
        }


       
        public void block()
        {


            btnShowMed.Enabled = true;
            btnShowMed.BackColor = Color.SteelBlue;
            ss.Enabled = false;
                btnr.Enabled = false;





         }




        public void block2()
        {
            
                btnShowMed.Enabled = false;
                ss.Enabled = false;
                btnr.Enabled = true;

                btnr.BackColor =Color.SteelBlue;
            
        }
            
        
        public void block1()
        {
              
                btnShowMed.Enabled = false;
                btnr.Enabled = false;
                ss.Enabled = true;
                ss.BackColor = Color.SteelBlue;
        }



       



        public event EventHandler showFormSecretaire;
        public event EventHandler showFormRp;
        public event EventHandler deconnexion1;
        public event EventHandler showFormMedecin;

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnr_Click(object sender, EventArgs e)
        {

        }
    }
}
