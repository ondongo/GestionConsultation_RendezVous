using consultationProjet.models;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository
{
    public class RpRepository: BaseRepository, IRpRepository
    {
        private readonly string SQL_SELECT_ALL_Rp = @"select * from utilisateurs where role LIKE 'Rp' and etat LIKE 'Dispo' ";

        private readonly string SQL_SELECT_BY_ID = @"select * from utilisateurs  where idUtilisateur=@idUtilisateur and role LIKE 'Rp'";


        public RpRepository(string connectionString)
        {

            ConnectionString = connectionString;
        }





        public Rp findbyId(int id)
        {
            Rp rp = null;


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





                        rp = new Rp()
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



            return rp;
        }























        public List<Rp> listRpdipo()
        {
            List<Rp> rpList = new List<Rp>();

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
                    command.CommandText = SQL_SELECT_ALL_Rp;


                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        Rp med = new Rp()
                        {

                            //convertir dr avant 
                            Id = (int)dr[0],


                            Nom = dr[4].ToString(),
                            Login = dr[1].ToString(),
                           




                        };


                        Enum.TryParse(dr[3].ToString(), out RoleUsers type3);
                        med.Role = type3;

                        Enum.TryParse(dr[6].ToString(), out Etat type2);
                        med.Etat = type2;


                        rpList.Add(med);
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



            return rpList;
        }
    }
}
