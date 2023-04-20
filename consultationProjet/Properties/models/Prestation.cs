using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.Properties.models
{
    public class Prestation
    {
        private int id;
        private TypePrestation typePrestation;
        private string resultatPrestation;

        private DateTime datePrestation;
        private Patient patient;
        private Rp rp;

        public int Id { get => id; set => id = value; }
        public TypePrestation TypePrestation { 
            get => typePrestation; set => typePrestation = value;
        }
        public string ResultatPrestation { get => resultatPrestation; set => resultatPrestation = value; }
        public Patient Patient { get => patient; set => patient = value; }
     
        public DateTime DatePrestation { get => datePrestation; set => datePrestation = value; }
        public Rp Rp { get => rp; set => rp = value; }

        public override string ToString()
        {
            return id + " " ;
        }
    }
}
