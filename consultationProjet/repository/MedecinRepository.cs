using consultationProjet.models;
using consultationProjet.repository.intertfaceRepositor;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository
{








    public class MedecinRepository : BaseRepository, IMedecinRepository
    {

        //---------------------------------med dispo-------------------------------
        private readonly string SQL_SELECT_ALL_MED = @"select * from utilisateurs where role LIKE 'Medecin' and etat LIKE 'Dispo' ";
        private readonly string SQL_SELECT_BY_ID = @"select * from utilisateurs  where idUtilisateur=@idUtilisateur and role LIKE 'Medecin'";
        private readonly string SQL_UPDATE = @"update utilisateurs set etat=@etat where idUtilisateur=@idUtilisateur and role LIKE 'Medecin'";
        private readonly string SQL_SELECT_BY_TYPE = @"select * from utilisateurs  where role LIKE 'Medecin' and typeMedecin=@typeMedecin";



        private readonly string SQL_SELECT_ALL_BY_Pt_Un_Med = @"SELECT DISTINCT Patient.*
                                                    FROM Patient
                                                    JOIN Consultation ON Patient.idPatient = Consultation.idPatient
                                                    JOIN Utilisateurs ON Consultation.idMedecin = Utilisateurs.idUtilisateur
                                                    WHERE Utilisateurs.idUtilisateur = @idUtilisateur";



        public MedecinRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void delete(int id)
        {
            throw new NotImplementedException();




        }

        public List<Medecin> findAll()
        {
            List<Medecin> medList = new List<Medecin>();

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


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        Medecin med = new Medecin()
                        {

                            //convertir dr avant 
                            Id = int.Parse(dr[0].ToString()),


                            Nom = dr[4].ToString(),
                            Login = dr[1].ToString(),




                        };
                        Enum.TryParse(dr[5].ToString(), out TypeMedecin type1);

                        med.TypeMedecin = type1;

                        Enum.TryParse(dr[3].ToString(), out RoleUsers type3);

                        med.Role = type3;


                        Enum.TryParse(dr[6].ToString(), out Etat type2);
                        med.Etat = type2;


                        medList.Add(med);
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



            return medList;
        }

        public Medecin findById(int id)
        {
            Medecin md = null;


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
                    command.CommandText = SQL_SELECT_BY_ID;

                    //parameters
                    command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = id;

                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {





                        md = new Medecin()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0],
                            Nom = dr[4].ToString(),

                        };





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



            return md;

        }



        public Medecin save(Medecin obj)
        {
            throw new NotImplementedException();
        }


        public void update(Medecin med)
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
                    command.CommandText = SQL_UPDATE;

                    command.Parameters.Add("@etat", SqlDbType.NVarChar).Value = Etat.Absent.ToString();

                    command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = med.Id;
                    //command.Parameters.Add("@date",SqlDbType.Date).Value =DateTime.Now ;



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
            }

        }




        //-----------------------------------Exception-----------------------------------------------------
        public void updateEtatDispo(Medecin med)
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
                    command.CommandText = SQL_UPDATE;

                    command.Parameters.Add("@etat", SqlDbType.NVarChar).Value = Etat.Dispo.ToString();

                    command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = med.Id;
                    //command.Parameters.Add("@date",SqlDbType.Date).Value =DateTime.Now ;



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
            }
        }












        //-------------------------------------------------------------------Med

        public List<Medecin> findbyTypeMedecin(string type)
        {
            List<Medecin> medList = new List<Medecin>();


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
                    command.CommandText = SQL_SELECT_BY_TYPE;

                    //parameters
                    command.Parameters.Add("@typeMedecin", SqlDbType.NVarChar).Value = type;

                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        Medecin med = new Medecin()
                        {

                            //convertir dr avant 
                            Id = int.Parse(dr[0].ToString()),


                            Nom = dr[4].ToString(),
                            Login = dr[1].ToString(),




                        };
                        Enum.TryParse(dr[5].ToString(), out TypeMedecin type1);

                        med.TypeMedecin = type1;

                        Enum.TryParse(dr[3].ToString(), out RoleUsers type3);

                        med.Role = type3;


                        Enum.TryParse(dr[6].ToString(), out Etat type2);
                        med.Etat = type2;


                        medList.Add(med);
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



            return medList;


        }




        public List<Patient> listerTousLesPatientsMed(int id)
        {
            List<Patient> ListPt = new List<Patient>();



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
                    command.CommandText = SQL_SELECT_ALL_BY_Pt_Un_Med;
                    command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = id;


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();


                    while (dr.Read())
                    {
                        Patient pt = new Patient();

                        pt.IdPatient = (int)dr[0];

                        pt.Nom = dr[2].ToString();
                        pt.Code = dr[1].ToString();

                        pt.Prenom = dr[4].ToString();


                        ListPt.Add(pt);
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

            return ListPt;
        }
    }

}