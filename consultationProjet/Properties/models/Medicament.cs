using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.models
{
    public class Medicament
    {
        private int id;
        private string codeMedoc;
        private string nomMedoc;

        public int Id { get => id; set => id = value; }
        public string CodeMedoc { get => codeMedoc; set => codeMedoc = value; }
        public string NomMedoc { get => nomMedoc; set => nomMedoc = value; }

        public override string ToString()
        {
            return  " " + id + "  " + codeMedoc + " " + nomMedoc ;
        }
    }
}
