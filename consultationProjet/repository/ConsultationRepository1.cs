using consultationProjet.models;
using consultationProjet.Properties.models;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

namespace consultationProjet.repository
{
    public class ConsultationRepository : BaseRepository, IConsultationRepository
    {



        /************************************************************/
        /*                                                          */
        /*        -----------------Requetes-----------------         */
        /*                                                          */
        /************************************************************/

    // VU Par La Sec   

    private readonly string SQL_SELECT_ALL = @"select * from consultation where date= CAST(GETDATE() AS DATE)  ";

    private readonly string SQL_SELECT_ALL_ByPatient = @"select * from consultation where idPatient=@idPatient ";


    private readonly string SQL_SELECT_ALL_date = @"select * from consultation where date=@date ";


    // VU Par Le Medecin

        private readonly string SQL_SELECT_ALL_MED = @"SELECT Consultation.*, ordonnance.libelle_Ord,ordonnance.posologie, medicament.*
                                                                FROM Consultation
                                                                JOIN ordonnance ON Consultation.id = ordonnance.consultation_id
                                                                JOIN medicament ON ordonnance.medicament_id = medicament.id
                                                                WHERE date=CAST(GETDATE() AS DATE)  and idMedecin=@idMedecin";



        private readonly string SQL_SELECT_ALL_MED_BY_DATE = @"SELECT Consultation.*, ordonnance.libelle_Ord,ordonnance.posologie, medicament.*
                                                                FROM Consultation
                                                                JOIN ordonnance ON Consultation.id = ordonnance.consultation_id
                                                                JOIN medicament ON ordonnance.medicament_id = medicament.id
                                                                WHERE  date=@date  and idMedecin=@idMedecin";




        private readonly string SQL_SELECT_ALL_CL_PATIENT = @"SELECT Consultation.*
                                                            FROM Consultation
                                                            JOIN Patient ON Consultation.idPatient= Patient.idPatient
                                                            JOIN Utilisateurs ON Consultation.idMedecin = Utilisateurs.idUtilisateur
                                                            WHERE Patient.idPatient =@idPatient AND Utilisateurs.idUtilisateur =@idUtilisateur";









        //Mes Requetes -------------SQl ecriture-----------------
        private readonly string SQL_INSERT = @"insert into consultation (date,temperature,poid,tension,idPatient,idMedecin)
      output INSERTED.id values(@date,@temperature,@poid,@tension,@idPatient,@idMedecin)";













        /************************************************************/
        /*                                                          */
        //             --------Couplages & constructeurs---
        /*                                                          */
        /************************************************************/

        private IPatientRepository patientRepository;
        private IMedecinRepository medRepository;

        public ConsultationRepository(string connectionString, IPatientRepository patientRepository, IMedecinRepository medRepository)
        {
            ConnectionString = connectionString;
            this.patientRepository = patientRepository;
            this.medRepository = medRepository;

        }



        public void delete(int id)
        {
            throw new NotImplementedException();
        }






        /************************************************************/
        /*                                                          */
        //             --------SELECT Cl---Pt---
        /*                                                          */
        /************************************************************/

        public List<Consultation> filtrerConsultationByPatient(int id)
        {
            List<Consultation> consultationListbyPt = new List<Consultation>();



            //On connection
            //using instance crée une seule fois
            using (var connection = new SqlConnection(ConnectionString))

            //Preparstatment ==> requete prepare
            using (var command = new SqlCommand())

                try
                {
                    //readonly (c#) ==final (java)
                    //ouverture 
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = SQL_SELECT_ALL_ByPatient;
                    command.Parameters.Add("idPatient", SqlDbType.Int).Value = id; 


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();


                    while (dr.Read())
                    {
                        Consultation consult = new Consultation();
                        consult.Id = (int)dr[0];

                        if (!Convert.IsDBNull(dr[1]))
                        {
                            consult.Date = (DateTime)dr[6];
                        }
                        consult.Poid = dr[1].ToString();
                        //onsult.Tension = dr[3].ToString();
                        // consult.Ordannance = dr[7].ToString();



                        Enum.TryParse(dr[3].ToString(), out Tension type);
                        consult.Tension = type;
                        consult.Temperature = dr[2].ToString();




                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[4]);


                            consult.Patient = patient;

                        }





                        if (!Convert.IsDBNull(dr[4]))
                        {

                            Medecin med = medRepository.findById((int)dr[5]);

                            consult.Medecin = med;
                        }



                        consultationListbyPt.Add(consult);
                    }


                    dr.Close();





                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {

                    command.Dispose();
                    //fermeture
                    connection.Close();

                }

            return consultationListbyPt;
        }






        /************************************************************/ //-----------------------------------------------------
        /*                                                          */
        //             -------- Consultation ALL---
        /*                                                          */
        /************************************************************/
        //-----------------------------------------------------------------------------FINDALL------------------------------
        public List<Consultation> findAll()
        {
            List<Consultation> consultationList = new List<Consultation>();



            //On connection
            //using instance crée une seule fois
            using (var connection = new SqlConnection(ConnectionString))

            //Preparstatment ==> requete prepare
            using (var command = new SqlCommand())

                try
                {
                    //readonly (c#) ==final (java)
                    //ouverture 
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = SQL_SELECT_ALL;


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();


                    while (dr.Read())
                    {
                        Consultation consult = new Consultation();
                        consult.Id = (int)dr[0];

                        if (!Convert.IsDBNull(dr[1]))
                        {
                            consult.Date = (DateTime)dr[6];
                        }
                        consult.Poid = dr[1].ToString();
                        Enum.TryParse(dr[3].ToString(), out Tension type);
                        consult.Tension = type;
                        // consult.Ordannance = dr[7].ToString();
                        consult.Temperature = dr[2].ToString();

                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[4]);


                            consult.Patient = patient;

                        }
                        if (!Convert.IsDBNull(dr[4]))
                        {

                            Medecin med = medRepository.findById((int)dr[5]);

                            consult.Medecin = med;
                        }
                        consultationList.Add(consult);
                    }
                    dr.Close();
                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {
                    command.Dispose();
                    //fermeture
                    connection.Close();
                }

            return consultationList;
        }






        /************************************************************/
        /*                                                          */
        //             -------- ConsultationByMed---
        /*                                                          */
        /************************************************************/

        public List<Consultation> ListerConsultationByMed(int id)
        {

            List<Consultation> consultationListMd = new List<Consultation>();
            //On connection
            //using instance crée une seule fois
            using (var connection = new SqlConnection(ConnectionString))

            //Preparstatment ==> requete prepare
            using (var command = new SqlCommand())

                try
                {
                    //readonly (c#) ==final (java)
                    //ouverture 
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = SQL_SELECT_ALL_MED;

                    
                    command.Parameters.Add("idMedecin", SqlDbType.Int).Value = id;


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();


                    while (dr.Read())
                    {
                        Consultation consult = new Consultation();
                        consult.Id = (int)dr[0];

                        if (!Convert.IsDBNull(dr[1]))
                        {
                            consult.Date = (DateTime)dr[6];
                        }
                        consult.Poid = dr[1].ToString();
                        Enum.TryParse(dr[3].ToString(), out Tension type);
                        consult.Tension = type;
                        // consult.Ordannance = dr[7].ToString();
                        consult.Temperature = dr[2].ToString();

                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[4]);


                            consult.Patient = patient;

                        }
                        if (!Convert.IsDBNull(dr[4]))
                        {

                            Medecin med = medRepository.findById((int)dr[5]);

                            consult.Medecin = med;
                        }
                        consultationListMd.Add(consult);
                    }
                    dr.Close();
                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {
                    command.Dispose();
                    //fermeture
                    connection.Close();
                }

            return consultationListMd;
        }







        /************************************************************/ //-------------------------------
        /*                                                          */
        //             -------- FILTRE PAR DATE---
        /*                                                          */
        /************************************************************///----------------------------

        public List<Consultation> filtrerConsultationBydate(string date)
    {
        List<Consultation> consultationListbyPt = new List<Consultation>();



        //On connection
        //using instance crée une seule fois
        using (var connection = new SqlConnection(ConnectionString))

        //Preparstatment ==> requete prepare
        using (var command = new SqlCommand())

            try
            {
                //readonly (c#) ==final (java)
                //ouverture 
                connection.Open();
                command.Connection = connection;
                command.CommandText = SQL_SELECT_ALL_date;

                    DateTime date1 = DateTime.Parse(date);
                //parameters
                command.Parameters.Add("@date", SqlDbType.Date).Value = date1;
                



                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    Consultation consult = new Consultation();
                    consult.Id = (int)dr[0];

                    if (!Convert.IsDBNull(dr[1]))
                    {
                        consult.Date = (DateTime)dr[6];
                    }
                    consult.Poid = dr[1].ToString();
                    //onsult.Tension = dr[3].ToString();



                    // consult.Ordannance = dr[7].ToString();



                    Enum.TryParse(dr[3].ToString(), out Tension type);
                    consult.Tension = type;
                    consult.Temperature = dr[2].ToString();


                    if (!Convert.IsDBNull(dr[3]))
                    {


                        Patient patient = patientRepository.findById((int)dr[4]);


                        consult.Patient = patient;

                    }





                    if (!Convert.IsDBNull(dr[4]))
                    {

                        Medecin med = medRepository.findById((int)dr[5]);

                        consult.Medecin = med;
                    }



                    consultationListbyPt.Add(consult);
                }


                dr.Close();





            }
            catch (Exception)
            {

                throw;
            }

            finally
            {

                command.Dispose();
                //fermeture
                connection.Close();

            }

        return consultationListbyPt;
}


















        /************************************************************/ //-----------------------------------------------------
        /*                                                          */
        //             -------- Non utilisés-------                        //---------------------------------------------------------------
        /*                                                          */
        /************************************************************/ //---------------------------------------------------------



        public Consultation findById(int id)
        {
            throw new NotImplementedException();
        }



        /************************************************************/
        /*                                                          */
        //             --------ADD Cl---Pt---
        /*                                                          */
        /************************************************************/
        public Consultation addtest(Consultation obj,int id)
        {
            //using instance crée une seule fois
            using (var connection = new SqlConnection(ConnectionString))

            //Preparstatment ==> requete prepare
            using (var command = new SqlCommand())

            {
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = SQL_INSERT;

                    command.Parameters.Add("@date", SqlDbType.Date).Value = obj.Date;


                    command.Parameters.Add("@temperature", SqlDbType.NVarChar).Value = obj.Temperature;

                    command.Parameters.Add("@idPatient", SqlDbType.Int).Value = obj.Patient.IdPatient;


                    command.Parameters.Add("@idMedecin", SqlDbType.Int).Value = id;

                    command.Parameters.Add("@poid", SqlDbType.NVarChar).Value = obj.Poid;


                    command.Parameters.Add("@tension", SqlDbType.NVarChar).Value = obj.Tension;



                    //     int Id = (int)command.ExecuteScalar();
                    //-------------pour les requetes select---------------c
                    command.ExecuteNonQuery();




                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {
                    command.Dispose();
                    //fermeture
                    connection.Close();

                }
                return obj;
            }

        }

        public void update(Consultation obj)
        {
            throw new NotImplementedException();
        }




        /************************************************************/
        /*                                                          */
        //             --------SELECT Cl-Med--Pt---
        /*                                                          */
        /************************************************************/
        public List<Consultation> filtrerConsultationMedBydate(string date, int id)
        {
            List<Consultation> consultationList = new List<Consultation>();



            //On connection
            //using instance crée une seule fois
            using (var connection = new SqlConnection(ConnectionString))

            //Preparstatment ==> requete prepare
            using (var command = new SqlCommand())

                try
                {
                    //readonly (c#) ==final (java)
                    //ouverture 
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = SQL_SELECT_ALL_MED_BY_DATE;

                    DateTime date1 = DateTime.Parse(date);
                    //parameters
                    command.Parameters.Add("@date", SqlDbType.Date).Value = date1;
                   command.Parameters.Add("idMedecin", SqlDbType.Int).Value = id;



                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();


                    while (dr.Read())
                    {
                        Consultation consult = new Consultation();
                        consult.Id = (int)dr[0];

                        if (!Convert.IsDBNull(dr[1]))
                        {
                            consult.Date = (DateTime)dr[6];
                        }
                        consult.Poid = dr[1].ToString();
                        //onsult.Tension = dr[3].ToString();
                        // consult.Ordannance = dr[7].ToString();



                        Enum.TryParse(dr[3].ToString(), out Tension type);
                        consult.Tension = type;
                        consult.Temperature = dr[2].ToString();




                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[4]);


                            consult.Patient = patient;

                        }





                        if (!Convert.IsDBNull(dr[4]))
                        {

                            Medecin med = medRepository.findById((int)dr[5]);

                            consult.Medecin = med;
                        }



                        consultationList.Add(consult);
                    }


                    dr.Close();





                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {

                    command.Dispose();
                    //fermeture
                    connection.Close();

                }

            return consultationList;
        }

        public List<Consultation> filtrerConsultationUnPatient(int idPatient, int idUtilisateur)
        {
            List<Consultation> consultationListbyPt = new List<Consultation>();

            //On connection
            //using instance crée une seule fois
            using (var connection = new SqlConnection(ConnectionString))

            //Preparstatment ==> requete prepare
            using (var command = new SqlCommand())

                try
                {
                    //readonly (c#) ==final (java)
                    //ouverture 
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = SQL_SELECT_ALL_CL_PATIENT;
                    command.Parameters.Add("idPatient", SqlDbType.Int).Value = idPatient;
                    command.Parameters.Add("idUtilisateur", SqlDbType.Int).Value = idUtilisateur;


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();


                    while (dr.Read())
                    {
                        Consultation consult = new Consultation();
                        consult.Id = (int)dr[0];

                        if (!Convert.IsDBNull(dr[1]))
                        {
                            consult.Date = (DateTime)dr[6];
                        }
                        consult.Poid = dr[1].ToString();
                        //onsult.Tension = dr[3].ToString();
                        // consult.Ordannance = dr[7].ToString();
                        Enum.TryParse(dr[3].ToString(), out Tension type);
                        consult.Tension = type;
                        consult.Temperature = dr[2].ToString();




                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[4]);


                            consult.Patient = patient;

                        }





                        if (!Convert.IsDBNull(dr[4]))
                        {

                            Medecin med = medRepository.findById((int)dr[5]);

                            consult.Medecin = med;
                        }



                        consultationListbyPt.Add(consult);
                    }


                    dr.Close();





                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {

                    command.Dispose();
                    //fermeture
                    connection.Close();

                }

            return consultationListbyPt;
        }

        public Consultation save(Consultation obj)
        {
            throw new NotImplementedException();
        }
    }

      
    }

