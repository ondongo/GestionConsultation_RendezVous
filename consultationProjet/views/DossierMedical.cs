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
    public partial class DossierMedical : Form,IDossierMedicalView
    {
        public DossierMedical()
        {
            InitializeComponent();
        }

        public string nom { get => throw new NotImplementedException(); set => lblNom.Text=value; }
        public string ant { get => throw new NotImplementedException(); set =>lblAnt.Text=value; }
        public string code { get => throw new NotImplementedException(); set => lblCode.Text=value; }
    




        public void setConsultationPt(BindingSource bindingSource)
        {
            ptL.DataSource=bindingSource;
        }


























        private void DossierMedical_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
