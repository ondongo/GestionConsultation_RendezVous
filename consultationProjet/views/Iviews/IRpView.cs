using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.views.Iviews
{
    public interface IRpView
    {




        void setdtgRdvPres(BindingSource bindingSource);
        void setdtgTypePres(BindingSource bindingSource);
        void setdtgprestation(BindingSource bindingSource);
        void setdtgEtat(BindingSource bindingSource);


        Etatrdv etatrdvRecup { get; set; }




        void Show();


        DateTime DaterecherchePres { get; set; }

        TypePrestation RecupTypePres { get; set; }

        string recupResultat { get; set; }  



        event EventHandler rechercherRdvParDatePres;
        event EventHandler AnnulerPresEvent;
        event EventHandler ValiderPresEvent;
        event EventHandler PlannifierNouveau;
        event EventHandler AddPresEvent;
        event EventHandler etatRdvEvent;



    }
}
