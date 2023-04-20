using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.views.Iviews
{
    public interface ImenuView
    {

        // string userShow { get; set; }


        string userLabel { get; set; }

        // string userHide { get; set; }
        string userRole { get; set; }


        User UserConnect { get; set; }


        event EventHandler showFormSecretaire;
        event EventHandler showFormRp;
        event EventHandler showFormMedecin;
        event EventHandler deconnexion1;
        
        void Show();
        void Hide();
        void Close();


        void block();
        void block1();
        void block2();



       

    }
        
}
