using consultationProjet.models;
using consultationProjet.Properties.models;
using consultationProjet.services;
using consultationProjet.views.Iviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace consultationProjet.presenter
{
    public class DossierMedicalePresenteur : IDossierMedicalePresenteur
    {
        private Patient pt;
        private IDossierMedicalView dossierMedicalView;
        public IConsultationServ consultservice;
        public ImenuView menu;

        IEnumerable<Consultation> listCl_Pt = new List<Consultation>();
        private BindingSource bindingConsult_Pt = new BindingSource();

        public DossierMedicalePresenteur(Patient pt, IDossierMedicalView dossierMedicalView, ImenuView menu)
        {
            this.pt = pt;
            this.dossierMedicalView = dossierMedicalView;
            this.dossierMedicalView.code = pt.Code;
            this.dossierMedicalView.nom = pt.Nom + " " + pt.Prenom;
            this.dossierMedicalView.ant = pt.Antecedent;
           
            this.menu = menu;
            consultservice = Fabrique.getconsultServ();


            listCl_Pt = consultservice.filterConsultUnPatient(this.pt.IdPatient, menu.UserConnect.Id);
            bindingConsult_Pt.DataSource = listCl_Pt;
            this.dossierMedicalView.setConsultationPt(bindingConsult_Pt);



            //Load start
            this.dossierMedicalView.Show();





        }

     

        public void initialize()
        {
          
        }
    }
}
