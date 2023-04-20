
using consultationProjet.models;
using consultationProjet.repository.intertfaceRepositor;
using consultationProjet.services;
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
    public class RendezVousRepository : BaseRepository, IRendezVousRepository
    {

        //Mes Requetes ----------SQl lecture--------------
        //Cote Vu Sec
        //private readonly string SQL_SELECT_ALL = @"select * from rendezvous  ";

        private readonly string SQL_SELECT_ALL = @"select * from rendezvous where date= CAST(GETDATE() AS DATE)";

        private readonly string SQL_SELECT_TYPE = @"select * from rendezvous where typeRdv like '%' +@typeRdv +'%' ";

        private readonly string SQL_SELECT_ALL_BY_DATE = @"select * from rendezvous where date=@date";

        private readonly string SQL_SELECT_ETAT = @"select * from rendezvous where etatrdv like '%' +@etatrdv +'%' and typeRdv=@typeRdv and idUtilisateur=@idUtilisateur";

        private readonly string SQL_SELECT_PRESTATION = @"select * from rendezvous where date= CAST(GETDATE() AS DATE)  and typeRdv like '%' +@typeRdv +'%' ";

        private readonly string SQL_SELECT_FILTRE_PRESTATION = @"select * from rendezvous where date= @date  and typeRdv like '%' +@typeRdv +'%' ";





        //Cote Vu USER
        private readonly string SQL_SELECT_RDV_USER = @"select * from rendezvous where date=@date  and idUtilisateur=@idUtilisateur and typeRdv like '%' +@typeRdv +'%' ";


        






        //ORM EVIT REPETITION
        //Mes Requetes -------------SQl ecriture-----------------
        private readonly string SQL_INSERT = @"insert into rendezvous (date,typeRdv,idPatient,idUtilisateur,heure,etatrdv) output INSERTED.id values(@date,@typeRdv,@idPatient,@idUtilisateur,@heure,@etatrdv)";
        // private readonly string SQL_INSERT = @"insert into rendezvous(date,typeRdv,idUtilisateur) values(CAST(GETDATE() AS DATE),@typeRdv,@idUtilisateur)";
        //private readonly string SQL_INSERT = @"insert into rendezvous(date,typeRdv,idPatient) values(CAST(GETDATE() AS DATE),@typeRdv,@idPatient)";
      
        private readonly string SQL_DELETE = @"delete from rendezvous where id=@id and etatrdv='Annule'";
        private readonly string SQL_UPDATE = @"update rendezvous set etatrdv='Annule' where id=@id ";
        private readonly string SQL_UPDATE_Validation = @"update rendezvous set etatrdv=@etatrdv where id=@id ";
        //private readonly string SQL_INSERT = @"insert into rendezvous(date,typeRdv) values(CAST(GETDATE() AS DATE),@typeRdv); SELECT SCOPE_IDENTITY()";
        //private readonly string SQL_INSERT = @"insert into rendezvous(date,typeRdv) values(CAST(GETDATE() AS DATE),@typeRdv)";







        private IPatientRepository patientRepository;
        private IMedecinRepository medRepository;
        private IRpRepository rpRepository;

        //patient 
        public RendezVousRepository(string connectionString, IPatientRepository patientRepository, IMedecinRepository medRepository, IRpRepository rpRepository)
        {
            ConnectionString = connectionString;
            this.patientRepository = patientRepository;
            this.medRepository = medRepository;
            this.rpRepository = rpRepository;
        }




        //Lister les rendez Vous Bd
        public List<RendezVous> findAll()
        {
            List<RendezVous> rdvList = new List<RendezVous>();



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
                        RendezVous rendezvous = new RendezVous();
                        rendezvous.Id = (int)dr[0]; 

                        

                        if (!Convert.IsDBNull(dr[1]))
                        {
                            rendezvous.Date = (DateTime)dr[1];
                        }

                        Enum.TryParse(dr[2].ToString(), out TypeRdv type);
                        rendezvous.TypeRdv = type;

                        Enum.TryParse(dr[5].ToString(), out Etatrdv type2);
                        rendezvous.Etatrdv = type2;


                        // if (!Convert.IsDBNull(dr[3]))
                        //{
                        //   Patient patient = Fabrique.getptService().TrouverbyIdPt((int)dr[3]);
                        //  rendezvous.Patient = patient;
                        //}

                        if (!Convert.IsDBNull(dr[3]))
                        {

                            Patient patient = patientRepository.findById((int)dr[3]);
                            rendezvous.Patient = patient;

                        }

                        if (!Convert.IsDBNull(dr[4]))
                        {
                            if (rendezvous.TypeRdv.ToString()== TypeRdv.Consultation.ToString()) 
                            {



                                Medecin med = medRepository.findById((int)dr[4]);

                                rendezvous.Medecin = med;
                             }



                            if (rendezvous.TypeRdv.ToString() == TypeRdv.Prestation.ToString())
                            {



                                Rp rp = rpRepository.findbyId((int)dr[4]);

                                rendezvous.Rp = rp;
                            }





                        }


                        if (!Convert.IsDBNull(dr[6]))
                        {
                            rendezvous.Heure = dr[6].ToString();

                        }


                        rdvList.Add(rendezvous);
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



            return rdvList;
        }

       

        public RendezVous findById(int id)
        {
            throw new NotImplementedException();
        }










        // -----------------------Filtrer ------------------------



        public List<RendezVous> findByType(string typeRdv)
        {

            List<RendezVous> rdvs = new List<RendezVous>();

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
                    command.CommandText = SQL_SELECT_TYPE;

                    //parameters
                    command.Parameters.Add("@typeRdv", SqlDbType.NVarChar).Value = typeRdv;



                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        RendezVous rdv = new RendezVous()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0]
                        };
                             if (!Convert.IsDBNull(dr[1]))
                        {
                            rdv.Date = (DateTime)dr[1];
                        }

                        Enum.TryParse(dr[2].ToString(), out TypeRdv type);
                        rdv.TypeRdv = type;

                        Enum.TryParse(dr[5].ToString(), out Etatrdv type2);
                        rdv.Etatrdv = type2;

                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[3]);


                            rdv.Patient = patient;



                        }





                        if (!Convert.IsDBNull(dr[4]))
                        {

                            if (rdv.TypeRdv.ToString() == TypeRdv.Consultation.ToString())
                            {



                                Medecin med = medRepository.findById((int)dr[4]);

                                rdv.Medecin = med;
                            }



                            if (rdv.TypeRdv.ToString() == TypeRdv.Prestation.ToString())
                            {



                                Rp rp = rpRepository.findbyId((int)dr[4]);

                                rdv.Rp = rp;
                            }
                        }

                        if (!Convert.IsDBNull(dr[6]))
                        {
                            rdv.Heure = dr[6].ToString();

                        }


                        rdvs.Add(rdv);

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



                        return rdvs;




        }




        public List<RendezVous> findBydate(string date)
        {
            List<RendezVous> rdvs = new List<RendezVous>();

            
            
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
                    command.CommandText = SQL_SELECT_ALL_BY_DATE;

                    //convert pas bess
                     DateTime date1 = DateTime.Parse(date);


                    //parameters
                    command.Parameters.Add("@date", SqlDbType.Date).Value = date1;

                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        RendezVous rdv = new RendezVous()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0]
                        };


                        if (!Convert.IsDBNull(dr[1] ))
                        {
                            rdv.Date = (DateTime)dr[1];
                        }

                        Enum.TryParse(dr[2].ToString(), out TypeRdv type);
                        rdv.TypeRdv = type;

                        Enum.TryParse(dr[5].ToString(), out Etatrdv type2);
                        rdv.Etatrdv = type2;

                        if (!Convert.IsDBNull(dr[3]))
                        {
                            Patient patient = Fabrique.getptService().TrouverbyIdPt((int)dr[3]);
                            rdv.Patient = patient;
                        }

                        if (!Convert.IsDBNull(dr[4]))
                        {

                            if (rdv.TypeRdv.ToString() == TypeRdv.Consultation.ToString())
                            {



                                Medecin med = medRepository.findById((int)dr[4]);

                                rdv.Medecin = med;
                            }



                            if (rdv.TypeRdv.ToString() == TypeRdv.Prestation.ToString())
                            {



                                Rp rp = rpRepository.findbyId((int)dr[4]);

                                rdv.Rp = rp;
                            }

                        }

                        if (!Convert.IsDBNull(dr[6]))
                        {
                            rdv.Heure = dr[6].ToString();

                        }

                        rdvs.Add(rdv);

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



            return rdvs;
        }


        //------------------- FIN_________FIND--------------










        // -------------------- ajout ------------------------------------------
        public RendezVous save (RendezVous rdv)
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

                    command.Parameters.Add("@typeRdv", SqlDbType.NVarChar).Value = rdv.TypeRdv;


                    command.Parameters.Add("@date",SqlDbType.Date).Value =rdv.Date ;
                    command.Parameters.Add("@etatrdv", SqlDbType.NVarChar).Value = Etatrdv.Encours.ToString();

                    command.Parameters.Add("@idPatient", SqlDbType.Int).Value = rdv.Patient.IdPatient;








                   if (rdv.TypeRdv.ToString() == TypeRdv.Consultation.ToString())
                    { 
                   command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = rdv.Medecin.Id;
                    }

                    else
                    {
                        command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = rdv.Rp.Id;
                    }







                    command.Parameters.Add("@heure", SqlDbType.NVarChar).Value = rdv.Heure;
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
                return rdv;
            }
        }




        //-------------delete rdv-------------------
        public void delete(int id)
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
                    command.CommandText = SQL_DELETE;

                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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





        //-----------------------------------modif-------------------------------
        public void update(RendezVous rdv)
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

                    command.Parameters.Add("@etatrdv", SqlDbType.NVarChar).Value = rdv.Etatrdv;

                    command.Parameters.Add("@id", SqlDbType.Int).Value = rdv.Id;
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












        // INTERESSANT MAIS JE NE VAIS PAS UTILISER 

        public void persit(RendezVous rdv)
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



                    if (rdv.Id != 0)
                    {
                        ///mode modif
                        command.CommandText = SQL_UPDATE;
                        command.Parameters.Add("@etatrdv", SqlDbType.NVarChar).Value = rdv.Etatrdv;
                    }


                    else {
                        
                        command.CommandText = SQL_INSERT;
                        command.Parameters.Add("@typeRdv", SqlDbType.NVarChar).Value = rdv.TypeRdv;
                        //command.Parameters.Add("@date",SqlDbType.Date).Value =DateTime.Now ;
                        command.Parameters.Add("@idPatient", SqlDbType.Int).Value = rdv.Patient.IdPatient;
                        command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = rdv.Medecin.Id;

                    }

                    


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




       // --------------------------------- Vue RP----------
       
        public List<RendezVous> findByPrestation()
        {
            List<RendezVous> rdvs = new List<RendezVous>();

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
                    command.CommandText = SQL_SELECT_PRESTATION;

                    //parameters
                    command.Parameters.Add("@typeRdv", SqlDbType.NVarChar).Value = TypeRdv.Prestation.ToString();

                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        RendezVous rdv = new RendezVous()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0],
                        };
                        if (!Convert.IsDBNull(dr[1]))
                        {
                            rdv.Date = (DateTime)dr[1];
                        }

                        Enum.TryParse(dr[2].ToString(), out TypeRdv type);
                        rdv.TypeRdv = type;

                        Enum.TryParse(dr[5].ToString(), out Etatrdv type2);
                        rdv.Etatrdv = type2;


                        if (!Convert.IsDBNull(dr[4]))
                        {

                            if (rdv.TypeRdv.ToString() == TypeRdv.Consultation.ToString())
                            {



                                Medecin med = medRepository.findById((int)dr[4]);

                                rdv.Medecin = med;
                            }



                            if (rdv.TypeRdv.ToString() == TypeRdv.Prestation.ToString())
                            {



                                Rp rp = rpRepository.findbyId((int)dr[4]);

                                rdv.Rp = rp;
                            }
                        }





                        rdvs.Add(rdv);

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



            return rdvs;

        }



        public List<RendezVous> findByAllAnnule()
        {
            List<RendezVous> rdvs = new List<RendezVous>();

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
                    command.CommandText = SQL_SELECT_ETAT;

                    //parameters
                    command.Parameters.Add("@etatrdv", SqlDbType.NVarChar).Value = Etatrdv.Annule.ToString();

                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        RendezVous rdv = new RendezVous()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0]
                        };
                        if (!Convert.IsDBNull(dr[1]))
                        {
                            rdv.Date = (DateTime)dr[1];
                        }

                        Enum.TryParse(dr[2].ToString(), out TypeRdv type);
                        rdv.TypeRdv = type;

                        Enum.TryParse(dr[5].ToString(), out Etatrdv type2);
                        rdv.Etatrdv = type2;

                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[3]);


                            rdv.Patient = patient;



                        }





                        if (!Convert.IsDBNull(dr[4]))
                        {

                            if (rdv.TypeRdv.ToString() == TypeRdv.Consultation.ToString())
                            {



                                Medecin med = medRepository.findById((int)dr[4]);

                                rdv.Medecin = med;
                            }



                            if (rdv.TypeRdv.ToString() == TypeRdv.Prestation.ToString())
                            {



                                Rp rp = rpRepository.findbyId((int)dr[4]);

                                rdv.Rp = rp;
                            }
                        }

                        rdvs.Add(rdv);

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



            return rdvs;

        }






        //--------------------------RP

        public List<RendezVous> findPrestationBydate(string date)
        {
            List<RendezVous> rdvs = new List<RendezVous>();



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
                    command.CommandText = SQL_SELECT_FILTRE_PRESTATION;

                    //convert
                    DateTime date1 = DateTime.Parse(date);
                    //parameters
                    command.Parameters.Add("@date", SqlDbType.Date).Value = date1;
                    command.Parameters.Add("@typeRdv", SqlDbType.NVarChar).Value = TypeRdv.Prestation.ToString();

                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        RendezVous rdv = new RendezVous()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0]
                        };


                        if (!Convert.IsDBNull(dr[1]))
                        {
                            rdv.Date = (DateTime)dr[1];
                        }

                        Enum.TryParse(dr[2].ToString(), out TypeRdv type);
                        rdv.TypeRdv = type;

                        Enum.TryParse(dr[5].ToString(), out Etatrdv type2);
                        rdv.Etatrdv = type2;

                        if (!Convert.IsDBNull(dr[3]))
                        {
                            Patient patient = Fabrique.getptService().TrouverbyIdPt((int)dr[3]);
                            rdv.Patient = patient;
                        }


                        if (!Convert.IsDBNull(dr[4]))
                        {

                            if (rdv.TypeRdv.ToString() == TypeRdv.Consultation.ToString())
                            {



                                Medecin med = medRepository.findById((int)dr[4]);

                                rdv.Medecin = med;
                            }



                            if (rdv.TypeRdv.ToString() == TypeRdv.Prestation.ToString())
                            {



                                Rp rp = rpRepository.findbyId((int)dr[4]);

                                rdv.Rp = rp;
                            }
                        }

                        if (!Convert.IsDBNull(dr[6]))
                        {
                            rdv.Heure = dr[6].ToString();

                        }

                        rdvs.Add(rdv);

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



            return rdvs;
        }






        //--------------------------------------------------------MED

        public List<RendezVous> findRDVMED(int id)
        {
            List<RendezVous> rdvs = new List<RendezVous>();

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
                    command.CommandText = SQL_SELECT_RDV_USER;

                    //parameters
                  
                    command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now;
                    command.Parameters.Add("@typeRdv", SqlDbType.NVarChar).Value = TypeRdv.Consultation.ToString();


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        RendezVous rdv = new RendezVous()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0]
                        };
                        if (!Convert.IsDBNull(dr[1]))
                        {
                            rdv.Date = (DateTime)dr[1];
                        }

                        Enum.TryParse(dr[2].ToString(), out TypeRdv type);
                        rdv.TypeRdv = type;

                        Enum.TryParse(dr[5].ToString(), out Etatrdv type2);
                        rdv.Etatrdv = type2;

                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[3]);


                            rdv.Patient = patient;



                        }





                        if (!Convert.IsDBNull(dr[4]))
                        {

                            if (rdv.TypeRdv.ToString() == TypeRdv.Consultation.ToString())
                            {



                                Medecin med = medRepository.findById((int)dr[4]);

                                rdv.Medecin = med;
                            }



                          
                        }

                        if (!Convert.IsDBNull(dr[6]))
                        {
                            rdv.Heure = dr[6].ToString();

                        }


                        rdvs.Add(rdv);

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



            return rdvs;


        }









        //-----------------------------------------------------Validation------------------------------------------------------

        public void Validation(RendezVous rdv)
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
                    command.CommandText = SQL_UPDATE_Validation;






                    command.Parameters.Add("@etatrdv", SqlDbType.NVarChar).Value = Etatrdv.Valide.ToString();

                    command.Parameters.Add("@id", SqlDbType.Int).Value = rdv.Id;
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




        public List<RendezVous> findByEtat(string etatRdv, string type, int id)
        {
            List<RendezVous> rdvsEtat = new List<RendezVous>();

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
                    command.CommandText = SQL_SELECT_ETAT;

                    //parameters
                    command.Parameters.Add("@etatrdv", SqlDbType.NVarChar).Value = etatRdv;
                    command.Parameters.Add("@typeRdv", SqlDbType.NVarChar).Value = type;
                    command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = id;

                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        RendezVous rdv = new RendezVous()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0]
                        };
                        if (!Convert.IsDBNull(dr[1]))
                        {
                            rdv.Date = (DateTime)dr[1];
                        }

                        Enum.TryParse(dr[2].ToString(), out TypeRdv type1);
                        rdv.TypeRdv = type1;

                        Enum.TryParse(dr[5].ToString(), out Etatrdv type2);
                        rdv.Etatrdv = type2;

                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[3]);


                            rdv.Patient = patient;



                        }





                        if (!Convert.IsDBNull(dr[4]))
                        {

                            if (rdv.TypeRdv.ToString() == TypeRdv.Consultation.ToString())
                            {



                                Medecin med = medRepository.findById((int)dr[4]);

                                rdv.Medecin = med;
                            }



                            if (rdv.TypeRdv.ToString() == TypeRdv.Prestation.ToString())
                            {



                                Rp rp = rpRepository.findbyId((int)dr[4]);

                                rdv.Rp = rp;
                            }
                        }

                        rdvsEtat.Add(rdv);

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



            return rdvsEtat;
        }




        public List<RendezVous> findRDVRp(int id)
        {
            List<RendezVous> rdvs = new List<RendezVous>();

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
                    command.CommandText = SQL_SELECT_RDV_USER;

                    //parameters

                    command.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now;
                    command.Parameters.Add("@typeRdv", SqlDbType.NVarChar).Value = TypeRdv.Prestation.ToString();


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        RendezVous rdv = new RendezVous()
                        {

                            //convertir dr avant 
                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0]
                        };
                        if (!Convert.IsDBNull(dr[1]))
                        {
                            rdv.Date = (DateTime)dr[1];
                        }

                        Enum.TryParse(dr[2].ToString(), out TypeRdv type);
                        rdv.TypeRdv = type;

                        Enum.TryParse(dr[5].ToString(), out Etatrdv type2);
                        rdv.Etatrdv = type2;

                        if (!Convert.IsDBNull(dr[3]))
                        {


                            Patient patient = patientRepository.findById((int)dr[3]);


                            rdv.Patient = patient;



                        }





                        if (!Convert.IsDBNull(dr[4]))
                        {

                            if (rdv.TypeRdv.ToString() == TypeRdv.Prestation.ToString())
                            {



                                Rp rp = rpRepository.findbyId((int)dr[4]);

                                rdv.Rp = rp;
                            }




                        }

                        if (!Convert.IsDBNull(dr[6]))
                        {
                            rdv.Heure = dr[6].ToString();

                        }


                        rdvs.Add(rdv);

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



            return rdvs;
        }
    }
}
