using consultationProjet.models;
using consultationProjet.Properties.models;
using consultationProjet.views.Iviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.presenter
{
    public class DetailsConsultationPresenteur : IDetailsConsultationPresenteur
    {
        private Consultation cl;
        private IDetailsConsultationView detailsView;

        public DetailsConsultationPresenteur(Consultation cl, IDetailsConsultationView detailsView)
        {
            this.cl = cl;
            this.detailsView = detailsView;

            //Load start
            this.detailsView.Show();
        }
    }
}
