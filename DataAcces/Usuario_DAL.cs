using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Services.Cache;



namespace DataAcces
{
    public class User_DATA
    {
        ConnetionToSQL con = new ConnetionToSQL();

        SqlCommand comando = new SqlCommand();
        SqlCommand comando2 = new SqlCommand();


        public void Insert_User(string loginName, string password, string firstName, string lastName, string position, string email)
        {
            comando2.Connection = con.Conectar();
            comando2.CommandText = "CreateUsers";
            comando2.CommandType = CommandType.StoredProcedure;
      
            comando2.Parameters.AddWithValue("@loginName", loginName);
            comando2.Parameters.AddWithValue("@password", password);
            comando2.Parameters.AddWithValue("@firstName", firstName);
            comando2.Parameters.AddWithValue("@lastName", lastName);
            comando2.Parameters.AddWithValue("@position", position);
            comando2.Parameters.AddWithValue("@email", email);
            comando2.ExecuteNonQuery();
            comando2.Parameters.Clear();
            con.Desconectar();
        }

        public bool Login(string user, string pass)
        {
                    con = new ConnetionToSQL();

                    comando = new SqlCommand();

                    comando.Connection=con.Conectar();

                    comando.CommandText = "select *from Users where loginName=@user and Convert(nvarchar(MAX), DECRYPTBYPASSPHRASE('password', password)) = @password ";
                    comando.Parameters.AddWithValue("@user", user);
                    comando.Parameters.AddWithValue("@password", pass);

                    comando.CommandType = CommandType.Text;


                    SqlDataReader reader = comando.ExecuteReader();



            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserLoginCache.userId = reader.GetInt32(0);
                    UserLoginCache.firstName = reader.GetString(3);
                    UserLoginCache.position = reader.GetString(5);
                    UserLoginCache.email = reader.GetString(6);

                }

                return true;

            }
           

            else 
            {

                return false;

            }
            


        }


        public void AnyMethod()
        {
            if (UserLoginCache.position==Positions.Administrador)
	        {

	        }
            if (UserLoginCache.position==Positions.Vendedor)
            {

            }
        }

        }
    
}
