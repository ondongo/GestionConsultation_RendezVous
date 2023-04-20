using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.models
{

    public class RendezVous
    {

        private int id;
        private DateTime date;
        private TypeRdv typeRdv;
        private Etatrdv etatrdv;
        private string heure;
        private Patient patient;
        private Medecin medecin;
        private Rp rp;


        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public TypeRdv TypeRdv { get => typeRdv; set => typeRdv = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public Medecin Medecin { get => medecin; set => medecin = value; }
        public Etatrdv Etatrdv { get => etatrdv; set => etatrdv = value; }
        public string Heure { get => heure; set => heure = value; }
        public Rp Rp { get => rp; set => rp = value; }

        public override string? ToString()
        {
            return "id" + id + " date" + date + "typeRdv" + typeRdv + "patient" + patient + "medecin" + medecin + "etatrdv" + Etatrdv + heure;

        }
    }
}
