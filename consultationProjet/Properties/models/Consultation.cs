using consultationProjet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.Properties.models
{
    public enum Tension
    {
       Normale,Faible,Moyenne,Haute
    }
    public class Consultation
    {
        private int id;

        private DateTime date;
        private Ordonnance ordonnance;
        private string temperature;
        private Tension tension;

        private Patient patient;
        private Medecin medecin;
        private string poid;
        private Prestation prestation;  
      

        public int Id { get => id; set => id = value; }
       

        public string Temperature { get => temperature + "°C"; set => temperature = value; }
      
        public Patient Patient { get => patient; set => patient = value; }
        public Medecin Medecin { get => medecin; set => medecin = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Poid { get => poid + "Kg"; set => poid = value; }
        public Prestation Prestation { get => prestation; set => prestation = value; }
        public Tension Tension { get => tension; set => tension = value; }
        public Ordonnance Ordonnance { get => ordonnance; set => ordonnance = value; }


        public override string ToString()
        {
            return patient + " "  + " " + temperature  + tension + poid + date + " " + medecin +ordonnance;
        }
    }
}
