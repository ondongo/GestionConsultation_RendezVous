
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.views.Iviews
{
    public interface IconnexionView
    {

        string Login { get; set; }
        string Password{ get; set; }


        string Message { get; set; }    

        bool IsLoggedIn { get; set; }




        //cacher
        void Hide();
        void Show();
        event  EventHandler ConnexionEvent;












    }
}
