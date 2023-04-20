using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.views.Iviews
{
    public interface IMedView
    {
        void Show();

        string numericTemperature { get; set; } 
        string numericPoid { get; set; }







        void setTension(BindingSource bindingSource);

        void setdtgRdvMed(BindingSource bindingSource);

        void setdtgConsultationMed(BindingSource bindingSource);



        void setdtgPatient(BindingSource bindingSource);
        void setEtat(BindingSource bindingSource);

        Etatrdv etatrdvRecup { get; set; }


        DateTime dateTimeConsultEvent { get; set; }

        event EventHandler VoirDossier;
        event EventHandler VoirDetailsConsult;
        event EventHandler radioCheckBtn;
        event EventHandler radioCheckIndispo; 
        event EventHandler radioCheckdispo;
        event EventHandler filtrerRdvConsult;
        event EventHandler listConsult;
        event EventHandler listpatient;
        event EventHandler AnnulerMedEvent;
        event EventHandler ValiderMedEvent;
        event EventHandler AddConsult;
        event EventHandler filtrerEtatRdvMedEvent;

        event EventHandler Plannifier;



    }
}