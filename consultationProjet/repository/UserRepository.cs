using consultationProjet.models;
using consultationProjet.repository.intertfaceRepositor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;

namespace consultationProjet.repository
{
    public class UserRepository : BaseRepository, IUserRepository

    {

        //---requete------------Sql


        private readonly string SQL_CONNECT = @"select * from utilisateurs where login=@login";
     





        public UserRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

    

    public User findUserByLogin(string login)
        {


            User us = null;
                    
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
                    command.CommandText = SQL_CONNECT;

                    //parameters
                    command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;

                    //-------------pour les requetes select---------------c
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {

                        us = new User()
                        {


                            //Id = int.Parse(dr[0].ToString() ),
                            Id = (int)dr[0],
                            Nom = dr[4].ToString(),
                            Login = dr[1].ToString(),
                            Password = dr[2].ToString()

                        };

                        //parse no error tryparse top
                        //out result
                        Enum.TryParse(dr[3].ToString(), out RoleUsers type);
                        us.Role = type;


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



            return us;
        }

    }
}
