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

namespace consultationProjet.repository
{
    public class PrestationRepository : BaseRepository, IPrestationRepository
    {


        private readonly string SQL_SELECT_ALL = @"select * from prestation where DatePrestation= CAST(GETDATE() AS DATE) ";
        private readonly string SQL_INSERT_Prestation = @"insert into prestation (DatePrestation,ResultatPrestation,typePrestation,idPatient,idRp)
      output INSERTED.id values(@DatePrestation,@ResultatPrestation,@typePrestation,@idPatient,@idRp)";


     



        private readonly string SQL_SELECT_ALL_Prestation = @"select * from prestation where  idPatient=@idPatient";


        private IPatientRepository patientRepository;
        private IRpRepository rpRepository;


        public PrestationRepository(string connectionString, IPatientRepository patientRepository, IRpRepository rpRepository)
        {
            ConnectionString = connectionString;
            this.patientRepository = patientRepository;
            this.rpRepository = rpRepository;
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

    
        public List<Prestation> findAll()
        {
            List<Prestation> prestationList = new List<Prestation>();



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
                        Prestation prestation = new Prestation();


                        prestation.Id = (int)dr[0];

                        if (!Convert.IsDBNull(dr[1]))
                        {
                            prestation.DatePrestation = (DateTime)dr[1];
                        }
                        prestation.ResultatPrestation = dr[2].ToString();
                       
                       
            

                            Patient patient = patientRepository.findById((int)dr[3]);


                            prestation.Patient = patient;

                        



                            Rp rp = rpRepository.findbyId((int)dr[4]);

                            prestation.Rp = rp;
                   


                        prestationList.Add(prestation);
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



            return prestationList;   }



        public Prestation save(Prestation pr)
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
                    command.CommandText = SQL_INSERT_Prestation;

                    command.Parameters.Add("@DatePrestation", SqlDbType.Date).Value = pr.DatePrestation;


                    command.Parameters.Add("@ResultatPrestation", SqlDbType.NVarChar).Value = pr.ResultatPrestation;

                    command.Parameters.Add("@idPatient", SqlDbType.Int).Value = pr.Patient.IdPatient;

                    command.Parameters.Add("@typePrestation", SqlDbType.NVarChar).Value = pr.TypePrestation;


                    command.Parameters.Add("@idRp", SqlDbType.Int).Value = pr.Rp.Id;

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
                return pr;
            }
        }









        public Prestation findById(int id)
        {
            throw new NotImplementedException();
        }

       


        public void persit(Prestation rdv)
        {
            throw new NotImplementedException();
        }

       
      

        public void update(Prestation obj)
        {
            throw new NotImplementedException();
        }













        public List<Prestation> filtrerPrestationByPatient(int id)
        {
            List<Prestation> PrestationListbyPt = new List<Prestation>();



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
                    command.CommandText = SQL_SELECT_ALL_Prestation;
                    command.Parameters.Add("idPatient", SqlDbType.Int).Value = id;


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();


                    while (dr.Read())
                    {
                        Prestation prestation = new Prestation();


                        prestation.Id = (int)dr[0];

                        if (!Convert.IsDBNull(dr[1]))
                        {
                            prestation.DatePrestation = (DateTime)dr[1];
                        }
                        prestation.ResultatPrestation = dr[2].ToString();




                        Patient patient = patientRepository.findById((int)dr[3]);


                        prestation.Patient = patient;





                        Rp rp = rpRepository.findbyId((int)dr[4]);

                        prestation.Rp = rp;



                        PrestationListbyPt.Add(prestation);
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

            return PrestationListbyPt;
        }




    }
}
