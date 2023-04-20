using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.views.Iviews
{
    public interface IDossierMedicalView
    {
        void Show();


        string nom { get; set; }
        string ant { get; set; }
        string code { get; set;}
     


        void setConsultationPt(BindingSource bindingSource);





    }
}
