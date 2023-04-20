using consultationProjet.models;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using consultationProjet.repository;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using consultationProjet.Properties.models;

namespace consultationProjet.presenter.repository.intertfaceRepositor
{
    public class PatientRepository : BaseRepository, IPatientRepository



    {


        private readonly string SQL_INSERT = @"insert into Patient (code,nom,prenom,antecedent) output INSERTED.idPatient values (@code,@nom,@prenom,@antecedent)";
       
       // private readonly string SQL_INSERT = @"insert into Patient (nom,prenom) output INSERTED.idPatient values (@nom,@prenom)";
        private readonly string SQL_SELECT_BY_ID = @"select * from Patient where idPatient=@idPatient ";
        private readonly string SQL_SELECT_ALL = @"select * from Patient";
       // private readonly string SQL_SELECT_ALL_BY_NOM = @"select * from Patient where nom=@nom";

        private readonly string SQL_SELECT_ALL_BY_Code = @"select * from Patient where code=@code";

       // private readonly string SQL_SELECT_ALL_CONSPt = @"select * from Consultation cl  where cl.id=@code";



       

        public PatientRepository(string connectionString)
        {
            ConnectionString = connectionString;




        }












        public Patient findById(int id)


        {

            Patient pt = null;


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
                    command.Parameters.Add("@idPatient", SqlDbType.Int).Value = id;

                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {

                        pt = new Patient()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            IdPatient = (int)dr[0],

                            Code = dr[1].ToString(),

                            Nom = dr[2].ToString(),

                            Antecedent = dr[3].ToString()
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



            return pt;

        }















        public void update(Patient obj)
        {
            throw new NotImplementedException();
        }



        public Patient save(Patient pt)
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
                    // int Id = (int)command.ExecuteScalar();
                    //--paramters ptS


                   


                    command.Parameters.Add("@code", SqlDbType.NVarChar).Value = pt.Code;
                    command.Parameters.Add("@nom", SqlDbType.NVarChar).Value = pt.Nom;
                    command.Parameters.Add("@prenom", SqlDbType.NVarChar).Value = pt.Prenom;
                    command.Parameters.Add("@antecedent", SqlDbType.NVarChar).Value = pt.Antecedent;

                    //patient.Code = ;
                    // command.Parameters.Add("@antecedent", SqlDbType.NVarChar).Value = pt.Antecedent;
                    


                    // int id = (int)command.ExecuteScalar();
                    //pt.IdPatient = id;
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


                return pt;
            }
        }

        public List<Patient> findAll()
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
                    command.CommandText = SQL_SELECT_ALL;


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




















        public void delete(int id)
        {
            throw new NotImplementedException();
        }






        public Patient RechercheBycode(string code)
        {
            Patient pt = null;

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
                    command.CommandText = SQL_SELECT_ALL_BY_Code;
                    command.Parameters.Add("@code", SqlDbType.NVarChar).Value = code;


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();


                    if (dr.Read())
                    {
                        pt = new Patient();

                        pt.IdPatient = (int)dr[0];

                        pt.Nom = dr[2].ToString();
                        pt.Code = dr[1].ToString();

                        pt.Prenom = dr[4].ToString();








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



            return pt;
        }

        public List<Consultation> TrouverconsultationsPt(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
